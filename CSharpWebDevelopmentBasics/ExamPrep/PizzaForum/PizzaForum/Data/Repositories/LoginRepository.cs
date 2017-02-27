namespace PizzaForum.Data.Repositories
{
    using Contracts;
    using Models;
    public class LoginRepository : Repository<Login>
    {
        public LoginRepository(IPizzaForumContext context) : base(context)
        {
        }
    }
}
