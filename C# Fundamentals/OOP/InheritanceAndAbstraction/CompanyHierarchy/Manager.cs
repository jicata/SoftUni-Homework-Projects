using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
     public class Manager : Employee, IManager
    {
        private List<Employee> employees;

        public Manager(string firstName, string lastName, int id, decimal salary, string department)
            :base(firstName, lastName, id, salary, department)
        {
            this.employees = new List<Employee>();
        }
        public IEnumerable<Employee> Employees { get { return this.employees; } }

        public void AddEmployee(Employee employee)
        {
            this.employees.Add(employee);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-Name: " + this.FirstName + " " + this.LastName);
            sb.Append("\n-ID: " + this.Id);
            sb.Append("\n--Department: " + this.Department);
            sb.Append("\n--Salary: " + this.Salary);
            sb.Append("\n--Employees under " + this.FirstName + ":");
            if (this.employees.Count == 0)
            {
                sb.Append(" None");
            }
            else
            {
                foreach (Employee empi in this.Employees)
                {
                    sb.Append("\n---" + empi.FirstName + " " + empi.LastName);
                }
            }
            return sb.ToString();
        }
    }
}
