using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeage
{
    public class Match
    {
        private Team homeTeam;
        private Team awayTeam;
        private Score score;

       
        private int Id;
        public Match(Team homeTeam, Team awayTeam, int Id, Score score)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.ID = Id;
            this.Score = score;
        }
        internal Score Score
        {
            get { return score; }
            set { score = value; }
        }
        public Team HomeTeam
        {
            get { return homeTeam; }
            set { homeTeam = value; }
        }
        public Team AwayTeam
        {
            get { return awayTeam; }
            set { awayTeam = value; }
        }
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public override string ToString()
        {
            string name = this.homeTeam.Name + " vs. " + this.awayTeam.Name;
            return name;
        }
    }
}
