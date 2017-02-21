namespace SharpStore.Views.Admin
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using BindingModels;
    using MVCFramework.MVC.Interfaces.Generic;

    public class Products : IRenderable<List<KnifeBindingModel>>
    {
        public string Render()
        {
            string knivesTop = File.ReadAllText(@"../../content/products-top-dark.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(knivesTop);
            foreach (var knife in Model)
            {
                pageBuilder.AppendLine($@"<div class=""card col-md-4"">
                <img class=""img-thumbnail"" src=""{knife.ImageUrl}"" width=""300"" height=""150"" alt=""{knife.Name}"">
                <div class=""card-block"">
                    <h4 class=""card-title"">{knife.Name}</h4>
                    <form method=""POST"" action=""/home/products"" >
                       <input type=""submit"" class=""btn btn-danger"" value=""Delete"">
                    </form>
                </div>
            </div>");
            }

            string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
            pageBuilder.Append(pageBottom);
            return pageBuilder.ToString();
        }

        public List<KnifeBindingModel> Model { get; set; }
    }
}
