namespace SimpleHttpServer.Models
{
    using Enums;
    public class HttpRequest
    {
        public RequestMethod Method { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }

        public Header Header { get; set; }
        public HttpSession Session { get; set; }

        public HttpRequest()
        {
            this.Header = new Header(HeaderType.HttpRequest);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} HTTP/1.1\r\n{2}{3}",
                this.Method,
                this.Url,
                this.Header,
                this.Content);
        }
    }
}
