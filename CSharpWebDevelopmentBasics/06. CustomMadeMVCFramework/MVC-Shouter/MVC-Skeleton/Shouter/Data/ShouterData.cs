namespace Shouter.Data
{
    using Contracts;
    using Repositories;

    public class ShouterData
    {
        private readonly IShouterContext context;

        public ShouterData()
            :this(new ShouterContext())
        {
            
        }
        public ShouterData(IShouterContext context)
        {
            this.context = context;
        }

        public UserRepository UsersRepository => new UserRepository(this.context);

        public LoginRepository LoginRepository => new LoginRepository(this.context);

        public ShoutRepository ShoutRepository => new ShoutRepository(this.context);

        public IShouterContext Context => this.context;

        public int SaveChanges() => this.context.SaveChanges();
    }
}
