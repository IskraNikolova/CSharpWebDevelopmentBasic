namespace SimpleHttpServer
{
    using System.IO;
    using Enums;
    using Models;

    class HttpResponseBuilder
    {
        public static HttpResponse NotFound()
        {
            string content = File.ReadAllText("../../../SimpleHttpServer/Resources/Pages/NotFound.html");
            return new HttpResponse()
            {
                ContentAsUTF8 = content,
                StatusCode = ResponseStatusCode.NotFound
            };
        }

        public static HttpResponse InternalServerError()
        {
            string content = File.ReadAllText("../../../SimpleHttpServer/Resources/Pages/InternalServerError.html");
            return new HttpResponse()
            {
                ContentAsUTF8 = content,
                StatusCode = ResponseStatusCode.NotFound
            };
        }
    }
}
