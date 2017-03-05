namespace SoftUniStore.Data.Security
{
    using System.Linq;
    using Contracts;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private ISoftStoreData data;

        public SignInManager(ISoftStoreData data)
        {
            this.data = data;
        }
        public bool IsAuthenticated(HttpSession session)
        {
            return this.data.Logins.GetAll().Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}
