using System;
using Capitalism.Contracts;


namespace Capitalism.Models
{
    public abstract class Employee : PaidPerson, IEmployee
    {
        private decimal salaryFactor;
        private IDepartment department;

        public Employee(string firstName, string lastName, decimal salary, IDepartment department, decimal salaryFactor) 
            : base(firstName, lastName, salary)
        {
            this.Department = department;
            this.SalaryFactor = salaryFactor;
        }

        public decimal SalaryFactor { get; }

        public IDepartment Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

       
    }
}
