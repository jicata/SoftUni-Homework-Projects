using BasicHttpServer.Models;
using System.Collections.Generic;
using System.IO;

namespace SharpStore
{
    using System;
    using System.Net;
    using System.Runtime.CompilerServices;
    using BasicHttpServer;
    using BasicHttpServer.Enums;
    using Utility;

    class SharpStore
    {
        static void Main()
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/home$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUtf8 = File.ReadAllText("../../content/home.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/content/css/carousel.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUtf8 = File.ReadAllText("../../content/css/carousel.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUtf8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap CSS map",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/bootstrap/css/bootstrap.min.css.map$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUtf8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css.map")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
               new Route()
                {
                    Name="Bootstrap CSS",
                    UrlRegex = @"^/bootstrap/css/bootstrap.min.css$",
                    Method = RequestMethod.GET,
                    Callable = (request) =>
                    {
                        var response = new HttpResponse
                        {
                            ContentAsUtf8 = File.ReadAllText(@"../../content/bootstrap/css/bootstrap.min.css"),
                            StatusCode = ResponseStatusCode.Ok,

                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
               new Route()
                {
                    Name="JQuery JS",
                    UrlRegex = @"^/content/jquery/jquery-3.1.1.js$",
                    Method = RequestMethod.GET,
                    Callable = (request) =>
                    {
                        var response = new HttpResponse
                        {
                            ContentAsUtf8 = File.ReadAllText(@"../../content/jquery/jquery-3.1.1.js"),
                            StatusCode = ResponseStatusCode.Ok,

                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
               new Route()
               {
                   Name = "About us",
                   UrlRegex = @"^/about$",
                   Method = RequestMethod.GET,
                   Callable = request =>
                   {
                       var response = new HttpResponse()
                       {
                           ContentAsUtf8 = File.ReadAllText(@"../../content/about.html"),
                           StatusCode = ResponseStatusCode.Ok
                       };
                       return response;
                   }
               },
                new Route()
                {
                    Name = "img placeholder lib",
                    UrlRegex = @"^/content/imsky-holder-8220898/holder.min.js$",
                    Method = RequestMethod.GET,
                    Callable = request =>
                    {
                        var response = new HttpResponse()
                        {
                            ContentAsUtf8 = File.ReadAllText(@"../../content/imsky-holder-8220898/holder.min.js"),
                            StatusCode = ResponseStatusCode.Ok
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                 new Route()
               {
                   Name = "Products",
                   UrlRegex = @"^/products$",
                   Method = RequestMethod.GET,
                   Callable = request =>
                   {
                       var response = new HttpResponse()
                       {
                           ContentAsUtf8 = PageBuilder.BuildKnivesPage(),
                           StatusCode = ResponseStatusCode.Ok
                       };
                       return response;
                   }
               },
                  new Route()
               {
                   Name = "Contacts",
                   UrlRegex = @"^/contacts$",
                   Method = RequestMethod.GET,
                   Callable = request =>
                   {
                       var response = new HttpResponse()
                       {
                           ContentAsUtf8 = File.ReadAllText(@"../../content/contacts.html"),
                           StatusCode = ResponseStatusCode.Ok
                       };
                       return response;
                   }
               },
                   new Route()
               {
                   Name = "Contacts",
                   UrlRegex = @"^/contacts$",
                   Method = RequestMethod.POST,
                   Callable = request =>
                   {
                       Console.WriteLine( "COOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOONTENT"+request.Content);
                      
                       var response = new HttpResponse()
                       {
                           ContentAsUtf8 = File.ReadAllText(@"../../content/contacts.html"),
                           StatusCode = ResponseStatusCode.Ok
                       };
                       return response;
                   }
               },
            };

            HttpServer server = new HttpServer(8081, routes);
            server.Listen();

        }
    }
}