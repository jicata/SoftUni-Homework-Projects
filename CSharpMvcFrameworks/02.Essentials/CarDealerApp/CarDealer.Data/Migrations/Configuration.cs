namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealer.Data.CarDealerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealer.Data.CarDealerContext context)
        {
            var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new Role("Admin"));
            }
        }
    }
}
