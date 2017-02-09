namespace BasicHttpServer.Resources
{
    using System.IO;
    using Enums;
    using Models;

    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string html500 = File.ReadAllText(
                @"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\05.HandMadeWebServer\HandMadeServer\500.html");
            var response = new HttpResponse();
            response.ContentAsUtf8 = html500;
            response.ResponseCode = ResponseStatusCode.ServerError;
            return response;
        }
        public static HttpResponse NotFound()
        {
            string html404 = File.ReadAllText(
                @"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\05.HandMadeWebServer\HandMadeServer\404.html");
            var response = new HttpResponse();
            response.ContentAsUtf8 = html404;
            response.ResponseCode = ResponseStatusCode.NotFound;
            return response;
        }

        public static HttpResponse MethodNotAllowed()
        {
            string html405 = File.ReadAllText(
                @"C:\Users\Maika\Documents\Programming\Homework\CSharpWebDevelopmentBasics\05.HandMadeWebServer\HandMadeServer\405.html");
            var response = new HttpResponse();
            response.ContentAsUtf8 = html405;
            response.ResponseCode = ResponseStatusCode.MethodNotAllowed;
            return response;    
        }
    }
}
