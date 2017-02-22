namespace SharpStore.Views.Admin
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;
    public class Orders : IRenderable<List<BuyerViewModel>>
    {
        public string Render()
        {
            string messagesTop = File.ReadAllText(@"../../content/products-top-dark.html");
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.Append(messagesTop);
            pageBuilder.Append("<div class=\"row\" ");

            pageBuilder.Append(@"<div class=""panel-body"">
        </div>

        <!-- Table -->
        <table class=""table table-striped"">
            <tr>
                <th>Buyer's Name</th>
                <th>Buyer's Address</th>
                <th>Order Status</th>
                <th>Modify</th>
            </tr>");
            Dictionary<string, string> rowClassByDeliveryStatus = new Dictionary<string, string>()
            {
                {"Delivered", "success"},
                {"Pending", "warning"},
                {"Declined", "danger"}
            };
            foreach (var buyerViewModel in Model)
            {
                string lineToAdd = ($@" <tr class=""{rowClassByDeliveryStatus[buyerViewModel.DeliveryStatus]}"">
                <form action=""/admin/orders"" method=""POST"" name=""itemform"">
                     <td><input type=""hidden"" name=""Name"" value=""{buyerViewModel.Name}"">{buyerViewModel.Name}</td>                    
                     <td><input type=""hidden"" name=""Address"" value=""{buyerViewModel.Address}"">{buyerViewModel.Address}</td>
                     <td>
                        <select class=""selectpicker"" name=""DeliveryStatus"">
                          <option value=""Pending"" >Pending</option>
                          <option value=""Delivered"" >Delivered</option>
                          <option value=""Declined"" >Declined</option>
                        </select>
                         </td>
                        <td><button type=""submit"" class=""btn btn-success"" value=""Edit"">Edit</td>
                    </form> 
                </tr>
                 ");
                lineToAdd = lineToAdd.Insert(lineToAdd.LastIndexOf(buyerViewModel.DeliveryStatus)-1,
                    "selected");
                pageBuilder.Append(lineToAdd);
            }


            pageBuilder.Append("</table></div>");
            pageBuilder.Append("</div>");
            string pageBottom = File.ReadAllText(@"../../content/products-bottom.html");
            pageBuilder.Append(pageBottom);
            return pageBuilder.ToString();
        }

        public List<BuyerViewModel> Model { get; set; }
    }
}
