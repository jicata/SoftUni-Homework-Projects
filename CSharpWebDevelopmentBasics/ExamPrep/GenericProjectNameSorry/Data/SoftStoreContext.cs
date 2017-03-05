namespace SoftUniStore.Data
{
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class SoftStoreContext : DbContext, ISoftStoreContext
    {
        public SoftStoreContext()
            : base("name=SoftStoreContext")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Login> Logins { get; set; }
        public IDbSet<Game> Games { get; set; }
        public DbContext DbContext => this;
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}