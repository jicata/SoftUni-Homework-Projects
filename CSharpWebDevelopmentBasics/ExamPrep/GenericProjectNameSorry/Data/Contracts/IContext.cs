namespace Data.Contracts
{
    using Models;

    public interface IContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Login> Logins { get; }           
        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
