namespace PizzaForum.Data.Repositories
{
    using Contracts;
    using Models;
    public class UserRepository : Repository<User>
    {
        public UserRepository(IPizzaForumContext context) : base(context)
        {
        }
    }
}
