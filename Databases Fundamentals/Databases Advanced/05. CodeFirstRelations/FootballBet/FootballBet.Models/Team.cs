namespace FootballBet.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(3)]
        [MinLength(3)]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public virtual Town Town { get; set; }

        [InverseProperty("PrimaryTeams")]
        public virtual Color PrimaryKitColor { get; set; }

        [InverseProperty("SecondaryTeams")]
        public virtual Color SecondaryKitColor { get; set; }

        public virtual ICollection<Player> Players { get; set; }


    }
}
