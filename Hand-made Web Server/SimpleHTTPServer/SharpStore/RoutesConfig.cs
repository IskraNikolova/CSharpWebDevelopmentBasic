namespace SharpStore
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data.Models;
    using Razor;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    public static class RoutesConfig
    {
        private static IList<Knife> knives = Data.Data.Context.Knives.ToList();

        public static IList<Route> GetRoutes()
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directories",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/home$",
                    Callable = (request) =>
                        {
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = new HomePage().ToString()
                        };
                    }
                },
                 new Route()
                {
                    Name = "Products Directories",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/products$",
                    Callable = (request) =>
                        {
                        var products = Data.Data.Context.Knives.ToList();
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = new ProductsPage("../../content/products.html", knives).ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "Directories",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/.+\.html$",
                    Callable = (request) =>
                               {
                        var nameOfFile = request.Url.Substring(1);
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{nameOfFile}")
                        };
                    }
                },
                new Route()
                {
                    Name = "Bootstrap CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/bootstrap/css/bootstrap.min.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                        };

                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/css/carousel.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css")
                        };

                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Jquery",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/jquery/jquery-3.1.1.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/jquery/jquery-3.1.1.js")
                        };

                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };

                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "PngImages",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/images/.+\.png$",
                    Callable = (request) =>
                               {
                        var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/'));
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content =  File.ReadAllBytes($"../../content/images/{nameOfFile}")
                        };

                        response.Header.ContentType = "image/png";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "JpgImages",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/images/.+\.jpg$",
                    Callable = (request) =>
                               {
                        var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/'));
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content =  File.ReadAllBytes($"../../content/images/{nameOfFile}")
                        };

                        response.Header.ContentType = "image/jpeg";
                        return response;
                    }
                }
            };

            return routes;
        }
    }
}
