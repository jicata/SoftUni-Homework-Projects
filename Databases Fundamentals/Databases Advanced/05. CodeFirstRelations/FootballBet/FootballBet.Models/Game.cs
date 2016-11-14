namespace FootballBet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.Players = new HashSet<PlayerStatistics>();
            this.Bets = new HashSet<BetGame>();
        }

        public int Id { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime? DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DwrawGameBetRate { get; set; }

        public virtual Round Round { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }

        public virtual ICollection<PlayerStatistics> Players { get; set; }

        public virtual ICollection<BetGame> Bets { get; set; }
 
    }
}
