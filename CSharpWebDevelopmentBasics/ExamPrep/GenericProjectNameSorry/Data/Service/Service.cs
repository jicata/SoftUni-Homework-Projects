namespace IssueTracker.Data.Service
{
    using Contracts;

    public class Service
    {
        protected IIssueTrackerData data;

        public Service(IIssueTrackerData data)
        {
            this.data = data;
        }
    }
}
