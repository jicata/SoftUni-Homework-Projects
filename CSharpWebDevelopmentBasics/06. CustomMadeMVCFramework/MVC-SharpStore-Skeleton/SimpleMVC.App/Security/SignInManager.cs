namespace SharpStore.Security
{
    using System.Linq;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private IDbIdentityContext context;

        public SignInManager(IDbIdentityContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.context.Logins.Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}
