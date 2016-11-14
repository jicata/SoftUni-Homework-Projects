namespace FootballBet.Data
{
    using System.Data.Entity;
    using Models;

    public class FootballBetContext : DbContext
    {

        public FootballBetContext()
            : base("name=FootballBetContext")
        {
        }

        public IDbSet<Bet> Bets { get; set; }
        public IDbSet<Color> Colors { get; set; }
        public IDbSet<Competition> Competitions { get; set; }
        public IDbSet<Continent> Continents { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<Player> Players { get; set; }
        public IDbSet<Position> Positions { get; set; }
        public IDbSet<Round> Rounds { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<Town> Towns { get; set; }
        public IDbSet<User> Users { get; set; }


        //can't compile with many-to-many dbsets<>
        //public IDbSet<PlayerStatistics> PlayerStatistics { get; set; }
        //public IDbSet<BetGame> BetGames { get; set; }

    }
}