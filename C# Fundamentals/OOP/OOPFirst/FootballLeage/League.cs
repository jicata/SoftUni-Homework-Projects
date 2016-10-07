using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeage
{
    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Match> Matches
        {
            get { return League.matches; }
        }
        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static void AddMatch(Match match)
        {
            if (MatchExists(match))
            {
                throw new InvalidOperationException("This match already exists in the league!");
            }
            matches.Add(match);
        }
        public static bool MatchExists(Match match)
        {
            bool matchExists = false;
            foreach (Match igra in Matches)
            {
                if (igra.ID == match.ID)
                {
                    matchExists = true;
                    return matchExists;
                }
            }
            return matchExists;
        }
        public static void AddTeam(Team team)
        {
            if (TeamExists(team))
            {
                throw new InvalidOperationException("This team already exists in the league!");
            }
            teams.Add(team);
        }
        public static bool TeamExists(Team team)
        {
            bool teamExists = false;
            foreach (Team otbor in teams)
            {
                if (otbor.Name == team.Name)
                {
                    teamExists = true;
                    return teamExists;
                }
            }
            return teamExists;
        }
        

    }
}
