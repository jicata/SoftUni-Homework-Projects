namespace PizzaForum.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IPizzaForumContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Login> Logins { get; }
        IDbSet<Reply> Replies { get; }
        IDbSet<Category> Categories { get; }
        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;

        IDbSet<Topic> Topics { get; }
    }
}
