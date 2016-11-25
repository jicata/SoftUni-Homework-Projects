namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Planet
    {
        public Planet()
        {
            this.Persons = new HashSet<Person>();
            this.AnomaliesOriginPlanet = new HashSet<Anomaly>();
            this.AnomaliesTeleportPlanet = new HashSet<Anomaly>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Star")]
        public int SunId { get; set; }

        public virtual Star Star { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public virtual ICollection<Anomaly> AnomaliesOriginPlanet { get; set; }

        public virtual ICollection<Anomaly> AnomaliesTeleportPlanet { get; set; }
        
        
    }
}
