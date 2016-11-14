namespace FootballBet.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistics
    {
        [Key]
        [Column(Order = 0)]
        public int GameId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PlayerId { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssists { get; set; }

        public int PlayedMinutes { get; set; }

    }
}
