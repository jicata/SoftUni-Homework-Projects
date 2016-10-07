using System;
using System.Collections;
using System.Collections.Generic;
using Capitalism.Models;

namespace Capitalism.Contracts
{
    public interface IDepartment
    {
        string Name { get; }
        Manager Manager { get; }
        ICollection<IEmployee> employeesInDepartment { get; }
        ICollection<IDepartment> SubDepartments { get; } 

    }
}
