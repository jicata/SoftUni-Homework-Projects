namespace VehicleSystem.Models.Motor
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CargoShip : Ship
    {
        public int MaxLoadKilograms { get; set; }
    }
}
