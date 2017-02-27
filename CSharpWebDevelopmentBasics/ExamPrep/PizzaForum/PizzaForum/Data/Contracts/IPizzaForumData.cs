namespace PizzaForum.Data.Contracts
{

    using Models;
    using Repositories;

    public interface IPizzaForumData
    {
        Repository<User> Users { get; }

        Repository<Category> Categories { get; }

        Repository<Topic> Topics { get; }

        Repository<Reply> Replies { get; }

        Repository<Login> Logins { get; }

        IPizzaForumContext Context { get; }

        int SaveChanges();
    }
}
