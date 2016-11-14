namespace FootballBet.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BetGame
    {
        [Key]
        [Column(Order = 0)]
        public int GameId { get; set; }        

        [Key]
        [Column(Order = 1)]
        public int BetId { get; set; }

        public virtual ResultPrediction ResultPrediction { get; set; }
    }
}
