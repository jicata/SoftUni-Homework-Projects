using BasicHttpServer.Models;
using System.Collections.Generic;
using System.IO;

namespace SharpStore
{
    using BasicHttpServer;
    using BasicHttpServer.Enums;
    using Utility;

    class SharpStore
    {
        static void Main()
        {
            PageBuilderFactory factory = new PageBuilderFactory();
            var routes = new List<Route>()
            {
                  new Route()
               {
                   Name = "Products",
                   UrlRegex = @"^/products.html$",
                   Method = RequestMethod.GET,
                   Callable = request =>
                   {
                       var response = new HttpResponse()
                       {
                           ContentAsUtf8 = PageBuilder.BuildKnivesPage(factory,request.Header.CookieCollection),
                           StatusCode = ResponseStatusCode.Ok
                       };
                       return response;
                   }
               },

                new Route()
                {
                    Name = "Home Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = "^\\/.+\\.html",
                    Callable = (request) =>
                    {
                        string url = string.Empty;
                        CookieCollection cookies = UrlHandler.HandleIncomingQueryParameters(request.Url);

                        foreach (var cookie in cookies)
                        {
                            request.Header.CookieCollection.AddCookie(cookie);
                        }
                        if (!request.Header.CookieCollection.ContainsKey("theme"))
                        {
                            request.Header.CookieCollection.AddCookie(new Cookie("theme", "dark"));
                        }
                        if (cookies.Count > 0)
                        {
                            url = request.Url.Substring(1, request.Url.IndexOf('?') - 1);
                        }
                        else
                        {
                            url = request.Url;
                        }

                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUtf8 = factory.BuildThemedPage(request.Header.CookieCollection, url)

                        };
                        response.Header.CookieCollection.AddCookie(request.Header.CookieCollection["theme"]);
                        return response;

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
                   Name = "Contacts POST",
                   UrlRegex = @"^/contacts$",
                   Method = RequestMethod.POST,

                   Callable = request =>
                   {
                       PostRequestHandler.HandleContactsPost(request.Content);
                       var response = new HttpResponse()
                       {
                           ContentAsUtf8 = factory.BuildThemedPage(request.Header.CookieCollection, request.Url),
                           StatusCode = ResponseStatusCode.Ok
                       };
                       return response;
                   }
               },
                     new Route()
               {
                   Name = "Products",
                   UrlRegex = @"^/products$",
                   Method = RequestMethod.POST,
                   Callable = request =>
                   {
                       string where = PostRequestHandler.HandleProductsPost(request.Content);
                       var response = new HttpResponse()
                       {

                           ContentAsUtf8 = PageBuilder.BuildKnivesPage(factory,request.Header.CookieCollection,where),
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