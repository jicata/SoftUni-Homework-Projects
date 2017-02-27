namespace PizzaForum.Data
{
    using Contracts;
    using Models;
    using Repositories;

    public class PizzaForumData : IPizzaForumData
    {
        private readonly IPizzaForumContext context;

        public PizzaForumData()
            :this(new PizzaForumContext())
        {
            
        }
        public PizzaForumData(IPizzaForumContext context)
        {
            this.context = context;
        }

        public Repository<User> Users => new UserRepository(this.context);
        public Repository<Category> Categories => new CategoryRepository(this.context);
        public Repository<Topic> Topics => new TopicRepository(this.context);
        public Repository<Reply> Replies => new ReplyRepository(this.context);
        public Repository<Login> Logins => new LoginRepository(this.context);
        public IPizzaForumContext Context => this.context;
        public int SaveChanges()
        {
            return this.Context.DbContext.SaveChanges();
        }

    
    }
}
