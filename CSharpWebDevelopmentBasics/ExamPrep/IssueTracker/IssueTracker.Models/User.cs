namespace IssueTracker.Models
{
    using System.Collections.Generic;
    using Enums;

    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
        
    }
}
