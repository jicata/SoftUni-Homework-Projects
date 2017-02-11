namespace SharpStore.Utility
{
    using System.IO;
    using BasicHttpServer.Models;

    public class PageBuilderFactory
    {
        public string BuildThemedPage(CookieCollection cookies, string pageName)
        {
            string theme = "dark";
            if (cookies.ContainsKey("theme"))
            {
                theme = cookies["theme"].Value;
            }
            string themedPageName = pageName.Insert(pageName.IndexOf('.'), $"-{theme}");
            string themedPage = File.ReadAllText($"../../content/{themedPageName}");
            return themedPage;
        }
    }
}
