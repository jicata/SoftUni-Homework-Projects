namespace SimpleMVC.App.MVC.Secutiry
{
    using System.Linq;
    using Interfaces;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.dbContext.Logins.Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}
