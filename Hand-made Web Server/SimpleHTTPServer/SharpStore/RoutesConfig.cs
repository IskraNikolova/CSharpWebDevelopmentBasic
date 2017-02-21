namespace SharpStore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Razor;
    using SharpStoreServices;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public static class RoutesConfig
    {
        public static IList<Route> GetRoutes()
        {
            var routes = new List<Route>()
            {
                 new Route()
                {
                    Name = "Home Directories",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/home.*$",
                    Callable = (request) =>
                    {
                        //AddCookies(request);
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = new HomePage().ToString()
                        };
                   }
                },
               new Route()
               {
                     Name = "DirectoriesTheme",
                     Method = RequestMethod.GET,
                     UrlRegex = @"^/.+?\\?theme=.+$",
                     Callable = (request) =>
                     {
                        //AddCookies(request);
                        var index = request.Url.IndexOf('?');
                        var themeDict = QueryStringParser.Parser(request.Url.Substring(index + 1));
                        var htmlName = request.Url.Substring(1, index - 1);

                        var pageName =Assembly.GetAssembly(typeof(Razor.Page))
                            .GetTypes()
                            .FirstOrDefault(type => 
                                type.Name.Contains(htmlName[0].ToString().ToUpper() 
                                + htmlName.Substring(1)));

                        var pageInstance = (Page)Activator.CreateInstance(pageName);

                        var responce = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = pageInstance.ToString()
                        };

                        responce.Header.Cookies.Add(new Cookie("theme", themeDict["theme"]));
                        return responce;
                     }
                 },
                new Route()
                {
                    Name = "ContactsGET",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/contacts.*$",
                    Callable = (request) =>
                    {
                        //AddCookies(request);
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = new ContactPage().ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "ContactsPost",
                    Method = RequestMethod.POST,
                    UrlRegex = @"^/contacts.*$",
                    Callable = (request) =>
                    {
                        //AddCookies(request);
                        var queryString = request.Content;
                        IDictionary<string, string> variables = QueryStringParser.Parser(queryString);
                        var service = new MessagesService();
                        service.AddMessageFromPostVariables(variables);
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = new ContactPage().ToString()
                        };
                    }
                },
               
                 new Route()
                {
                    Name = "About Directories",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/about.*$",
                    Callable = (request) =>
                    {
                        //AddCookies(request);
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = new AboutPage().ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "Products Directories",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/products.*$",
                    Callable = (request) =>
                    {
                        //AddCookies(request);
                        KnivesService service = new KnivesService();
                        var products = service.GetAllKnivesFromUrl(request.Url);
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = new ProductsPage(products).ToString()
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
                            StatusCode = ResponseStatusCode.OK,
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
                    UrlRegex = "^/css/.+$",
                    Callable = (request) =>
                               {
                                   var cssFileName = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText($"../../content/css/{cssFileName}")
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
                            StatusCode = ResponseStatusCode.OK,
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
                            StatusCode = ResponseStatusCode.OK,
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
                            StatusCode = ResponseStatusCode.OK,
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
                            StatusCode = ResponseStatusCode.OK,
                            Content =  File.ReadAllBytes($"../../content/images/{nameOfFile}")
                        };

                        response.Header.ContentType = "image/jpeg";
                        return response;
                    }
                }
            };

            return routes;
        }

        private static void AddCookies(HttpRequest request)
        {
            
            if (request.Header.Cookies.Cookies.ContainsKey("theme"))
            {
                Cookies.cookies["theme"] = request.Header.Cookies["theme"].Value;
            }
            else
            {
                request.Header.Cookies.Add(new Cookie("theme", ""));
            }
            
        }
    }
}
