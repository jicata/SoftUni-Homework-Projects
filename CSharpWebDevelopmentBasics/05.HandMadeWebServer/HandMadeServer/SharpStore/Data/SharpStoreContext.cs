namespace SharpStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }

        public IDbSet<Knife> Knives { get; set; }

        public IDbSet<Message> Messages { get; set; }
    }
}