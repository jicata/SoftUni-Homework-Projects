namespace Data
{
    using Contracts;
    using Models;
    using Repositories;

    public class Data : IData
    {
        private IContext context;

        public Data()
            :this(new Context())
        {
            
        }

        public Data(IContext context)
        {
            this.context = context;
        }
        public Repository<Login> Logins => new Repository<Login>(this.context);
        public Repository<User> Users => new Repository<User>(this.context);
        public IContext Context => this.context;
        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }

      
    }
}
