using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Manager : PaidPerson, ISalaryFactor
    {

        public double SalaryFactor { get; private set; }
        
    }
}
