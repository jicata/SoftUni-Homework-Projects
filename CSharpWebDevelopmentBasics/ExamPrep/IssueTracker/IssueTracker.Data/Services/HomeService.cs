namespace IssueTracker.Data.Services
{
    using Contracts;

    public class HomeService : Service
    {
        public HomeService(IIssueTrackerData data) : base(data)
        {
        }
    }
}
