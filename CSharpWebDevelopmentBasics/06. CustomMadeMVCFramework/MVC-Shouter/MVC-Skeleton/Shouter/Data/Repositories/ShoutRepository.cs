namespace Shouter.Data.Repositories
{
    using Contracts;
    using Models;
    public class ShoutRepository : Repository<Shout>
    {
        public ShoutRepository(IShouterContext context) 
            : base(context)
        {
        }
    }
}
