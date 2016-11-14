namespace FootballBet.Models
{
    using System.Collections.Generic;

    public class Round
    {
        public Round()
        {
            this.Games = new HashSet<Game>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        
    }
}
