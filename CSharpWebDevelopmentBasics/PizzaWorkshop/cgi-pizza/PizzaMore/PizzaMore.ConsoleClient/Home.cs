namespace PizzaMore.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Models;
    using Utility;

    public class Home
    {
        public static IDictionary<string, string> RequestParameters;
        public static Session Session;
        public static Header Header = new Header();
        public static string Language;

        static void Main(string[] args)
        {
            AddDefaultLanguageCookie();
            foreach (KeyValuePair<string, Cookie> cookie1 in Header.CookieCollection)
            {
                Logger.Log("COOKIE IN HEADER FROM HOME: " + cookie1.Value.Name + " " + cookie1.Value.Value + "\n");
            }
            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
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
        public static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
                ShowPage();
            }
        }
        public static void ShowPage()
        {

           // Logger.Log(Header.ToString());
            Console.Write(Header.ToString());
            Logger.Log("SHOW PAGE \n");
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
