namespace SharpStore.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SharpStoreContext context)
        {
            if (context.Knives.Any())
            {
                return;
            }
            Knife k1 = new Knife()
            {
                Name = "Ostar",
                Price = 400,
                ImageUrl = "../../content/images/k1.png"
            };
            Knife k2 = new Knife()
            {
                Name = "Gut-knife",
                Price = 350,
                ImageUrl = "../../content/images/k2.png"
            };
            Knife k3 = new Knife()
            {
                Name = "Butt plugs",
                Price = 1000,
                ImageUrl = "../../content/images/k3.png"
            };
            context.Knives.Add(k1);
            context.Knives.Add(k2);
            context.Knives.Add(k3);
            context.SaveChanges();
        }
    }
}
