using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitalism.Models
{
    public abstract class PaidPerson : IPerson
    {

        public string FirstName {get; private set;}
        public string LastName { get; private set; }
        public decimal Salary { get; private set; }
        
    }
}
