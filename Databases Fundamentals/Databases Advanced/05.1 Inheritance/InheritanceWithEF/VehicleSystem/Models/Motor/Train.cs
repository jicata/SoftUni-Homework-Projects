namespace VehicleSystem.Models.Motor
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Trains")]
    public class Train : MotorVehicle
    {
        //[ForeignKey("Locomotive")]
        //public int LocomotiveId { get; set; }

        public Locomotive Locomotive { get; set; }

        public int NumberOfCarriages { get; set; }

        public virtual ICollection<Carriage> Carriages { get; set; }
        
    }
}
