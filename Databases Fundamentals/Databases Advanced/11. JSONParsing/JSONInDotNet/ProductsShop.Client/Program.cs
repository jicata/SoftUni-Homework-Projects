namespace ProductsShop.Client
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Models;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Data.Migrations;

    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsShopContext, Configuration>());

            var context = new ProductsShopContext();
            string destinationPath =
                @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\11. JSONParsing\04.users-and-products.xml";
            // 01. Products In Range

            var productsInRange =
                context.Products.Where(p => p.Price >= 500 && p.Price <= 1000 && p.Buyer == null)
                    .Select(p => new { name = p.Name, price = p.Price, seller = p.Seller.FirstName + " " + p.Seller.LastName });

            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
            //File.WriteAllText(destinationPath,json);


            // 02. Successfully Sold Products  (json)

            var successfulProducts =
                context.Users
                    .Where(u => u.ProductsSold.Any())
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(
                        u =>
                            new
                            {
                                SellerFirstName = u.FirstName,
                                SellerLastName = u.LastName,
                                Products =
                                    u.ProductsSold.Where(p => p.Buyer != null)
                                        .Select(ps => new { ProductName = ps.Name, ProductPrice = ps.Price, BuyerFirstName = ps.Buyer.FirstName, BuyerLastName = ps.Buyer.LastName })
                            });

            var json2 = JsonConvert.SerializeObject(successfulProducts, Formatting.Indented);

            //File.WriteAllText(destinationPath, json2);

            // 03. Categories By Products Count (json)

            var catsByCount = context.Categories.OrderByDescending(c => c.Products.Count)
                .Select(
                    c =>
                        new
                        {
                            category = c.Name,
                            productsCount = c.Products.Count,
                            averagePrice = (decimal?)c.Products.Average(p => p.Price) ?? 0,
                            totalRevenue = (decimal?)c.Products.Sum(p => p.Price) ?? 0
                        });


           
            var json3 = JsonConvert.SerializeObject(catsByCount, Formatting.Indented);

           // File.WriteAllText(destinationPath, json3);

           // 04. Users And Products (xml)

            var usersAndProducts = context.Users.Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count).Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    Products = u.ProductsSold
                        .Select(p => new {ProductName = p.Name, ProductPrice = p.Price})
                });

            XDocument xmlDoc = new XDocument(new XElement("users", new XAttribute("count", usersAndProducts.Count())));

            foreach (var userAndProducts in usersAndProducts)
            {
                XElement element = new XElement("user");
                if (!string.IsNullOrEmpty(userAndProducts.FirstName) && userAndProducts.Age != 0)
                {
                    element.Add(new XAttribute("first-name", userAndProducts.FirstName));
                    element.Add(new XAttribute("last-name", userAndProducts.LastName));
                    element.Add(new XAttribute("age", userAndProducts.Age));
                }
                else
                {
                    element.Add(new XAttribute("last-name", userAndProducts.LastName));
                }
                element.Add(new XElement("sold-products", new XAttribute("count", userAndProducts.Products.Count()),
                    from product in userAndProducts.Products select new XElement("product",
                        new XAttribute("name", product.ProductName),
                        new XAttribute("price", product.ProductPrice))));
               
                xmlDoc.Root.Add(element);
            }
            xmlDoc.Save(destinationPath);



        }
    }
}
