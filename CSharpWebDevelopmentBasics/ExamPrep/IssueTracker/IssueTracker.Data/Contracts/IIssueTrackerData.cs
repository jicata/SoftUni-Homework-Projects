namespace IssueTracker.Data.Contracts
{
    using Models;
    using Repositories;

    public interface IIssueTrackerData
    {
        Repository<User> Users { get; }

        Repository<Issue> Issues { get; }

        Repository<Login> Logins { get; }

        IIssueTrackerContext Context { get; }

        int SaveChanges();
    }
}
