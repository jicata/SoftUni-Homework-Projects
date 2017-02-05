namespace PizzaMore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("name=PizzaMore.Context")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Pizza> Pizzas { get; set; }

        public IDbSet<Session> Sessions { get; set; }

    }

}