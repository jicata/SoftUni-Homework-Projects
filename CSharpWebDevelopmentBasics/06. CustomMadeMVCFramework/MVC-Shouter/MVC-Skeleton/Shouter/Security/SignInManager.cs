namespace Shouter.Security
{
    using System.Linq;
    using Data.Contracts;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private IShouterContext context;

        public SignInManager(IShouterContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.context.Logins.Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}
