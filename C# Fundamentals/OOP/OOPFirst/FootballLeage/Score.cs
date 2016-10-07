using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeage
{
  public  class Score
    {
        private int homeTeamGoals;
        private int awayTeamGoals;
        public Score(int homeTeamGoals, int awayTeamGoals)
        {
            this.HomeTeamGoals = homeTeamGoals;
            this.AwayTeamGoals = awayTeamGoals;
        }
        public int HomeTeamGoals
        {
            get { return homeTeamGoals; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Goals cannot be negative");
                }
                homeTeamGoals = value; }
        }
        public int AwayTeamGoals
        {
            get { return awayTeamGoals; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Goals cannot be negative");
                }
                awayTeamGoals = value; 
            }
        }

    }
}
