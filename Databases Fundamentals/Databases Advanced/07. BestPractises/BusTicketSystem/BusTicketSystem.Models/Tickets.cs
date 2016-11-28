namespace BusTicketSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tickets
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Trip")]
        public int TripId { get; set; }

        public decimal Price { get; set; }

        public string Seat { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
