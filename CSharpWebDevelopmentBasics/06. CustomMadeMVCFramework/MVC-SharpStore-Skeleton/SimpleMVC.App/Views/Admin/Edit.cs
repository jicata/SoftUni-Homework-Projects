namespace SharpStore.Views.Admin
{
    using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
    using System.IO;
    using System.Text;
    using BindingModels;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;
    public class Edit : IRenderable<KnifeViewModel>
    {
        public string Render()
        {
            string knivesTop = File.ReadAllText(@"../../content/products-top-dark.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(knivesTop);

            pageBuilder.Append(
                $@"<div class=""row""><form action=""/admin/edit"" method=""POST"" role=""FORM"" class=""form-vertical col-md-4"" >
             <img class=""img-thumbnail"" src=""{Model.ImageUrl}"" width=""300"" height=""150"" alt=""{Model.Name}"">
                <div class=""form-group"">
                    <label class=""control-label"">Name</label>
                    <div class=""input-group input-group-lg"">
                        <input type=""text"" class=""form-control"" value=""{Model.Name}"" aria-describedby=""basic-addon1"" name=""Name"" disabled>
                        <input type=""hidden"" class=""form-control"" value=""{Model.Name}"" aria-describedby=""basic-addon1"" name=""Name"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label"">ImageUrl</label>
                    <div class=""input-group input-group-lg"">
                        <input type=""text"" class=""form-control"" value=""{Model.ImageUrl}"" aria-describedby=""basic-addon1"" name=""ImageUrl"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label"">Price</label>
                    <div class=""input-group input-group-lg"">
                        <input type=""text"" class=""form-control"" value=""{Model.Price}"" aria-describedby=""basic-addon1"" name=""Price"">
                    </div>
                </div>
                <div class=""form-group text-right"">
                    <input type=""submit"" class=""btn btn-warning col-md-2"" value=""Edit"">
                </div>
            </form>   ");

            pageBuilder.Append("</div>");
            pageBuilder.Append("</div>");
            string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
            pageBuilder.Append(pageBottom);
            return pageBuilder.ToString();
        }

        public KnifeViewModel Model { get; set; }
    }
}
