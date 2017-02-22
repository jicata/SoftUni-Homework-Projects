namespace SharpStore.Views.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Data;
    using MVCFramework.MVC.Interfaces.Generic;

    public class Products : IRenderable<List<Knife>>
    {
        public string Render()
        {
            string knivesTop = File.ReadAllText(@"../../content/products-top-dark.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(knivesTop);
            pageBuilder.Append(@"<div class=""row"">
        <form class=""form-inline col-md-4"" method=""GET"" action=""/home/products"" style=""margin-bottom: 1%"">
            <div class=""form-group"">
                <input type=""text"" class=""form-control"" placeholder=""Search"" name=""query"">
            </div>
            <button type=""submit"" class=""btn btn-default"" value=""Search"">Search</button>
        </form>
    </div>
    <div class=""row"">");
            foreach (var knife in Model)
            {
                pageBuilder.AppendLine($@"<div class=""card col-md-4"">
                <img class=""img-thumbnail"" src=""{knife.ImageUrl}"" width=""300"" height=""150"" alt=""{knife.Name}"">
                <div class=""card-block"">
                    <h4 class=""card-title"">{knife.Name}</h4>
                    <p class=""card-text"">{knife.Price}</p>
                    <form method=""POST"" action=""/home/products"" >
                       <input type=""submit"" class=""btn btn-primary"" value=""Buy Now"">                      
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

        public List<Knife> Model { get; set; }
        
    }
}
