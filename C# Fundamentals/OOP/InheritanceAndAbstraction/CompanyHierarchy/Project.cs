using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public class Project
    {
        private string projectName;
        private DateTime startDate;
        private string details;
        private bool state;

        public Project(string projectName, DateTime startDate, string details, string state)
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.Details = details;
            SetState(state.ToLower());

        }

        public string ProjectName
        {
            get { return projectName; }
            set { 
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Project name cannot be empty");
                }
                projectName = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public string Details
        {
            get { return details; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Details cannot be empty");
                }
                details = value; }
        }
        public string State
        {
            get 
            {
                if (this.state == true)
                {
                    return "Open";
                }
                else
                {
                    return "Closed";
                }
            }
        }
        public void SetState(string state)
        {
            if (state != "open" && state != "closed")
            {
                throw new ArgumentException("State of project can be only open or closed");
            }
            if (state == "open")
            {
                this.state = true;
            }
            else
            {
                this.state = false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("---Project name: " + this.projectName);
            sb.Append("\n---Project start date: " + this.StartDate.ToLongDateString());
            sb.Append("\n---Project details: " + this.Details);
            sb.Append("\n---Project state: " + this.State);
            return sb.ToString();
        }


    }
}
