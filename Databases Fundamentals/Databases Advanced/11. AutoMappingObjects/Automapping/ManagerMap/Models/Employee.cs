namespace ManagerMap.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Adress { get; set; }

        public bool IsOnVACation { get; set; }

        public Employee Manager { get; set; }

        public ICollection<Employee> Subordinates { get; set; }

    }
}
