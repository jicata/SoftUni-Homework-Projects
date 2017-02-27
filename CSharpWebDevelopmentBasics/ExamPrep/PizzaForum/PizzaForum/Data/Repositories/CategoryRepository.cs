namespace PizzaForum.Data
{
    using Contracts;
    using Models;
    using Repositories;
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(IPizzaForumContext context) : base(context)
        {
        }
    }
}
