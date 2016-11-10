namespace _05.HospitalDatabase.Models
{
    using System;

    public class Visitation
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Comments { get; set; }

        public virtual Doctor Doctor { get; set; }
        
    }
}

