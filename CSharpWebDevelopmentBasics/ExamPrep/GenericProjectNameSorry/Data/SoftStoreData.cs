namespace SoftUniStore.Data
{
    using Contracts;
    using Models;
    using Repositories;

    public class SoftStoreData : ISoftStoreData
    {
        private readonly ISoftStoreContext context;

        public SoftStoreData()
            :this(new SoftStoreContext())
        {

        }

        public SoftStoreData(ISoftStoreContext context)
        {
            this.context = context;
        }
        public Repository<Login> Logins => new Repository<Login>(this.context);
        public Repository<User> Users => new Repository<User>(this.context);
        public Repository<Game> Games => new Repository<Game>(this.context);
        public ISoftStoreContext Context => this.context;
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

      
    }
}
