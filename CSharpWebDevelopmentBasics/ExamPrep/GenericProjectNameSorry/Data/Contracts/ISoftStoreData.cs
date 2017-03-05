namespace SoftUniStore.Data.Contracts
{
    using Models;
    using Repositories;

    public interface ISoftStoreData
    {
        Repository<User> Users { get; }
        Repository<Login> Logins { get; }

        Repository<Game> Games { get; }
        ISoftStoreContext Context { get; }

        int SaveChanges();
    }
}
