using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public abstract class Employee : PaidPerson, ISalaryFactor
    {
        public decimal SalaryFactor { get; set; }
    }
}
