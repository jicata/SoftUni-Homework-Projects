namespace Products.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using Data;
    using Models;
    using Models.Enums;

    class Program
    {
        static void Main()
        {
         
            Console.Write("Content-Type: text/html \n\n");
            var context = new ProductsContext();
            var orders = context.Orders.ToList();
             string postRequest = Environment.GetEnvironmentVariable("QUERY_STRING");
           // string postRequest = @"itemId=1&itemName=Harry+Potter+5+Game+&itemType=PC&paymentDate=29-01-2017&deliveryDate=01-02-2017&statusOptions=In+Call+To+Confirm";


            if (!string.IsNullOrWhiteSpace(postRequest))
            {
                
                string[] postItems = postRequest.Split('&');
                List<string> postValues = new List<string>();
                foreach (var postItem in postItems)
                {
                    string postValue = postItem.Split('=')[1];
                    postValues.Add(NormalizeString(postValue));
                }

                string orderId = postValues[0];
                string orderDeliveryDate = postValues[4];
                string orderStatus = (postValues[5]);
                var order = orders.FirstOrDefault(o => o.Id.ToString() == orderId);
                order.DeliveryDate = DateTime.Parse(orderDeliveryDate);
                order.Status.StatusType = (StatusType)Enum.Parse((typeof(StatusType)), orderStatus);
                context.SaveChanges();

            }
            List<string> tableRows = new List<string>();
            foreach (var order in orders)
            {
                int orderId = order.Id;
                string orderName = order.Name + " " + $"({InsertSpacesIntoCamelCaseString(order.ProductType.ToString())})";
                var orderPaymentDate = order.PaymentDate;
                var orderDeliveryDate = order.DeliveryDate.Value;
                var orderStatus = order.Status;
                string rowStatus = DetermineRowStatus(orderStatus);
                string tableRow = StaticTemplates.tableRowTemplate
                    .Replace(StaticTemplates.RowStatusPlaceholder, rowStatus)
                    .Replace(StaticTemplates.ItemIdPlaceholder, orderId.ToString())
                    .Replace(StaticTemplates.ItemNamePlaceholder, orderName)
                    .Replace(StaticTemplates.ItemPaymentDatePlaceholder, orderPaymentDate.Value.ToString("dd/MM/yyyy"))
                    .Replace(StaticTemplates.ItemDeliveryDatePlaceholder, orderDeliveryDate.ToString("dd/MM/yyyy"))
                    .Replace(StaticTemplates.ItemOrderStatusPlaceholder, InsertSpacesIntoCamelCaseString(orderStatus.StatusType.ToString()));
                tableRows.Add(tableRow);
            }
            string productsHtml = StaticTemplates.productsAndOrdersTemplate.Replace(StaticTemplates.TableRowTemplatePlaceholder,
                string.Join(Environment.NewLine, tableRows));
            Console.Write(productsHtml);

        }
        private static string InsertSpacesIntoCamelCaseString(string orderStatus)
        {
            Regex rgx = new Regex(@"([a-z][A-Z]){1}");
            var matchCol = rgx.Matches(orderStatus);
            foreach (Match match in matchCol)
            {
                orderStatus = orderStatus.Insert(orderStatus.IndexOf(match.ToString()) + 1, " ");
            }
            return orderStatus;
        }
        private static string NormalizeString(string postValue)
        {
            string decoded = WebUtility.UrlDecode(postValue);
            return decoded;
        }
        private static string DetermineRowStatus(Status orderStatus)
        {
            switch (orderStatus.StatusType)
            {
                case StatusType.Pending:
                    return "active";
                case StatusType.Declined:
                    return "danger";
                case StatusType.Delivered:
                    return "success";
                case StatusType.InCallToConfirm:
                    return "warning";
                default: throw new InvalidEnumArgumentException("Invalid status");
            }
        }
    }
}
