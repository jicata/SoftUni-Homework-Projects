namespace BusTicketSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using Enum;

    public class Customer
    {
        public Customer()
        {
            this.Reviews = new HashSet<Review>();
            this.Tickets = new List<Tickets>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }
        
        [Column("HomeTownId")]
        public int TownId { get; set; }

        [ForeignKey("TownId")]
        public virtual Town HomeTown { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
        
        
        
    }
}
