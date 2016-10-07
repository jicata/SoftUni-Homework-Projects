using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitalism.Contracts;

namespace Capitalism.Models
{
    public abstract class PaidPerson : IPaidPerson
    {
        private string firstName;
        private string lastName;
        private decimal salary;

        protected PaidPerson(string firstName, string lastName, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public decimal Salary { get; }

        public override string ToString()
        {
            string info = string.Format("{0} {1} ({2})", this.FirstName, this.LastName, this.Salary);
            return info;
        }
    }
}
