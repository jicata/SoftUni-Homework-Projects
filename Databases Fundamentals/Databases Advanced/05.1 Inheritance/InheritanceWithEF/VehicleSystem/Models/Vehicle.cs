namespace VehicleSystem.Models
{
    public abstract class Vehicle
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public double MaxSpeed { get; set; }
    }
}
