namespace VehicleSystem.Models.NonMotor
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bikes")]
    public class Bike : NonMotorVehicle
    {
        public int ShiftCount { get; set; }

        public string Color { get; set; }
            
    }
}
