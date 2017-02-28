namespace IssueTracker.Data
{
    using Contracts;
    using Models;
    using Repositories;

    public class IssueTrackerData : IIssueTrackerData
    {
        private readonly IIssueTrackerContext context;

        public IssueTrackerData()
            :this(new IssueTrackerContext())
        {
            
        }
        public IssueTrackerData(IIssueTrackerContext context)
        {
            this.context = context;
        }

        public Repository<User> Users =>  new Repository<User>(this.context);
        
        public Repository<Issue> Issues => new Repository<Issue>(this.context);

        public Repository<Login> Logins => new Repository<Login>(this.context);
        public IIssueTrackerContext Context => this.context;
        public int SaveChanges()
        {
            return this.Context.DbContext.SaveChanges();
        }

    
    }
}
