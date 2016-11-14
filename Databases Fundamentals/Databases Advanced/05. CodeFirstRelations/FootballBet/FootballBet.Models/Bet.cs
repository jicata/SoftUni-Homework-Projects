namespace FootballBet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        public Bet()
        {
            this.BettedGames = new HashSet<BetGame>();
        }

        public int Id { get; set; }

        public decimal BetMoney { get; set; }

        public DateTime? DateTime { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<BetGame> BettedGames { get; set; }
        
    }
}
