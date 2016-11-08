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
                @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\11. JSONParsing\result.json";
            //01. Products In Range

            var productsInRange =
                context.Products.Where(p => p.Price >= 500 && p.Price <= 1000 && p.Buyer == null)
                    .Select(p => new {name = p.Name, price = p.Price, seller = p.Seller.FirstName + " " + p.Seller.LastName});

            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
            File.WriteAllText(destinationPath,json);







        }
    }
}
