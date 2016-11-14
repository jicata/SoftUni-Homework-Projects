namespace FootballBet.Models
{
    using System.Collections.Generic;

    public class Continent
    {
        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
        
    }
}
