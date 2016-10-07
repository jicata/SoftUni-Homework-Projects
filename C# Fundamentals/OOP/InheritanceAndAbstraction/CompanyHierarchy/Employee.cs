using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public class Employee : Person, IEmployee
    {
        private  decimal salary;
        protected string department;

        public Employee(string firstName, string lastName, int id, decimal salary, string department)
            : base(firstName, lastName, id)
        {
            this.Department = department;
            this.Salary = salary;
        }
        public string Department
        {
            get { return department; }
            set 
            { 
                if(value!= "Production" && value!="Accounting" && value!="Sales" && value!= "Marketing")
                {
                    throw new ArgumentException("Department can only be one of the following: Production, Accounting, Sales or Marketing");
                }
                department = value; 
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set 
            {
                if (value < 0 || String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Salary field cannot be empty and Salary cannot be negative");
                }
                salary = value; 
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-Name: " + this.FirstName + " " + this.LastName);
            sb.Append("\n-ID: " + this.Id);
            sb.Append("\n--Department: " + this.Department);
            sb.Append("\n--Salary: " + this.Salary);
            return sb.ToString();
        }

    }
}
