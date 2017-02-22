namespace SharpStore.Views.Admin
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using BindingModels;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;

    public class Products : IRenderable<List<KnifeViewModel>>
    {
        public string Render()
        {
            string knivesTop = File.ReadAllText(@"../../content/products-top-dark.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(knivesTop);
            pageBuilder.Append(@"<div class=""row"">
       
            <div class=""form-group col-md-4"">
                <a href=""/admin/add""><button class=""btn btn-success"" value=""Add"">Add knife</button></a>
            </div>          

    </div>
    <div class=""row"">");
            foreach (var knife in Model)
            {
                pageBuilder.AppendLine($@"<div class=""card col-md-4"">
                <img class=""img-thumbnail"" src=""{knife.ImageUrl}"" width=""300"" height=""150"" alt=""{knife.Name}"">
                <div class=""card-block"">
                    <h4 class=""card-title"">{knife.Name}</h4>
                    <p class=""card-text"">{knife.Price}</p>
                    <form method=""POST"" action=""/admin/products"" >
                       <input type=""submit"" class=""btn btn-danger"" value=""Delete"">
                       <input type=""hidden"" name=""Name"" value=""{knife.Name}"">
                    </form>
                    <form method=""GET"" action=""/admin/edit"" >
                        <input type=""submit"" class=""btn btn-warning"" value=""Edit"">
                        <input type=""hidden"" name=""knifeUrl"" value=""{knife.ImageUrl}"">
                    </form>
                </div>
            </div>");
            }
            pageBuilder.Append("</div>");
            pageBuilder.Append("</div>");
            string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
            pageBuilder.Append(pageBottom);
            return pageBuilder.ToString();
        }

        public List<KnifeViewModel> Model { get; set; }
    }
}
