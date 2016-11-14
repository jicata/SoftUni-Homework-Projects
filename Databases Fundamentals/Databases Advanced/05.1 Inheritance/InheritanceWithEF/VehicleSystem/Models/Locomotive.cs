namespace VehicleSystem.Models
{
    using Motor;

    public class Locomotive
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Power { get; set; }

        public virtual Train Train { get; set; }
        
    }
}
