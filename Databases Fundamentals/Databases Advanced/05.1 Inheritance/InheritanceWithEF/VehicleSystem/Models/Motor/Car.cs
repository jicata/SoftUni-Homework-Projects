namespace VehicleSystem.Models.Motor
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cars")]
    public class Car : MotorVehicle
    {
        public int NumberOfDoors { get; set; }

        public bool IsInsured { get; set; }
    }
}
