namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims = new HashSet<Person>();
        }

        public int Id { get; set; }

        [InverseProperty("AnomaliesOriginPlanet")]
        public virtual Planet OriginPlanet { get; set; }

        [InverseProperty("AnomaliesTeleportPlanet")]
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; }
        
    }
}
