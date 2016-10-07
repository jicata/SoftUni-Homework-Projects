using System;
using System.Collections.Generic;
using Capitalism.Models;


namespace Capitalism.Contracts
{
    public interface ICompany
    {

        string Name { get; }
        CEO ceo { get; }
        ICollection<IDepartment> Departments { get; }
        ICollection<IPaidPerson> CompanyEmployees { get; }  
    }
}
