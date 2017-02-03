namespace Products.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<Products.Data.ProductsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Products.Data.ProductsContext context)
        {
            if (context.Orders.Any())
            {
                return;
            }
            Order order1 = new Order()
            {
                Name = "Harry Potter 5 Game",
                ProductType = ProductType.PC,
                PaymentDate = new DateTime(2017, 01, 29),
                DeliveryDate = new DateTime(2017, 02, 01),
                Status = new Status()
                {
                    StatusType = StatusType.Pending
                }
            };
            Order order2 = new Order()
            {
                Name = "Pandemic",
                ProductType = ProductType.BoardGame,
                PaymentDate = new DateTime(2017, 01, 17),
                DeliveryDate = new DateTime(2017, 01, 19),
                Status = new Status()
                {
                    StatusType = StatusType.Delivered
                }
            };
            Order order3 = new Order()
            {
                Name = "Logitech G502",
                ProductType = ProductType.Accessory,
                PaymentDate = new DateTime(2017, 01, 29),
                DeliveryDate = new DateTime(2017, 01, 31),
                Status = new Status()
                {
                    StatusType = StatusType.InCallToConfirm
                }
            };
            Order order4 = new Order()
            {
                Name = "Warcraft: The Beginning",
                ProductType = ProductType.DVD,
                PaymentDate = new DateTime(2017, 01, 18),
                DeliveryDate = new DateTime(2017, 01, 19),
                Status = new Status()
                {
                    StatusType = StatusType.Declined
                }
            };
            Order order5 = new Order()
            {
                Name = "Grimm's Fairy Tales",
                ProductType = ProductType.Book,
                PaymentDate = new DateTime(2017, 01, 20),
                DeliveryDate = new DateTime(2017, 01, 23),
                Status = new Status()
                {
                    StatusType = StatusType.Delivered
                }
            };
            List<Order> orders = new List<Order>() {order1, order2, order3, order4, order5};
            orders.ForEach(o=>context.Orders.Add(o));

        }
    }
}
