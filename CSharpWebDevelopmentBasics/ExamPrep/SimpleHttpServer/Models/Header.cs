using SimpleHttpServer.Enums;
using System.Collections.Generic;
using System.Text;

namespace SimpleHttpServer.Models
{
    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }
        public HeaderType Type { get; set; }
        public string ContentType { get; set; }
        public string Location { get; set; }
        public string ContentLength { get; set; }
        public Dictionary<string, string> OtherParameters { get; set; }
        public CookieCollection Cookies { get; private set; }


        public void AddCookie(Cookie cookie)
        {
            this.Cookies.Add(cookie);
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine("Content-type: " + this.ContentType);
            if (this.Location != null)
            {
                header.AppendLine("Location: " + this.Location);
            }
            
            if (this.Cookies.Count > 0)
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    header.AppendLine("Cookie: " + this.Cookies.ToString());
                }
                else if (this.Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine("Set-Cookie: " + cookie);
                    }
                }
            }

            if (this.ContentLength != null)
            {
                header.AppendLine("Content-Length: " + this.ContentLength);
            }

            foreach (var other in OtherParameters)
            {
                header.AppendLine($"{other.Key}: {other.Value}");
            }
            header.AppendLine();

            return header.ToString();
        }
    }
}
