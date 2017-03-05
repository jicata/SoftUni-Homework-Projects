namespace SoftUniStore.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface ISoftStoreContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Login> Logins { get; }           
        IDbSet<Game> Games { get; }
        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
