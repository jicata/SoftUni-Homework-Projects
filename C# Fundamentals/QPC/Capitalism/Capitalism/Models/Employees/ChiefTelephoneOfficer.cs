using System;
using Capitalism.Contracts;


namespace Capitalism.Models.Employees
{
    public class ChiefTelephoneOfficer : Employee
    {
        private const decimal CTOSalaryFactor = 0.98m;

        public ChiefTelephoneOfficer(string firstName, string lastName, decimal salary, IDepartment department) 
            : base(firstName, lastName, salary, department,CTOSalaryFactor)
        {
        }
        public ChiefTelephoneOfficer(string firstName, string lastName, decimal salary)
           : this (firstName, lastName, salary, null)
        {
        }
    }
}
