namespace SharpStore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Data;
    using Models;

    public static class PageBuilder
    {
        public static string BuildKnivesPage(string where=null)
        {
            string pageTop = File.ReadAllText(@"../../content/products-top.html");
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
    }
}
