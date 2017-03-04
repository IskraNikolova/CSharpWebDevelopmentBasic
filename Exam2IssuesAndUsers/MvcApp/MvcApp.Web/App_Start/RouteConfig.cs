namespace MvcApp.Web.App_Star
{
    using System.Collections.Generic;
    using System.IO;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleMVC.Routers;

    public class RouteConfig
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                    //new Route()
                    //{
                    //    Name = "Favicon",
                    //    Method = RequestMethod.GET,
                    //    UrlRegex = "/favicon.ico$",
                    //    Callable = (request) =>
                    //    {
                    //        var response = new HttpResponse()
                    //        {
                    //            StatusCode = ResponseStatusCode.Ok,
                    //            Content = File.ReadAllBytes("../../Content/favicon.ico")
                    //        };

                    //        response.Header.ContentType = "image/x-icon";
                    //        return response;
                    //    }
                    //},
                    new Route()
                    {
                        Name = "Images",
                        Method = RequestMethod.GET,
                        UrlRegex = "/images/(.)$",
                        Callable = (request) =>
                        {                         
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content = File.ReadAllBytes($@"../../{request.Url}")
                            };

                            response.Header.ContentType = "image/*";
                            response.Header.ContentLength = response.Content.Length.ToString();
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Bootstrap CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = @"/bootstrap/css/bootstrap.min.css$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../Content/bootstrap/css/bootstrap.min.css")
                            };

                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Carousel CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/.+$",
                        Callable = (request) =>
                            {
                            var cssFileName = request.Url.Substring(startIndex: request.Url.LastIndexOf(value: '/') + 1);
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../Content/css/{cssFileName}")
                            };

                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Jquery",
                        Method = RequestMethod.GET,
                        UrlRegex = @"/jquery/jquery-3.1.1.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../Content/jquery/jquery-3.1.1.js")
                            };

                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = @"/bootstrap/js/bootstrap.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../Content/bootstrap/js/bootstrap.min.js")
                            };

                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}