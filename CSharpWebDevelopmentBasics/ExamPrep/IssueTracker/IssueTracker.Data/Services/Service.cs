namespace IssueTracker.Data.Services
{
    using Contracts;
    using Models;
    using Models.ViewModels;
    using SimpleHttpServer.Models;

    public class Service
    {
        protected IIssueTrackerData data;

        public Service(IIssueTrackerData data)
        {
            this.data = data;
        }

        public User FindUserBySession(HttpSession session)
        {
            return this.data.Logins.FindByPredicate(l => l.SessionId == session.Id).User;
        }

        public LoggedInUserViewModel CheckedForLoggedInUser(HttpSession session)
        {
            var login = this.data.Logins.FindByPredicate(l => l.SessionId == session.Id && l.IsActive);
            if (login != null)
            {
                LoggedInUserViewModel liuvm = new LoggedInUserViewModel()
                {
                    Username = login.User.UserName
                };
                return liuvm;
            }
            else
            {
                return new LoggedInUserViewModel();
            }
        }
    }
}
