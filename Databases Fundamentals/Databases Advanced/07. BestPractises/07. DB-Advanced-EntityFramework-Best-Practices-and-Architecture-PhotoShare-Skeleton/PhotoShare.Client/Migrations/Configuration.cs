namespace PhotoShare.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal class Configuration : DbMigrationsConfiguration<PhotoShareContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoShareContext context)
        {
            //TODO Seed some data in the database
            context.Tags.AddOrUpdate(new Tag() { Name = "#summer" });
            context.Tags.AddOrUpdate(new Tag() { Name = "#NYE2017" });
            context.Tags.AddOrUpdate(new Tag() { Name = "#NoMakeUp#" });
            Town bs = new Town() { Name = "Burgas", Country = "Bulgaria" };
            Town vn = new Town() { Name = "Varna", Country = "Bulgaria" };
            Town tr = new Town() { Name = "Turin", Country = "Italy" };
            context.Towns.AddOrUpdate(bs);
            context.Towns.AddOrUpdate(vn);
            context.Towns.AddOrUpdate(tr);
            context.Users.AddOrUpdate(new User() { Username = "pesho", Password = "KKkk??pmer00", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            context.Users.AddOrUpdate(new User() { Username = "gosho", Password = "KLoP0k?erl93", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            context.Users.AddOrUpdate(new User() { Username = "minka", Password = "Lpkk!?asdrjj", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            //TODO seed albums
            //TODO seed album roles
            //TODO seed pictures

            context.SaveChanges();
        }
    }
}
