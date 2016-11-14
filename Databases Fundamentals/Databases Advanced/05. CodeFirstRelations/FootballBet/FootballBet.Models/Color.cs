namespace FootballBet.Models
{
    using System.Collections.Generic;

    public class Color
    {
        public Color()
        {
            this.PrimaryTeams = new HashSet<Team>();
            this.SecondaryTeams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Team> PrimaryTeams { get; set; }

        public virtual ICollection<Team> SecondaryTeams { get; set; }

    }
}
