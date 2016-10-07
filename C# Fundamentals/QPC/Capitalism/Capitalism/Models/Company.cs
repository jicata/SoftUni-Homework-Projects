using System;
using System.Collections.Generic;
using Capitalism.Contracts;


namespace Capitalism.Models
{
    public class Company : ICompany
    {
        public Company(string name, CEO ceo)
        {
            this.Name = name;
            this.ceo = ceo;
            this.Departments = new List<IDepartment>();
            this.CompanyEmployees = new List<IPaidPerson>();
        }

        public string Name { get; }
        public CEO ceo { get; }
        public ICollection<IDepartment> Departments { get; }
        public ICollection<IPaidPerson> CompanyEmployees { get; }

        public void GetEmAll(IPaidPerson person)
        {
            if(IPaidPerson)
        }
    }
}
