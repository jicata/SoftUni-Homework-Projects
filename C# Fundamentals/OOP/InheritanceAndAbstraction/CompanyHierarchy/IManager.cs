
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    interface IManager : IEmployee, IPerson
    {
        IEnumerable<Employee> Employees { get; }
    }
}
