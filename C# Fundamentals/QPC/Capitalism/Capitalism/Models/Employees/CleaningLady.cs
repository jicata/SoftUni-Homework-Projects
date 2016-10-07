using System;
using Capitalism.Contracts;

namespace Capitalism.Models.Employees
{
    public class CleaningLady : Employee
    {
        private const decimal CleaningLadySalaryFactor = 0.98m;

        public CleaningLady(string firstName, string lastName, decimal salary, IDepartment department) 
            : base(firstName, lastName, salary, department, CleaningLadySalaryFactor)
        {
        }
        public CleaningLady(string firstName, string lastName, decimal salary)
           : this (firstName, lastName, salary, null)
        {
        }
    }
}
