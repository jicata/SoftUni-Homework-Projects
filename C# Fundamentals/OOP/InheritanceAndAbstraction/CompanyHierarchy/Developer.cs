using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public class Developer : Employee
    {
        private List<Project> projects;
        public Developer(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id, salary, "Production")
        {
            this.projects = new List<Project>();
        }
        public IEnumerable<Project> Projects
        {
            get { return this.projects; }
        }

        public void AddProject(Project project)
        {
            this.projects.Add(project);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-Name: " + this.FirstName + " " + this.LastName);
            sb.Append("\n-ID: " + this.Id);
            sb.Append("\n--Department: " + this.Department);
            sb.Append("\n--Salary: " + this.Salary);
            sb.Append("\n--Projects: ");
            if (this.projects.Count == 0)
            {
                sb.Append("None");
            }
            else
            {
                foreach (Project project in this.projects)
                {
                    sb.Append("\n" + project.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
