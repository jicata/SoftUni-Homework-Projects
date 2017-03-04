namespace IssueTracker.Data.Service
{
    using Contracts;
    using Models;
    using Models.ViewModels;
    using SimpleHttpServer.Models;

    public class HomeService : Service
    {
        public HomeService(IIssueTrackerData data) : base(data)
        {
        }

        public User FindUserBySession(HttpSession session)
        {
            return this.data.Logins.FindByPredicate(l => l.SessionId == session.Id).User;
        }
    }
}
