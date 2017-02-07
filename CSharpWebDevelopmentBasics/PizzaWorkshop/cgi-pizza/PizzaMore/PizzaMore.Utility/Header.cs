namespace PizzaMore.Utility
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Header
    {
        public Header()
        {
            this.Type = Constants.ContentType;
            this.CookieCollection = new CookieCollection();
        }

        public string Type { get; set; }

        public string Location { get; set; }

        public ICookieCollection CookieCollection { get; set; }

        public void AddLocation(string location)
        {
            this.Location = location;
        }

        public void AddCookie(Cookie cookie)
        {
            this.CookieCollection.AddCookie(cookie);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.Type);
            if (this.CookieCollection.Count > 0)
            {
                
                foreach (KeyValuePair<string, Cookie> cookie in this.CookieCollection)
                {
                    //<meta http-equiv="set-cookie" content="HolidayGlaze=Good%20yummies;">
                    builder.AppendLine($@"Set-Cookie: {cookie.Value.Name}={cookie.Value.Value}");
           
                        
                }
           
            }
            if (!string.IsNullOrEmpty(this.Location))
            {   
                builder.AppendLine(this.Location);
            }
            for (int i = 0; i < 2; i++)
            {
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
