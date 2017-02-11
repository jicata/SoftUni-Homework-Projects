namespace BasicHttpServer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using Enums;
    using Models;
    using Resources;

    public class HttpProcessor
    {
        private HttpRequest request;
        private HttpResponse response;

        public HttpProcessor(IEnumerable<Route> routes)
        {
            this.Routes = routes;
        }

        public IEnumerable<Route> Routes { get; private set; }

        public HttpRequest Request
        {
            get
            {
                return request;
            }

            set
            {
                request = value;
            }
        }

        public HttpResponse Response
        {
            get
            {
                return response;
            }

            set
            {
                response = value;
            }
        }

        public void HandleClient(TcpClient client)
        {
            var networkStream = client.GetStream();
            using (networkStream)
            {
                this.Request = this.GetRequest(networkStream);
                this.Response = this.RouteRequest();
                StreamUtils.WriteResponse(networkStream, this.Response);

            }
        }

        private HttpResponse RouteRequest()
        {
            var routes = this.Routes
                .Where(x => Regex.Match(Request.Url, x.UrlRegex).Success)
                .ToList();

           
            if (!routes.Any())
                return HttpResponseBuilder.NotFound();


            var route = routes.FirstOrDefault(x => x.Method == Request.Method);

            if (route == null)
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.MethodNotAllowed
                };


            // trigger the route handler...
            try
            {
                return route.Callable(Request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return HttpResponseBuilder.InternalServerError();
            }

        }

        private HttpRequest GetRequest(NetworkStream stream)
        {
            string[] firstLineParams = StreamUtils.ReadLine(stream).Split(' ');
            Console.WriteLine(string.Join(" ", firstLineParams));
            
            RequestMethod method = (RequestMethod)Enum.Parse(typeof(RequestMethod), firstLineParams[0]);
            string url = firstLineParams[1];
            Header header = new Header(HeaderType.HttpRequest);
            string line;
            while (!string.IsNullOrEmpty(line = StreamUtils.ReadLine(stream)))
            {
                string[] requestParams = line.Split(new char[] {':'},2);
                string paramName = requestParams[0];
                string paramValue = requestParams[1];
                if (paramName == "Cookie")
                {
                    string[] cookieParams = paramValue.Split('=');
                    string cookieName = cookieParams[0];
                    if (cookieName == "theme")
                    {
                        File.AppendAllText("D:\\Logged.txt", $"{cookieName}  {cookieParams[1]}");
                    }
                    string cookieValue = cookieParams[1];
                    var cookie = new Cookie(cookieName, cookieValue);
                    header.CookieCollection.AddCookie(cookie);
                }
                else if (paramName == "Content-Length")
                {
                    header.ContentLength = paramValue;
                }
                else
                {
                    header.OtherParameters.Add(paramName, paramValue);
                }

            }
            string content = null;
            if (!string.IsNullOrEmpty(header.ContentLength))
            {
                int totalBytes = Convert.ToInt32(header.ContentLength);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];
                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = stream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes,totalBytes-bytesLeft);
                    bytesLeft -= n;
                }
                content = Encoding.ASCII.GetString(bytes);
            }
            var request = new HttpRequest()
            {
                Method = method,
                Url = url,
                Header = header,
                Content = content
            };
            return request;
        }
    }
}
