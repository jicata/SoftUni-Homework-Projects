using System;
using System.Collections.Generic;
using Capitalism.Contracts;

namespace Capitalism.Models
{
    public class Manager : PaidPerson,IBoss
    {
        private ICollection<IEmployee> subordinates = new List<IEmployee>();
        private IDepartment department;
         
        public Manager(string firstName, string lastName, decimal salary, IDepartment department) 
            : base(firstName, lastName, salary)
        {
            this.Department = department;
        }

        public Manager(string firstName, string lastName, decimal salary)
           : this(firstName, lastName, salary, null)
        {
            this.Department = department;
        }

        public ICollection<IEmployee> Subordinates { get; }
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
