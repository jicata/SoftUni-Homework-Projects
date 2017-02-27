namespace PizzaForum.Data
{
    using Contracts;
    using Models;
    using Repositories;
    public class ReplyRepository : Repository<Reply>
    {
        public ReplyRepository(IPizzaForumContext context) : base(context)
        {
        }
    }
}
