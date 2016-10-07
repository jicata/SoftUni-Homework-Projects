using System;
using Capitalism.Contracts;


namespace Capitalism.Models.Employees
{
    public class Accountant : Employee
    {
        private const decimal AccountantSalaryFactor = 1;

        public Accountant(string firstName, string lastName, decimal salary, IDepartment department) 
            : base(firstName, lastName, salary, department,AccountantSalaryFactor)
        {
        }
        public Accountant(string firstName, string lastName, decimal salary)
           : this (firstName, lastName, salary, null)
        {
        }


    }
}
