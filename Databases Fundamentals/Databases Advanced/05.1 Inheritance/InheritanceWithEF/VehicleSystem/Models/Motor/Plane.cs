namespace VehicleSystem.Models.Motor
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Planes")]
    public class Plane : MotorVehicle
    {
        public string AirlineOwner { get; set; }

        public string Color { get; set; }

        public int PassangerCapacity { get; set; }
   
    }
}
