namespace IssueTracker.Data.Security
{
    using System.Linq;
    using Contracts;
    using Data;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private readonly IIssueTrackerData data;

        public SignInManager(IIssueTrackerData data)
        {
            this.data = data;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.data.Logins.GetAll().Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}
