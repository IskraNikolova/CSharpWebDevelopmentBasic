namespace SimpleHttpServer
{
    using System.IO;
    using Enums;
    using Models;

    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string content = File.ReadAllText(path: "Resources/Pages/500.html");

            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.InternalServerError,
                ContentAsUTF8 = content
            };
        }

        public static HttpResponse NotFound()
        {
            string content = File.ReadAllText(path: "Resources/Pages/404.html");

            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.NotFound,
                ContentAsUTF8 = content
            };
        }
    }
}