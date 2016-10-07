using System;
using Capitalism.Contracts;


namespace Capitalism.Models.Employees
{
    public class Salesman : Employee
    {
        private const decimal SalesmanSalaryFactor = 1.015m;
        public Salesman(string firstName, string lastName, decimal salary, IDepartment department)
            : base(firstName, lastName, salary, department, SalesmanSalaryFactor)
        {
        }
        public Salesman(string firstName, string lastName, decimal salary)
           : this (firstName, lastName, salary, null)
        {
        }
    }
}
