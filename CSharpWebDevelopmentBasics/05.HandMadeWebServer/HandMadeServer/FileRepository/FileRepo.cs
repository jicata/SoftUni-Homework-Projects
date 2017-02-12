namespace FileRepository
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using BasicHttpServer;
    using BasicHttpServer.Enums;
    using BasicHttpServer.Models;
    using BasicHttpServer.Resources;
    using SharpStore.Utility;

    class FileRepo
    {
        private const string RepoPath =
            @"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\05.HandMadeWebServer\Repo";
        static void Main(string[] args)
        {
            
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Products",
                    UrlRegex = @"\/.+\..+",
                    Method = RequestMethod.GET,
                    Callable = request =>
                    {
                        string decodedUrl = WebUtility.UrlDecode(request.Url);
                        string normalizedUrl = RepoPath+decodedUrl.Replace('/', '\\');
                        var response = new HttpResponse()
                        {
                            Content = File.ReadAllBytes(normalizedUrl),
                            StatusCode = ResponseStatusCode.Ok
                        };
                        string fileType = decodedUrl.Substring(decodedUrl.LastIndexOf('.')+1);
                        response.Header.ContentType = MimeMapper.MapMimeToType(fileType);
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Products",
                    UrlRegex = @"^/",
                    Method = RequestMethod.GET,
                    Callable = request =>
                    {
                        return new HttpResponse()
                        {
                            ContentAsUtf8 = PageBuilder.BuildMyRepoPage(RepoPath+request.Url),
                            StatusCode = ResponseStatusCode.Ok
                        };
                    }
                },
                 new Route()
                {
                    Name = "Products",
                    UrlRegex = @"^/",
                    Method = RequestMethod.POST,
                    Callable = request =>
                    {
                    
                       byte[] bytes = PostRequestHandler.HandleFolderCreation(RepoPath+request.Url, request.Content);
                        MemoryStream ms = new MemoryStream(bytes);
                        Image image = Image.FromStream(ms,true,true);
                        image.Save(@"D:\\UPLOADEDIMAGE.png", ImageFormat.Png);
                        return new HttpResponse()
                        {
                            ContentAsUtf8 = PageBuilder.BuildMyRepoPage(RepoPath+request.Url),
                            StatusCode = ResponseStatusCode.Ok
                        };
                    }
                },

            };
            HttpServer server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}
