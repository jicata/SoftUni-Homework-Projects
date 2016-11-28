namespace BusTicketSystem.Models
{
    using System;

    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public float Grade { get; set; }

        public virtual BusCompany BusCompany { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime? PublishedOn { get; set; }

    }
}
