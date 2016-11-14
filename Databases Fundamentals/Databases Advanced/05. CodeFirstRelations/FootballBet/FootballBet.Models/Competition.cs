namespace FootballBet.Models
{
    using System.Collections.Generic;
    using Enums;

    public class Competition
    {
        public Competition()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public CompetitionType CompetitionType { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
