using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitalism.Contracts;

namespace Capitalism.Models
{
    public class CEO : PaidPerson, IBoss
    {
        private ICollection<IEmployee> subordinates = new List<IEmployee>();

        public CEO(string firstName, string lastName, decimal salary) 
            : base(firstName, lastName, salary)
        {
        }

        public ICollection<IEmployee> Subordinates { get; }
        
    }
}
