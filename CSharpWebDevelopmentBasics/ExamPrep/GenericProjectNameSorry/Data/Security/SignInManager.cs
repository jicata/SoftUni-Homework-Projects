namespace Data.Security
{
    using System.Linq;
    using Contracts;

    public class SignInManager
    {
        private IData data;

        public SignInManager(IData data)
        {
            this.data = data;
        }
        public bool IsAuthenticated(HttpSession session)
        {
            return this.data.Logins.GetAll().Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}
