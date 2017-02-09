using System;
using System.Text;

namespace PizzaMore.Utilities
{
    public class Header
    {
        public Header()
        {
            this.Type = "Content-type: text/html";
            this.Cookies = new CookieCollection();
        }

        public string Type { get; }

        public string Location { get; private set; }

        public ICookieCollection Cookies { get; private set; }

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine(this.Type);
            if (this.Cookies.Count > 0)
            {
                foreach (Cookie cookie in this.Cookies)
                {
                    header.AppendLine($"Set-Cookie: {cookie.ToString()}");
                }
            }

            if (this.Location != null)
            {
                header.AppendLine(this.Location);
            }

            header.AppendLine();
            header.AppendLine();

            return header.ToString();
        }
    }
}
