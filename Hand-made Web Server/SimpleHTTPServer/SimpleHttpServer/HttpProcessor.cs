namespace SimpleHttpServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using Enums;
    using Models;

    public class HttpProcessor
    {
        private readonly IList<Route> Routes;
        private HttpRequest Request;
        private HttpResponse Response;

        public HttpProcessor(IEnumerable<Route> routes)
        {
            this.Routes = new List<Route>(routes);
        }

        public void HandleClient(TcpClient tcpClient)
        {
            using (var stream = tcpClient.GetStream())
            {
                this.Request = this.GetRequest(stream);
                this.Response = this.RouteRequest();
                StreamUtils.WriteResponse(stream, this.Response);
            }
        }

        private HttpResponse RouteRequest()
        {
            var routes = this.Routes
                             .Where(x => Regex.Match(this.Request.Url, x.UrlRegex).Success)
                             .ToList();
            if (!routes.Any())
            {
                return HttpResponseBuilder.NotFound();
            }

            var route = routes.SingleOrDefault(x => x.Method == this.Request.Method);
            if (route == null)
            {
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.MethodNotAllowed
                };
            }

            try
            {
                return route.Callable(this.Request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return HttpResponseBuilder.InternalServerError();
            }
        }

        private HttpRequest GetRequest(NetworkStream stream)
        {
            string requestLine = StreamUtils.ReadLine(stream);
            string[] tokens = requestLine.Split();
            if (tokens.Length != 3)
            {
                throw new Exception("Invalid http request line!");
            }

            RequestMethod method = (RequestMethod) Enum.Parse(typeof(RequestMethod), tokens[0].ToUpper());
            string url = tokens[1];
            string protocolVersion = tokens[2];

            Header header = new Header(HeaderType.HttpRequest);
            string line;
            while ((line = StreamUtils.ReadLine(stream)) != null)
            {
                if (line == string.Empty)
                {
                    break;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception($"Invalid http header line: {line}");
                }

                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while (pos < line.Length && line[pos] == ' ')
                {
                    pos++;
                }

                string value = line.Substring(pos, line.Length - pos);
                if (name == "Cookie")
                {
                    string[] cookieSaves = value.Split(';');

                    foreach (var cookieSave in cookieSaves)
                    {
                        string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                        var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                        header.AddCookie(cookie);
                    }
                }
                else if(name == "Content-Length")
                {
                    header.ContentLength = value;
                }
                else
                {
                    header.OtherParameters.Add(name, value);
                }
            }

            string content = null;
            if (header.ContentLength != null)
            {
                int tottalBytes = Convert.ToInt32(header.ContentLength);
                int bytesLeft = tottalBytes;
                byte[] bytes = new byte[tottalBytes];

                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = stream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes, tottalBytes - bytesLeft);

                    bytesLeft -= n;
                }

                content = Encoding.ASCII.GetString(bytes);
            }

            var request = new HttpRequest()
            {
                Method = method,
                Url = url,
                Header = header,
                Content = content
            };

            Console.WriteLine("-REQUEST---------------------");
            Console.WriteLine(request);
            Console.WriteLine("-----------------------------");

            return request;
        }
    }
}
