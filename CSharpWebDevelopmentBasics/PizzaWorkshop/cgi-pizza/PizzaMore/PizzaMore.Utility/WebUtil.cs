namespace PizzaMore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Contracts;
    using Data;
    using Models;

    public static class WebUtil
    {
        public static void PageNotAllowed()
        {
            //TODO: Add real(relative) path
            PrintFileContent("index.html");
        }

        public static void PrintFileContent(string filePath)
        {
            string html = File.ReadAllText(filePath, Encoding.Default);
            Console.Write(html);
        }

        public static Session GetSession()
        {
            ICookieCollection cookieCollection = GetCookies();
            Session session = null;
            var context = new PizzaMoreContext();
            if (cookieCollection.Count > 0 && cookieCollection.ContainsKey("sid"))
            {
                string sidValue = cookieCollection["sid"].Value;
                session = context.Sessions.FirstOrDefault(s => s.Id == int.Parse(sidValue));
            }
            return session;
        }

        public static ICookieCollection GetCookies()
        {
        
            ICookieCollection cookieCollection = new CookieCollection();
            string incomingCookies = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            if (!string.IsNullOrEmpty(incomingCookies))
            {
                ParseCookies(incomingCookies, cookieCollection);
            }
            return cookieCollection;
        }

        private static void ParseCookies(string incomingCookies, ICookieCollection cookieCollection)
        {
           
            string[] cookieNameValuePairs = incomingCookies.Split(';');
            foreach (var cookieNameValuePair in cookieNameValuePairs)
            {
                string[] cookieNameValuePairParams = cookieNameValuePair.Split('=');
                string cookieName = WebUtility.UrlDecode(cookieNameValuePairParams[0].Trim());
                string cookieValue = WebUtility.UrlDecode(cookieNameValuePairParams[1].Trim());
                Cookie cookie = new Cookie(cookieName, cookieValue);
                cookieCollection.AddCookie(cookie);
            }

        }

        public static bool IsGet()
        {
            string methodType = Environment.GetEnvironmentVariable("REQUEST_METHOD");
         
            if (methodType.ToLower() == "get")
            { 
                return true;
            }
            return false;
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string requestContent = Environment.GetEnvironmentVariable("QUERY_STRING");
            IDictionary<string, string> requestValues = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(requestContent))
            {
                requestValues = DecodeIncomingRequest(requestContent);
            }
            
            return requestValues;
        }
        public static IDictionary<string, string> RetrievePostParameters()
        {
            string requestContent = Console.ReadLine();
            Logger.Log($"REQUEST CONTENT: {requestContent} \n");
            IDictionary<string, string> requestValues = DecodeIncomingRequest(requestContent);
            return requestValues;
        }

        private static IDictionary<string, string> DecodeIncomingRequest(string requestContent)
        {
            IDictionary<string, string> requestValues = new Dictionary<string, string>();
            string[] nameValuePairs = requestContent.Split('&');
           
            foreach (var nameValuePair in nameValuePairs)
            {
                string[] nameValuePairParams = nameValuePair.Split('=');
                string paramName = WebUtility.UrlDecode(nameValuePairParams[0]);
                string paramValue = WebUtility.UrlDecode(nameValuePairParams[1]);
              
                requestValues.Add(paramName, paramValue);
            }

            return requestValues;
        }
    }
}
