using SimpleHttpServer.Enums;
using System;
using System.Text;

// NOTE: two consequences of this simplified response model are:
//
//      (a) it's not possible to send 8-bit clean responses (like file content)
//      (b) it's 
//       must be loaded into memory in the the Content property. If you want to send large files,
//       this has to be reworked so a handler can write to the output stream instead. 

namespace SimpleHttpServer.Models
{


    public class HttpResponse
    {
        public ResponseStatusCode StatusCode { get; set; }
        public string StatusMessage
        {
            get
            {
                return Enum.GetName(typeof(ResponseStatusCode), this.StatusCode);
            }
        }
        public byte[] Content { get; set; }

        public Header Header { get; set; }
        public string ContentAsUTF8
        {
            set
            {
                this.Content = Encoding.UTF8.GetBytes(value);
            }
        }

        public HttpResponse()
        {
            this.Header = new Header(HeaderType.HttpResponse);
            this.Content = new byte[] { };
        }
        public override string ToString()
        {
            return string.Format("HTTP/1.1 {0} {1}\r\n{2}",
                (int)this.StatusCode,
                this.StatusMessage,
                this.Header);
        }
    }
}
