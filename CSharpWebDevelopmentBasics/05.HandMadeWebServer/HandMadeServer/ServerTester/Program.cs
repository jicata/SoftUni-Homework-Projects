namespace ServerTester
{
    using System.Collections.Generic;
    using System.IO;
    using BasicHttpServer;
    using BasicHttpServer.Enums;
    using BasicHttpServer.Models;

    class Program
    {
        static void Main(string[] args)
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Hello Handler",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = request => new HttpResponse()
                    {
                        ContentAsUtf8 = "<h3>Hello from HttpServer :)</h3>",
                        ResponseCode = ResponseStatusCode.OK
                    }
                },
                new Route()
                {
                    Name="Upsa",
                    UrlRegex = @"^/calc$",
                    Method = RequestMethod.GET,
                    Callable = request => new HttpResponse()
                    {
                        ContentAsUtf8 = File.ReadAllText(@"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\03.Bootstrap\04.Calculator.html"),
                        ResponseCode = ResponseStatusCode.OK
                    }
                },
                new Route()
                {
                    Name="bootstrap.css",
                    UrlRegex = @"/bootstrap-3.3.7-dist/css/bootstrap.css",
                    Method = RequestMethod.GET,
                    Callable = request => new HttpResponse()
                    {
                        ContentAsUtf8 = File.ReadAllText(@"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\bootstrap-3.3.7-dist\css\bootstrap.min.css"),
                        ResponseCode = ResponseStatusCode.OK
                    }
                },
                 new Route()
                {
                    Name="style.css",
                    UrlRegex = @"/styles/style.css",
                    Method = RequestMethod.GET,
                    Callable = request => new HttpResponse()
                    {
                        ContentAsUtf8 = File.ReadAllText(@"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\03.Bootstrap\styles\style.css"),
                        ResponseCode = ResponseStatusCode.OK
                    }
                },
                   new Route()
                {
                    Name="Jquery.css",
                    UrlRegex = @"/jquery/jquery-3.1.1.js",
                    Method = RequestMethod.GET,
                    Callable = request => new HttpResponse()
                    {
                        ContentAsUtf8 = File.ReadAllText(@"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\jquery\jquery-3.1.1.js"),
                        ResponseCode = ResponseStatusCode.OK
                    }
                },

                     new Route()
                {
                    Name="bootstrapJquery.css",
                    UrlRegex = @"/bootstrap-3.3.7-dist/js/bootstrap.js",
                    Method = RequestMethod.GET,
                    Callable = request => new HttpResponse()
                    {
                        ContentAsUtf8 = File.ReadAllText(@"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\bootstrap-3.3.7-dist\js\bootstrap.min.js"),
                        ResponseCode = ResponseStatusCode.OK
                    }
                }
            };
            HttpServer server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}
