namespace Data.Contracts
{
    using Models;
    using Repositories;

    public interface IData
    {
        Repository<User> Users { get; }
        Repository<Login> Logins { get; }

        IContext Context { get; }

        int SaveChanges();
    }
}
