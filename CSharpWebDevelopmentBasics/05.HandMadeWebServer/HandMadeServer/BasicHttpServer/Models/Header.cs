namespace BasicHttpServer.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;

    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "Content-Type: text/html";
            this.OtherParameters = new Dictionary<string, string>();
            this.CookieCollection = new CookieCollection();
        }

        public HeaderType Type { get; set; }

        public string ContentType { get; set; }

        public string ContentLength { get; set; }

        public Dictionary<string,string> OtherParameters { get; set; }

        public CookieCollection CookieCollection { get; private set; }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine(this.ContentType);
            if (!string.IsNullOrEmpty(ContentLength))
            {
                header.AppendLine($"Content-Length: {ContentLength}");
            }
            if (this.CookieCollection.Any())
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    header.AppendLine("Cookie: " + this.CookieCollection.ToString());
                }
                else
                {
                    foreach (Cookie cookie in CookieCollection)
                    {
                        header.AppendLine($"Set-CookieL: {cookie}");
                    }
                }
            }
            
            foreach (var otherParameter in OtherParameters)
            {
                header.AppendLine($"{otherParameter.Key}: {otherParameter.Value}");
            }
            header.AppendLine();
            header.AppendLine();
            return header.ToString();
        }
    }
}
