namespace FootballBet.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        public Player()
        {
            this.Statistics = new HashSet<PlayerStatistics>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public bool IsCurrentlyInjured { get; set; }

        public virtual Team Team { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<PlayerStatistics> Statistics { get; set; }      

    }
}
