namespace PizzaMore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("PizzaMore.Context")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Session> Sessions { get; set; }

    }

}