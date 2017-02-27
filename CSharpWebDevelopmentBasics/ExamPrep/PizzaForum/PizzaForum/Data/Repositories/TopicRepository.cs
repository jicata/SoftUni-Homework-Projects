namespace PizzaForum.Data
{
    using Contracts;
    using Models;
    using Repositories;
    public class TopicRepository : Repository<Topic>
    {
        public TopicRepository(IPizzaForumContext context) : base(context)
        {
        }
    }
}
