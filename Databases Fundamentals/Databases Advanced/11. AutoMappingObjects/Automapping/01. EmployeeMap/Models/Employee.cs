﻿namespace _01.EmployeeMap.Models
{
    using System;

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Adress { get; set; }
    }
}
