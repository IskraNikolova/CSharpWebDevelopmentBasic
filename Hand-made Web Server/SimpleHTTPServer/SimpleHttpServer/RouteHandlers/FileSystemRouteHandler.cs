namespace SimpleHttpServer.RouteHandlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Enums;
    using Models;

    public class FileSystemRouteHandler
    {
        public string BasePath { get; set; }

        public bool ShowDirectories { get; set; }

        public HttpResponse Handle(HttpRequest request)
        {
            string urlPart = "";
            urlPart = urlPart.Replace("\\..\\", "\\");
            urlPart = urlPart.Replace("/../", "/");
            urlPart = urlPart.Replace("//", "/");
            urlPart = urlPart.Replace(@"\\", @"\");
            urlPart = urlPart.Replace(":", "");
            urlPart = urlPart.Replace("/", Path.DirectorySeparatorChar.ToString());

            if (urlPart.Length > 0)
            {
                char firstChar = urlPart.ElementAt(0);
                if (firstChar == '/' || firstChar == '\\')
                {
                    urlPart = "." + urlPart;
                }
            }

            string localPath = Path.Combine(this.BasePath, urlPart);

            if (this.ShowDirectories && Directory.Exists(localPath))
            {
                return this.HandleLocalDirectory(request, localPath);
            }
            else if (File.Exists(localPath))
            {
                return this.HandleLocalFile(request, localPath);
            }
            else
            {
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.NotFound
                };
            }
        }

        private HttpResponse HandleLocalFile(HttpRequest request, string localPath)
        {
            string fileExtension = Path.GetExtension(localPath);
            var response = new HttpResponse();
            response.StatusCode = ResponseStatusCode.Ok;
            response.Header.ContentType = QuickMimeTypeMapper.GetMimeType(fileExtension);
            response.Content = File.ReadAllBytes(localPath);

            return response;
        }

        private HttpResponse HandleLocalDirectory(HttpRequest request, string localPath)
        {
            var output = new StringBuilder();
            output.Append(String.Format($"<h1>Directory: {request.Url}</h1>"));

            foreach (var entry in Directory.GetFiles(localPath))
            {
                var fileInfo = new FileInfo(entry);
                var fileName = fileInfo.Name;
                output.Append(string.Format($"<a href=\"{fileName}\">{fileName}</a></br>"));
            }

            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.Ok
            };
        }
    }

    public class QuickMimeTypeMapper
    {
        private static IDictionary<string, string> mappings =
            new Dictionary<string, string>(StringComparer.InvariantCulture);

        public static string GetMimeType(string fileExtension)
        {
            if (fileExtension == null)
            {
                throw new ArgumentNullException("extension");
            }

            if (!fileExtension.StartsWith("."))
            {
                fileExtension = "." + fileExtension;
            }

            string mime;
            return mappings.TryGetValue(fileExtension, out mime) ? mime : "application/octet-stream";
        }      
    }
}
