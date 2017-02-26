namespace SimpleHttpServer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using Enums;
    using Models;
    using Utilities;

    public class HttpProcessor
    {
        private IList<Route> Routes;
        private HttpRequest Request;
        private HttpResponse Response;
        private readonly IDictionary<string, HttpSession> sessions;

        public HttpProcessor(IEnumerable<Route> routes, IDictionary<string, HttpSession> sessions)
        {
            this.Routes = new List<Route>(collection: routes);
            this.sessions = sessions;
        }

        public void HandleClient(TcpClient tcpClient)
        {
            using (var stream = tcpClient.GetStream())
            {
                this.Request = this.GetRequest(inputStream: stream);
                this.Response = this.RouteRequest();
                Console.WriteLine(value: "-RESPONSE-------------");
                Console.WriteLine(value: this.Response.Header);
                //Console.WriteLine(Encoding.UTF8.GetString(this.Response.Content));
                Console.WriteLine(value: "----------------------");
                StreamUtils.WriteResponse(stream: stream, response: this.Response);
            }
        }

        private HttpRequest GetRequest(Stream inputStream)
        {
            string requestLine = StreamUtils.ReadLine(stream: inputStream);
            string[] tokens = requestLine.Split();

            while (tokens.Length != 3)
            {
                requestLine = StreamUtils.ReadLine(stream: inputStream);
                tokens = requestLine.Split();
            }

            RequestMethod method = (RequestMethod)Enum.Parse(enumType: typeof(RequestMethod), value: tokens[0]
                .ToUpper());

            string url = tokens[1];
            string protocolVersion = tokens[2];

            //Read Headers
            Header header = new Header(type: HeaderType.HttpRequest);
            string line;
            while ((line = StreamUtils.ReadLine(stream: inputStream)) != null)
            {
                if (line.Equals(value: ""))
                {
                    break;
                }

                int separator = line.IndexOf(value: ':');
                if (separator == -1)
                {
                    throw new Exception(message: "Invalid http header line: " + line);
                }

                string name = line.Substring(startIndex: 0, length: separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[index: pos] == ' '))
                {
                    pos++;
                }

                string value = line.Substring(startIndex: pos, length: line.Length - pos);
                if (name == "Cookie")
                {
                    string[] cookieSaves = value.Split(';');
                    foreach (var cookieSave in cookieSaves)
                    {
                        string[] cookiePair = cookieSave
                            .Split('=')
                            .Select(selector: x => x.Trim())
                            .ToArray();

                        var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                        header.AddCookie(cookie: cookie);
                    }
                }
                else if (name == "Location")
                {
                    header.Location = value;
                }
                else if (name == "Content-Length")
                {
                    header.ContentLength = value;
                }
                else
                {
                    header.OtherParameters.Add(key: name, value: value);
                }
            }

            string content = null;
            if (header.ContentLength != null)
            {
                int totalBytes = Convert.ToInt32(value: header.ContentLength);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];

                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = inputStream.Read(buffer: buffer, offset: 0, count: buffer.Length);
                    buffer.CopyTo(array: bytes, index: totalBytes - bytesLeft);

                    bytesLeft -= n;
                }

                content = Encoding.ASCII.GetString(bytes: bytes);
            }

            var request = new HttpRequest()
            {
                Method = method,
                Url = url,
                Header = header,
                Content = content
            };

            if (request.Header.Cookies.Contains(cookieName: "sessionId"))
            {
                var sessionId = request.Header.Cookies[cookieName: "sessionId"].Value;
                request.Session = new HttpSession(id: sessionId);
                if (!this.sessions.ContainsKey(key: sessionId))
                {
                    this.sessions.Add(key: sessionId, value: request.Session);
                }
            }

            Console.WriteLine(value: "-REQUEST-----------------------------");
            Console.WriteLine(value: request);
            Console.WriteLine(value: "------------------------------");

            return request;
        }

        private HttpResponse RouteRequest()
        {
            var routes = this.Routes
                .Where(predicate: x => Regex.Match(input: this.Request.Url, pattern: x.UrlRegex).Success)
                .ToList();

            if (!routes.Any())
                return HttpResponseBuilder.NotFound();

            var route = routes
                .FirstOrDefault(predicate: x => x.Method == this.Request.Method);


            if (route == null)
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.MethodNotAllowed
                };


            // trigger the route handler...
            try
            {
                var response = route.Callable(arg: this.Request);
                if (!this.Request.Header.Cookies.Contains(cookieName: "sessionId") ||
                     this.Request.Session == null)
                {
                    var session = SessionCreator.Create();
                    var sessionCookie = new Cookie(name: "sessionId", value: session.Id + "; HttpOnly; path=/");
                    response.Header.AddCookie(cookie: sessionCookie);
                }


                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(value: ex.Message);
                Console.WriteLine(value: ex.StackTrace);

                return HttpResponseBuilder.InternalServerError();
            }
        }
    }
}
