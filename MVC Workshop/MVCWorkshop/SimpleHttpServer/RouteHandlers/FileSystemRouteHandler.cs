namespace SimpleHttpServer.RouteHandlers
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Enums;
    using Models;
    using Utilities;

    public class FileSystemRouteHandler
    {
        public string BasePath { get; set; }

        public HttpRequest Request { get; set; }

        public string RouteUrlRegex { get; set; }

        public HttpResponse Handle(HttpRequest request)
        {
            this.Request = request;
            string urlPart = string.Empty;

            var match = Regex.Match(input: request.Url, pattern: this.RouteUrlRegex);

            if (match.Groups.Count > 1)
            {
                urlPart = match.Groups[groupnum: 1].Value;
            }
            else
            {
                urlPart = request.Url;
            }        

            urlPart = SanitarizePath(urlPart: urlPart);

            if (urlPart.Length > 0)
            {
                var firstChar = urlPart.ElementAt(index: 0);
                if (firstChar == '/' || firstChar == '\\')
                {
                    urlPart = "." + urlPart;
                }
            }

            var localPath = Path.Combine(path1: this.BasePath, path2: urlPart);

            if (Directory.Exists(path: localPath))
            {
                return this.HandleDirectory(localPath: localPath);
            }
            else if (File.Exists(path: localPath))
            {
                return this.HandleFile(localPath: localPath);
            }
            else
            {
                return HttpResponseBuilder.NotFound();
            }
        }

        private static string SanitarizePath(string urlPart)
        {
            urlPart = urlPart.Replace(oldValue: "\\..\\", newValue: "\\");
            urlPart = urlPart.Replace(oldValue: "/../", newValue: "/");
            urlPart = urlPart.Replace(oldValue: "//", newValue: "/");
            urlPart = urlPart.Replace(oldValue: @"\\", newValue: @"\");
            urlPart = urlPart.Replace(oldValue: ":", newValue: "");
            urlPart = urlPart.Replace(oldValue: "/", newValue: Path.DirectorySeparatorChar.ToString());
            return urlPart;
        }

        private HttpResponse HandleFile(string localPath)
        {
            var fileExtension = Path.GetExtension(path: localPath);

            var response = new HttpResponse();
            response.Header.ContentType = QuickMimeTypeMapper.GetMimeType(fileExtension: fileExtension);

            response.StatusCode = ResponseStatusCode.OK;
            response.Content = File.ReadAllBytes(path: localPath);
            response.Header.ContentLength = response.Content.Length.ToString();
            return response;
        }

        private HttpResponse HandleDirectory(string localPath)
        {
            var output = new StringBuilder();
            output.Append(value: $"<h3> Directory: {this.Request.Url} </h3>");
            output.Append(value: "<ul>");

            foreach (var folder in Directory.GetDirectories(path: localPath).OrderBy(keySelector: d => d))
            {
                var dirInfo = new DirectoryInfo(path: folder);
                output.Append(value: string.Format(format: "<li><a href=\"{0}\">{0}/</a></li>", arg0: dirInfo.Name));

            }

            foreach (var entry in Directory.GetFiles(path: localPath).OrderBy(keySelector: f => f))
            {
                var fileInfo = new FileInfo(fileName: entry);
                output.Append(value: string.Format(format: "<li><a href=\"{0}\">{0}</a></li>", arg0: fileInfo.Name));
            }

            output.Append(value: "</ul>");

            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.OK,
                ContentAsUTF8 = output.ToString(),
            };
        }
    }
}