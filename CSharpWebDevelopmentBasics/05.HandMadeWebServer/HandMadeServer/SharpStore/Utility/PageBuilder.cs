namespace SharpStore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Text.RegularExpressions;
    using BasicHttpServer.Models;
    using Data;
    using Models;

    public static class PageBuilder
    {

        public static string BuildKnivesPage(PageBuilderFactory factory, CookieCollection cookies, string where = null)
        {
            string pageTop = factory.BuildThemedPage(cookies, "products-top.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(pageTop);

            var context = new SharpStoreContext();
            List<Knife> knives = new List<Knife>();
            if (string.IsNullOrEmpty(where))
            {
                knives = context.Knives.ToList();
            }
            else
            {
                knives = context.Knives.Where(k => k.Name.Contains(where)).ToList();
            }
            foreach (var knife in knives)
            {
                string base64 = Convert.ToBase64String(File.ReadAllBytes(knife.ImageUrl));
                pageBuilder.AppendLine($@"<div class=""card col-md-4"">
                <img class=""img-thumbnail"" src=""data:image;base64,{base64}"" width=""300"" height=""150"" alt=""{knife.Name}"">
                <div class=""card-block"">
                    <h4 class=""card-title"">{knife.Name}</h4>
                    <p class=""card-text"">{knife.Price}</p>
                    <form method=""POST"">
                        <input type=""submit"" class=""btn btn-primary"" value=""Buy Now"">
                    </form>
                </div>
            </div>");
            }

            string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
            pageBuilder.Append(pageBottom);
            return pageBuilder.ToString();
        }

        public static string BuildMyRepoPage(string url)
        {
            List<string> dirs = Directory.EnumerateDirectories(url).ToList();
            List<string> files = Directory.EnumerateFiles(url).ToList();
            List<string> items = dirs.Concat(files).ToList();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(
                "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n   " +
                " <meta charset=\"UTF-8\">\r\n    " +
                "<title>Repo</title>\r\n</head>\r\n<body>\r\n  " +
                $"  <h1>Directory: {url.Substring(url.IndexOf("Repo") + 4)} </h1>\r\n    <ul>");

            foreach (var item in items)
            {
                string itemName = item.Replace("/", "\\");
                itemName = itemName.Substring(itemName.LastIndexOf('\\') + 1);
                string path = item.Substring(item.IndexOf("Repo") + 5);

                builder.AppendLine($@"<li><a href=""{path}"">{itemName}</a></li>");
            }

            builder.AppendLine(" </ul>" +
                               "<form method=\"POST\">\r\n   " +
                               " <input type=\"text\" name =\"folderName\">\r\n   " +
                               " <input type=\"submit\" value=\"Create new folder\">\r\n</form>" +
                               "<form method=\"POST\" enctype=\"multipart/form-data\">\r\n       " +
                               " <input type=\"file\" name=\"fileToUpload\" accept=\"image/*\">\r\n     " +
                               "   <input type=\"submit\">\r\n    </form>"+
                               "</body>" +
                               "</html>");
            return builder.ToString();
        }
    }
}
