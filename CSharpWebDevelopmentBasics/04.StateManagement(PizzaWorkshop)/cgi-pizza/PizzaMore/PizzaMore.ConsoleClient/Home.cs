namespace PizzaMore.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;
    using Models;
    using Utility;
    using Utility.Contracts;

    public class Home
    {
        public static IDictionary<string, string> RequestParameters;
        public static Session Session;
        public static Header Header = new Header();
        public static string Language;

        static void Main(string[] args)
        {
            AddDefaultLanguageCookie();

            foreach (KeyValuePair<string,Cookie> keyValuePair in WebUtil.GetCookies())
            {
                Logger.Log($"{keyValuePair.Value}\n" );
            }
            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;

            }
            else
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Cookie cookie = new Cookie("lang", RequestParameters["language"]);
                Header.AddCookie(cookie);
                Language = RequestParameters["language"];
            }

            ShowPage();


        }

        private static void TryLogOut()
        {

            try
            {
                if (RequestParameters.ContainsKey("logout") && RequestParameters["logout"]=="true")
                {
                    var cookieValue = int.Parse(WebUtil.GetCookies()["sid"].Value);
                    var cookieName = WebUtil.GetCookies()["sid"].Name;


                    var context = new PizzaMoreContext();
                    var session =
                        context.Sessions.FirstOrDefault(s => s.Id == cookieValue);
                    if (Header.CookieCollection.ContainsKey("sid"))
                    {
                        Header.CookieCollection.RemoveCookie(cookieName);
                    }
              
                    context.Sessions.Remove(session);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
        }

        public static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
              //  ShowPage();
            }
        }
        public static void ShowPage()
        {

            // Logger.Log(Header.ToString());
            Console.Write(Header.ToString());
            ServeHtmlPage(Language);
        }
        private static void ServeHtmlPage(string language)
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
