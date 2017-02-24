namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shouter.Data.ShouterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Shouter.Data.ShouterContext";
        }

        protected override void Seed(Shouter.Data.ShouterContext context)
        {
            //var users = context.Users.ToList();
            //foreach (var user in users)
            //{
            //    var shouts = context.Shouts.Where(s => s.Author == user);
            //    if (user.Shouts.Count == 0 && shouts.Any())
            //    {                   
            //        user.Shouts = shouts.ToList();
            //    }
            //}
            //context.SaveChanges();
        }
       
    }
}
