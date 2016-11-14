namespace FootballBet.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        
    }
}
