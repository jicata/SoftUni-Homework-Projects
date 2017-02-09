namespace BasicHttpServer.Models
{
    using System;
    using System.Text;
    using Enums;

    public class HttpResponse
    {
        public HttpResponse()
        {
            this.Header = new Header(HeaderType.HttpResponse);
        }

        public ResponseStatusCode ResponseCode { get; set; }

        public string StatusMessage => $"{this.ResponseCode}";

        public Header Header { get; set; }

        public byte[] Content { get; set; }

        public string ContentAsUtf8
        {
            set
            {
                byte[] contentAsBytes = Encoding.ASCII.GetBytes(value);
                this.Content = contentAsBytes;
            }
        }

        public override string ToString()
        {
            StringBuilder httpResponse = new StringBuilder();
            httpResponse.AppendLine("HTTP/1.0");
            httpResponse.AppendLine($"{(int)this.ResponseCode} {this.ResponseCode}");
            httpResponse.AppendLine(this.Header.ToString());
            return httpResponse.ToString();

        }
    }
}
