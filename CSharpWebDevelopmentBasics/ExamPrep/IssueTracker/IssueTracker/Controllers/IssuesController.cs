namespace IssueTracker.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Data;
    using Data.Contracts;
    using Data.Security;
    using Data.Services;
    using Models;
    using Models.BindingModels;
    using Models.Enums;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class IssuesController : Controller
    {
        private IssuesService service;
        private SignInManager signInManager;

        public IssuesController()
            :this(new IssueTrackerData())
        {

        }

        public IssuesController(IIssueTrackerData data)
        {
            this.service = new IssuesService(data);
            this.signInManager = new SignInManager(data);
        }

        [HttpGet]
        public IActionResult<HashSet<IssueViewModel>> All(HttpResponse response, HttpSession session, string query, string status)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            HashSet<Issue> issues = new HashSet<Issue>();
            var user = this.service.FindUserBySession(session);
            
            if (string.IsNullOrEmpty(query) && string.IsNullOrEmpty(status))
            {
                issues = this.service.FindIssues();
            }
            else
            {
                issues = this.service.FindIssues(query, status);
            }
           
            return this.View(this.service.ProduceIssuesList(user, issues));
        }

        [HttpGet]
        public IActionResult<LoggedInUserViewModel> New(HttpSession session)
        {
            return this.View(this.service.CheckedForLoggedInUser(session));
        }

        [HttpPost]
        public IActionResult New(HttpSession session, HttpResponse response, NewIssueBindingModel nibm)
        {
            this.service.AddIssue(session, nibm);
            this.Redirect(response,"/issues/all");
            return null;
        }

        [HttpGet]
        public IActionResult Delete(HttpResponse response, int id)
        {
            this.service.DeleteIssueById(id);
            this.Redirect(response,"/issues/all");
            return null;
        }

        [HttpGet]
        public IActionResult<EditIssueViewModel> Edit(HttpSession session,HttpResponse response, int id)
        {
            var user = this.service.FindUserBySession(session);
            if (user.Issues.All(i => i.Id != id) && user.Role != Role.Administrator)
            {
                this.Redirect(response,"/issues/all");
                return null;
            }
            var loggedUserViewModel = this.service.CheckedForLoggedInUser(session);
            var editIssueViewModel = new EditIssueViewModel()
            {
                Id = id,
                LoggedInUserViewModel = loggedUserViewModel
            };
            return this.View(editIssueViewModel);
        }

        [HttpPost]
        public IActionResult Edit(HttpSession session, HttpResponse response,EditIssueBindingModel eibm)
        {
            this.service.UpdateIssue(session,eibm);
            this.Redirect(response,"/issues/all");
            return null;
        }
    }
}
