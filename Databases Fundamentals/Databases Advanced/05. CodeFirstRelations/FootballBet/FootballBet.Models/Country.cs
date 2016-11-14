namespace FootballBet.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        [Key]
        [MinLength(3)]
        [MaxLength(3)]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
        
    }
}
