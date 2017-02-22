namespace SharpStore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using MVCFramework.MVC.Routers;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    public static class RouteTable
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                       new Route()
                    {
                        Name = "Testemonial",
                        Method = RequestMethod.GET,
                        UrlRegex = "/testemonial.css$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText(@"../../content/css/testemonial.css")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },

                      new Route()
                    {
                        Name = "HolderJS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/holder.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText(@"../../content/imsky-holder-8220898/holder.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                     new Route()
                    {
                        Name = "Carousel CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/favicon.ico$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content = File.ReadAllBytes(@"../../content/images/knife.ico")
                            };
                            response.Header.ContentType = "image/*";
                            response.Header.ContentLength = response.Content.Length.ToString();
                            return response;
                        }
                    },

                    new Route()
                    {
                        Name = "Carousel CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/carousel.css$",
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
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/bootstrap/js/bootstrap.min.js$",
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
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/jquery/jquery-3.1.1.js$",
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
                        Name = "Bootstrap CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/bootstrap/css/bootstrap.min.css$",
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
                        Name = "Images",
                        Method = RequestMethod.GET,
                        UrlRegex = "/images/(.)+.png$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content= File.ReadAllBytes($@"../../{request.Url}")
                            };
                            response.Header.ContentType = "image/png";
                            response.Header.ContentLength = response.Content.Length.ToString();
                            return response;
                        }
                    },
                    //TODO: Add the route to bootstrap.min.css file here
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
                    },
                       

                };
            }
        }
    }
}
