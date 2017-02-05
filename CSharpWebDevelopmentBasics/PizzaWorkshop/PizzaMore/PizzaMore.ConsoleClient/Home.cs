namespace PizzaMore.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Utility;
    using Utility.Contracts;

    public class Home
    {
        public static IDictionary<string, string> RequestParameters;
        public static Session Session;
        public static Header Header;
        public static string Language;

        public Home()
        {
            Session = new Session();
            Header = new Header();
            RequestParameters = new Dictionary<string, string>();
        }

        public void AddDefaultLanguageCookie()
        {
            var cookies = WebUtil.GetCookies();
            if (cookies.ContainsKey("lang"))
            {

                Language = cookies["lang"].Value;
                Logger.Log("contains");
            }
            else
            {
                Cookie cookie = new Cookie("lang", "EN");
                cookies.AddCookie(cookie);
                Header.AddCookie(cookie);
                Language = "EN";
            }
            this.HandleRequest();
        }

        public void HandleRequest()
        {

            if (WebUtil.IsGet())
            {
   
                RequestParameters = WebUtil.RetrieveGetParameters();
                Language = Header.CookieCollection["lang"].Value;
                Logger.Log(Header.CookieCollection.ContainsKey("lang").ToString());
            }
            else
            {

                RequestParameters = WebUtil.RetrievePostParameters();
                Cookie cookie = new Cookie("lang", RequestParameters["language"]);
                Header.CookieCollection["lang"] = cookie;
                Language = RequestParameters["language"];
            }
        }

        public void ShowPage()
        {
            try
            {
                Logger.Log(Header.ToString());
            }
            catch (Exception e)
            {
               Logger.Log(e.Message);
            }
          

            Console.Write(Header.ToString());

            this.ServeHtmlPage(Language);
        }

        private void ServeHtmlPage(string language)
        {
            switch (language)
            {
                case "EN":
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaHome.html");
                    break;
                case "BG":
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaHomeBG.html");
                    break;
                default: throw new InvalidOperationException("Unrecognized language");
            }
        }
    }
}
