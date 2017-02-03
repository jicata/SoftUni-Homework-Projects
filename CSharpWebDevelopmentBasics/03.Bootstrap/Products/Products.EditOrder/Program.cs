namespace Products.EditOrder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using Client;

    class Program
    {
        static void Main()
        {
           
            Console.Write("Content-Type: text/html \n\n");
            string postStuff = Environment.GetEnvironmentVariable("QUERY_STRING");
            //string postStuff =
            //    @"itemId=1&itemName=Harry+Potter+5+Game+%28PC%29&itemPaymentDate=29-01-2017&itemDeliveryDate=01-02-2017&itemOrderStat=Pending";
            string[] postItems = postStuff.Split('&');
            List<string> postValues = new List<string>();
            foreach (var postItem in postItems)
            {
                string postValue = postItem.Split('=')[1];
                postValues.Add(NormalizeString(postValue));
            }
            string[] itemNameAndType = postValues[1].Split('(');
            string orderId = postValues[0];
            string orderName = itemNameAndType[0];
            string orderType = itemNameAndType[1].Replace(")", string.Empty);
            string orderPaymentDate = postValues[2];
            string orderDeliveryDate = postValues[3];
            string orderStatus = postValues[4];

            string editOrderHtml = StaticTemplates.editOrderTemplate
                .Replace(StaticTemplates.ItemIdPlaceholder, orderId)
                .Replace(StaticTemplates.ItemNamePlaceholder, orderName)
                .Replace(StaticTemplates.ItemTypePlaceholder, orderType)
                .Replace(StaticTemplates.ItemPaymentDatePlaceholder, orderPaymentDate)
                .Replace(StaticTemplates.ItemDeliveryDatePlaceholder, orderDeliveryDate);

            orderStatus = InsertSpacesIntoOrderStatus(orderStatus);
            editOrderHtml = editOrderHtml.Insert(editOrderHtml.LastIndexOf(orderStatus) - 1, "selected");
            Console.Write(editOrderHtml);
        }

        private static string InsertSpacesIntoOrderStatus(string orderStatus)
        {
            Regex rgx = new Regex(@"([a-z][A-Z]){1}");
            var matchCol = rgx.Matches(orderStatus);
            foreach (Match match in matchCol)
            {
                orderStatus = orderStatus.Insert(orderStatus.IndexOf(match.ToString())+1, " ");
            }
            return orderStatus;
        }
        private static string NormalizeString(string postValue)
        {
            string decoded = WebUtility.UrlDecode(postValue);
            return decoded;
        }
    }
}
