namespace ProductShop.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using ProductsShop.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ProductsShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsShopContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            try
            {
                this.SeedUsers(context);
                this.SeedCategories(context);
                this.SeedProducts(context);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var dbEntityValidationResult in e.EntityValidationErrors)
                {
                    foreach (var dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError);
                    }
                }
            }
           
        }


        private void SeedUsers(ProductsShopContext context)
        {
            string path =
                @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\11. JSONParsing\users.xml";
            XDocument doc = XDocument.Load(path);

            var root = doc.Root;
            foreach (XElement descendant in root.Descendants())
            {
                User user = new User();
                foreach (XAttribute xAttribute in descendant.Attributes())
                {
                    if (xAttribute.Name == "first-name")
                    {
                        user.FirstName = xAttribute.Value;
                    }
                    else if (xAttribute.Name == "last-name")
                    {
                        user.LastName = xAttribute.Value;
                    }
                    else if (xAttribute.Name == "age")
                    {
                        user.Age = int.Parse(xAttribute.Value);
                    }

                }
                context.Users.Add(user);
            }
            context.SaveChanges();
        }

        private void SeedCategories(ProductsShopContext context)
        {
            string categoriesJsonPath =
               @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\11. JSONParsing\categories.json";
            string jsonString = File.ReadAllText(categoriesJsonPath);

            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(jsonString);

            categories.ForEach(x=>context.Categories.Add(x));
            context.SaveChanges();
        }

        private void SeedProducts(ProductsShopContext context)
        {
            string path =
                @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\11. JSONParsing\products.json";

            string jsonString = File.ReadAllText(path);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonString);

            int usersCount = context.Users.Count();
            int categoriesCount = context.Categories.Count();
            Random rand = new Random(DateTime.Now.Millisecond);
            foreach (var product in products)
            {
                // random id for Buyer
                int randomUserId = rand.Next(1, usersCount);
                User randUserBuyer = context.Users.Find(randomUserId);
                // random id for Seller
                randomUserId = rand.Next(1, usersCount);
                User randUserSeller = context.Users.Find(randomUserId);
                // ensure are not the same person
                while (randUserSeller.LastName == randUserBuyer.LastName)
                {
                    randomUserId = rand.Next(1, usersCount);
                    randUserSeller = context.Users.Find(randomUserId);
                }
             
                // random number of categories
                product.Buyer = randUserBuyer;
                product.Seller = randUserSeller;
                int numberOfCats = rand.Next(2, 6);
                for (int i = 0; i < numberOfCats; i++)
                {
                    int randomCatId = rand.Next(0, categoriesCount);
                    Category randCat = context.Categories.Find(randomCatId);
                    if (!product.Categories.Contains(randCat))
                    {
                        product.Categories.Add(randCat);
                    }                 
                }
                context.Products.Add(product);
            }
            // set some items' buyers to null
           
                for (int i = 0; i < 3; i++)
                {
                    int randomIndex = rand.Next(0, usersCount);
                    User user = context.Users.Find(randomIndex);
                    if (user.ProductsBought.Any())
                    {
                        var product = user.ProductsBought.First();
                        user.ProductsBought.Remove(product);
                        product.Buyer = null;
                    }
                }
            
          
            context.SaveChanges();
        }

    }
}
