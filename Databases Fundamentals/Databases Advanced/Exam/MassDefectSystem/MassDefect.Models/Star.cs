namespace MassDefect.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Star
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }
        
    }
}
