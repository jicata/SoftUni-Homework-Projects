namespace PizzaForum.Data
{
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class PizzaForumContext : DbContext, IPizzaForumContext
    {
      
        public PizzaForumContext()
            : base("name=PizzaForumContext")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Login> Logins { get; set; }
        public IDbSet<Reply> Replies { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Topic> Topics { get; set; }

        public DbContext DbContext => this;
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

    }


}