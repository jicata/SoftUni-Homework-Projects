using System;
using Capitalism.Contracts;


namespace Capitalism.Models.Employees
{
    public class RegularEmployee : Employee
    {
        private const decimal RegularEmployeeSalaryFactor = 1;

        public RegularEmployee(string firstName, string lastName, decimal salary, IDepartment department) 
            : base(firstName, lastName, salary,department, RegularEmployeeSalaryFactor)
        {
        }
        public RegularEmployee(string firstName, string lastName, decimal salary)
           : this (firstName, lastName, salary, null)
        {
        }
    }
}
