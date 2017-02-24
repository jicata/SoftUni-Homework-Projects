namespace Shouter.Data.Repositories
{
    using Contracts;
    using Models;
    public class NotificationRepository : Repository<Notification>
    {
        public NotificationRepository(IShouterContext context) : base(context)
        {
        }
    }
}
