namespace SharpStore.Views.Admin
{
    using System.IO;
    using System.Text;
    using MVCFramework.MVC.Interfaces;
    public class Add : IRenderable
    {
        public string Render()
        {
            string knivesTop = File.ReadAllText(@"../../content/products-top-dark.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(knivesTop);

            pageBuilder.Append(
                $@"<div class=""row""><form action=""/admin/add"" method=""POST"" role=""FORM"" class=""form-vertical col-md-4"" >
                <div class=""form-group"">
                    <label class=""control-label"">Name</label>
                    <div class=""input-group input-group-lg"">
                        <input type=""text"" class=""form-control"" placeholder=""Name"" aria-describedby=""basic-addon1"" name=""Name"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label"">ImageUrl</label>
                    <div class=""input-group input-group-lg"">
                        <input type=""text"" class=""form-control"" placeholder=""Image URL"" aria-describedby=""basic-addon1"" name=""ImageUrl"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label"">Price</label>
                    <div class=""input-group input-group-lg"">
                        <input type=""text"" class=""form-control"" placeholder=""Price"" aria-describedby=""basic-addon1"" name=""Price"">
                    </div>
                </div>
                <div class=""form-group text-right"">
                    <input type=""submit"" class=""btn btn-success col-md-2"" value=""Add"">
                </div>
            </form>   ");

            pageBuilder.Append("</div>");
            pageBuilder.Append("</div>");
            string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
            pageBuilder.Append(pageBottom);
            return pageBuilder.ToString();
        }
    }
}
