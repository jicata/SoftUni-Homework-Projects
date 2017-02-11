namespace SharpStore.Utility
{
    using Cookie = BasicHttpServer.Models.Cookie;
    using CookieCollection = BasicHttpServer.Models.CookieCollection;

    public static class UrlHandler
    {

        public static CookieCollection HandleIncomingQueryParameters(string url)
        {
           
            CookieCollection cookies = new CookieCollection();
            if(!url.Contains("?"))
            {
                return cookies;
            }
            string urlParams = url.Substring(url.IndexOf('?')+1);
            string[] parameterKeyValues = urlParams.Split('=');
            for (int i = 0; i < parameterKeyValues.Length; i+=2)
            {
                Cookie cookie = new Cookie(parameterKeyValues[i], parameterKeyValues[i + 1]);
               cookies.AddCookie(cookie);
            }
            return cookies; 
        }
    }
}
