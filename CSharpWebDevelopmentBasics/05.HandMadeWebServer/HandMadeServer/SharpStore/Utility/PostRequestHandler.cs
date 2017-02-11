namespace SharpStore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using Data;
    using Models;

    public static class PostRequestHandler
    {
        private static IDictionary<string, string> PostParameters = new Dictionary<string, string>();
        public static void HandleContactsPost(string incomingRequestString)
        {
            PostParameters = DecodeParams(incomingRequestString);
            var context = new SharpStoreContext();
            Message message = new Message()
            {
                Sender = PostParameters["email"],
                Subject = PostParameters["subject"],
                Content = PostParameters["content"]
            };
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public static string HandleProductsPost(string incomingRequestString)
        {
            PostParameters = DecodeParams(incomingRequestString);
            return PostParameters["search"];
        }

        public static void HandleFolderCreation(string url, string incomingRequestString)
        {
            IDictionary<string, string> requestValues = DecodeFileParams(incomingRequestString);
            int counter = 0;
            string fileName = requestValues["fileName"];
            byte[] file = Encoding.ASCII.GetBytes(requestValues["file"]);
         
            File.WriteAllBytes("D:\\image.png", file);

            //if (incomingRequestString.Contains("folderName"))
            //{
            //   // IDictionary<string, string> requestValues = DecodeParams(incomingRequestString);
            //    string folderName = requestValues["folderName"];
            //    Directory.CreateDirectory(url + "/" + folderName);
            //    return;
            //}
            //else
            //{
                   
            //    string fileContent = incomingRequestString;
            //}
           
        }
        public static IDictionary<string, string> DecodeParams(string incomingRequestString)
        {
            Console.WriteLine(incomingRequestString);
            IDictionary<string, string> requestValues = new Dictionary<string, string>();
            string[] nameValuePairs = incomingRequestString.Split('&');

            foreach (var nameValuePair in nameValuePairs)
            {
                string[] nameValuePairParams = nameValuePair.Split('=');
                string paramName = WebUtility.UrlDecode(nameValuePairParams[0].Trim());
                string paramValue = WebUtility.UrlDecode(nameValuePairParams[1].Trim());

                requestValues.Add(paramName, paramValue);
            }

            return requestValues;
        }
        public static IDictionary<string, string> DecodeFileParams(string incomingRequestString)
        {
            Console.WriteLine(incomingRequestString);
            IDictionary<string, string> requestValues = new Dictionary<string, string>();
            Regex rgx = new Regex(@"filename=""(.*)""");
            StringReader reader = new StringReader(incomingRequestString);
            StringBuilder builder = new StringBuilder();
            int newlineCount = 0;
            reader.ReadLine();
            while (true)
            {
                 string readit = reader.ReadLine();
               
                if (readit.StartsWith("------W"))
                {
                    break;
                }
                if (newlineCount > 0)
                {
                    builder.AppendLine(readit);
                }
                if (string.IsNullOrEmpty(readit))
                {
                    newlineCount++;
                }

            }

            Match match = rgx.Match(incomingRequestString);
            requestValues["fileName"] = match.Groups[1].Value;
            requestValues["file"] = builder.ToString();
            return requestValues;
        }
    }
}
