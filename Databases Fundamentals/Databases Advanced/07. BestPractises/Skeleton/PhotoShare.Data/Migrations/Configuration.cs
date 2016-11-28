namespace PhotoShare.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Contracts;
    using Repositories;

    internal class Configuration : DbMigrationsConfiguration<PhotoShareContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoShareContext context)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            //unitOfWork.Tags.Add(new Tag() { Name = "#summeTr2" });
            //unitOfWork.Tags.Add(new Tag() { Name = "#NyE2017" });
            //unitOfWork.Tags.Add(new Tag() { Name = "#NoMakeUp1" });
            Town bs = new Town() { Name = "Burgas", Country = "Bulgaria" };
            Town vn = new Town() { Name = "Varna", Country = "Bulgaria" };
            Town tr = new Town() { Name = "Turin", Country = "Italy" };
            unitOfWork.Towns.Add(bs);
            unitOfWork.Towns.Add(vn);
            unitOfWork.Towns.Add(tr);
            unitOfWork.Users.Add(new User() { Username = "pesho", Password = "KKkk??pmer00", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            unitOfWork.Users.Add(new User() { Username = "gosho", Password = "KLoP0k?erl93", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            unitOfWork.Users.Add(new User() { Username = "minka", Password = "Lpkk!?asdr0jj", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            //TODO seed albums
            //TODO seed album roles
            //TODO seed pictures

            unitOfWork.Save();
        }
    }
}
