using System;
using System.Collections.Generic;
using Capitalism.Contracts;


namespace Capitalism.Models
{
    public class Department : IDepartment
    {
        public Department(string name, Manager manager)
        {
            this.Name = name;
            this.Manager = manager;
        }
        public string Name { get; }
        public Manager Manager { get; }
        public ICollection<IEmployee> employeesInDepartment { get; } = new List<IEmployee>();
        public ICollection<IDepartment> SubDepartments { get; } = new List<IDepartment>();
    }
}
