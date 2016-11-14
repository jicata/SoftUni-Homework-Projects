namespace VehicleSystem.Models.Motor
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ships")]
    public class Ship : MotorVehicle
    {
        public string Nationality { get; set; }

        public string CaptainName { get; set; }

        public int CrewSize { get; set; }
    }
}
