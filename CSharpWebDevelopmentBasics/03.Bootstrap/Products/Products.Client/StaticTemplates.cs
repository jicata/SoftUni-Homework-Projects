namespace Products.Client
{
    public static class StaticTemplates
    {
        public const string RowStatusPlaceholder = "#rowStatus#";
        public const string ItemIdPlaceholder = "#itemId#";
        public const string ItemNamePlaceholder = "#itemName#";
        public const string ItemTypePlaceholder = "#itemType#";
        public const string ItemPaymentDatePlaceholder = "#itemPaymentDate#";
        public const string ItemDeliveryDatePlaceholder = "#itemDeliveryDate#";
        public const string ItemOrderStatusPlaceholder = "#itemOrderStatus#";
        public const string TableRowTemplatePlaceholder = "#tableRow#";

        public static string productsAndOrdersTemplate = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Products</title>
    <!--<link rel=""stylesheet"" href=""localhost//bootstrap-3.3.7-dist/css/bootstrap.css"">-->
    <link rel=""stylesheet"" href=""\bootstrap-3.3.7-dist\css\bootstrap.css"">
</head>
<body>
     <div class=""panel panel-default"">
        <!-- Default panel contents -->
        <div class=""panel-heading"">Products & Orders</div>
        <div class=""panel-body"">
            <p>Orders</p>
        </div>

        <!-- Table -->
        <table class=""table table-striped"">
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Payment Date</th>
                <th>Delivery Date</th>
                <th>Order Status</th>
                <th>Modify</th>
            </tr>
            #tableRow#
       </table>        
    </div>

<!--<script src=""localhost//jquery/jquery-3.1.1.js""></script>
<script src=""localhost//bootstrap-3.3.7-dist/js/bootstrap.js""></script>-->
<script src=""\bootstrap-3.3.7-dist\js\bootstrap.js""></script>
<script src=""\jquery\jquery-3.1.1.js""></script>
</body>
</html>";

        public static string tableRowTemplate = @"
<tr class=""#rowStatus#"">
    <form action=""http://localhost/cgi-bin/cgi-products/Products/Products.EditOrder/bin/Debug/Products.EditOrder.exe"" method=""GET"" name=""itemform#itemId#"">
            <td> <input type=""hidden"" name=""itemId"" value=""#itemId#"">#itemId#</td>                    
            <td><input type=""hidden"" name=""itemName"" value=""#itemName#"">#itemName#</td>
            <td><input type=""hidden"" name=""itemPaymentDate"" value=""#itemPaymentDate#"">#itemPaymentDate#</td>
            <td><input type=""hidden"" name=""itemDeliveryDate"" value=""#itemDeliveryDate#"">#itemDeliveryDate#</td>
            <td><input type=""hidden"" name=""itemOrderStat"" value=""#itemOrderStatus#"">#itemOrderStatus#</td>
            <td><a href=""javascript:document.itemform#itemId#.submit();"">Edit</a></td>
    </form>              
</tr>
";
        public static string editOrderTemplate = @"<html>
<head>
    <meta charset=""UTF-8"">
    <title>Edit Order</title>
    <link rel = ""stylesheet"" href= ""\bootstrap-3.3.7-dist\css\bootstrap.css"">
</head>
<body>
    <div class=""row"">
    <div class=""container-fluid col-lg-8"">
      
        <form class=""form-horizontal col-lg-12"" action=""http://localhost/cgi-bin/cgi-products/Products/Products.Client/bin/Debug/Products.Client.exe"" method=""GET"" id=""formDiv"">
              <label class=""control-label col-lg-1 block"">Edit order</label>
              <hr></hr>
                <div class=""form-group col-lg-12"">
                <label class=""control-label col-sm-2"" for=""itemId"">Item ID:</label>
                <div class=""col-sm-2"">
                    <input type = ""email"" class=""form-control"" id=""itemId"" name=""itemId"" value=""#itemId#"" readonly>
                </div>
            </div>
            <div class=""form-group col-lg-12"">
                <label class=""control-label col-sm-2"" for=""itemName"">Item Name:</label>
                <div class=""col-sm-2""> 
                    <input type = ""text"" class=""form-control"" id=""itemName"" name=""itemName"" value=""#itemName#"" readonly>
                </div>
            </div>
            <div class=""form-group col-lg-12"">
                <label class=""control-label col-sm-2"" for=""itemType"">Item Type:</label>
                <div class=""col-sm-2""> 
                    <input type = ""text"" class=""form-control"" id=""itemType"" name=""itemType"" value=""#itemType#"" readonly>
                </div>
            </div>
            <div class=""form-group col-lg-12"">
                <label class=""control-label col-sm-2"" for=""paymentDate"">Payment Date:</label>
                <div class=""col-sm-2""> 
                    <input type = ""text"" class=""form-control"" id=""paymentDate"" name=""paymentDate"" value=""#itemPaymentDate#"" readonly>
                </div>
            </div>
            <div class=""form-group col-lg-12"">
                <label class=""control-label col-sm-2"" for=""deliveryDate"">Delivery Date:</label>
                <div class=""col-sm-2""> 
                    <input type = ""text"" class=""form-control"" id=""deliveryDate"" name=""deliveryDate"" value=""#itemDeliveryDate#"" placeholder=""#itemDeliveryDate#"">
                </div>
            </div>
            <div class=""form-group col-lg-12"">              
                <div class=""dropdown"">
                     <label class=""control-label col-sm-2"" for=""dropdownMenu1"">Status:</label>
                     <div class=""col-sm-2"">
                        <select class=""form-control"" id=""dropdownMenu1"" name=""statusOptions"">
                            <option value = ""Pending"">Pending</option>
                            <option value=""Declined"">Declined</option>
                            <option value = ""Delivered"" >Delivered</option >
                            <option value=""InCallToConfirm"">In Call To Confirm</option>
                        </select>
                    </div>
                </div>
            </div>
           
            <div class=""form-group col-sm-12""> 
                <div class=""col-sm-offset-2 col-sm-6 text-center"">
                     <button type = ""submit"" class=""btn btn-default col-sm-2"">Edit</button>
                </div>
            </div>
        </form>
        <div class=""col-lg-12"">
               <button type = ""button"" class=""btn btn-secondary"">
                   <a href = ""http://localhost/cgi-bin/cgi-products/Products/Products.Client/bin/Debug/Products.Client.exe""> Back to orders</a>
                </button>
                </div>
    </div>
    </div>
    

<script src = ""\jquery\jquery-3.1.1.js"" ></ script >
    < script src= ""\bootstrap-3.3.7-dist\js\bootstrap.js"" ></ script >
    </ body >
    

    </ html > ";

    }
}
