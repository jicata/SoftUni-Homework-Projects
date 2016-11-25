namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Persons")]
    public class Person
    {

        public Person()
        {
            this.Anomalies = new HashSet<Anomaly>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Planet")]
        public int HomePlanetId { get; set; }

        public virtual Planet Planet { get; set; }

        public virtual ICollection<Anomaly> Anomalies { get; set; }
        
    }
}
