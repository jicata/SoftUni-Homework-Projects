namespace IssueTracker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.BindingModels;
    using Models.Enums;
    using Models.ViewModels;
    using SimpleHttpServer.Models;

    public class IssuesService : Service
    {
        public IssuesService(IIssueTrackerData data) : base(data)
        {
        }

        public HashSet<Issue> FindIssues()
        {
            return new HashSet<Issue>(this.data.Issues.GetAll());
        }

        public HashSet<Issue> FindIssues(string query, string status)
        {
            if (string.IsNullOrEmpty(query) && status == "All")
            {
                return this.FindIssues();
            }
            else if (string.IsNullOrEmpty(query) && status != "All")
            {
                return new HashSet<Issue>(this.data.Issues.Find(i => i.Status.ToString() == status));
            }
            else if (!string.IsNullOrEmpty(query) && status != "All")
            {
                return
                    new HashSet<Issue>(
                        this.data.Issues.Find(i => i.Name.Contains(query) || i.Status.ToString() == status));
            }
            else
            {
                return new HashSet<Issue>(this.data.Issues.Find(i => i.Name.Contains(query)));
            }
            
        }

        public HashSet<IssueViewModel> ProduceIssuesList(User user, HashSet<Issue> issues)
        {
            HashSet<IssueViewModel> ivms = new HashSet<IssueViewModel>();
            var placeholderIvm = new IssueViewModel();
            placeholderIvm.LoggedInUserViewModel = new LoggedInUserViewModel()
            {
                Username = user.UserName,
                IsAdmin = user.Role == Role.Administrator
            };
            ivms.Add(placeholderIvm);
            foreach (var issue in issues)
            {
                IssueViewModel ivm = new IssueViewModel()
                {
                    LoggedInUserViewModel = new LoggedInUserViewModel
                    {
                        Username = user.UserName,
                        IsAdmin = user.Role == Role.Administrator
                    },
                    Author = issue.Author.UserName,
                    CreatedOn = issue.CreatedOn.ToString(),
                    Id = issue.Id,
                    Name = issue.Name,
                    Priority = issue.Priority.ToString(),
                    Status = issue.Status.ToString()
                };
                ivms.Add(ivm);
            }
            return ivms;
        }

        public void AddIssue(HttpSession session, NewIssueBindingModel nibm)
        {
            var user = this.FindUserBySession(session);
            Issue issue = new Issue()
            {
                Author = user,
                CreatedOn = DateTime.Now,
                Name = nibm.Name,
                Priority = (Priority)Enum.Parse(typeof(Priority), nibm.Priority),
                Status = (Status)Enum.Parse(typeof(Status), nibm.Status)
            };
            this.data.Issues.InsertOrUpdate(issue);
            this.data.SaveChanges();
        }

        public void DeleteIssueById(int id)
        {
            var issue = this.data.Issues.GetById(id);
            this.data.Issues.Delete(issue);
            this.data.SaveChanges();
        }

        public void UpdateIssue(HttpSession session, EditIssueBindingModel eibm)
        {
            var user = this.FindUserBySession(session);
            var issue = this.data.Issues.GetById(eibm.Id);
            issue.Priority = (Priority) Enum.Parse(typeof(Priority), eibm.Priority);
            issue.Status = (Status) Enum.Parse(typeof(Status), eibm.Status);
            issue.Name = eibm.Name;
            this.data.Issues.InsertOrUpdate(issue);
            this.data.SaveChanges();
        }
    }
}
