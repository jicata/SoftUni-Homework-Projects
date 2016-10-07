using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeage
{
    public class LeagueManager
    {
        public static void HandleInput(string input)
        {
            string[] properInput = input.Split();
            switch (properInput[0])
            {
                case "AddTeam":
                    AddTeamToLeague(new Team(properInput[1], properInput[2], DateTime.Parse(properInput[3])));
                    break;
                case "AddMatch":
                    Team team1 = GetTeam(properInput[1]);
                    Team team2 = GetTeam(properInput[2]);
                    AddMatchToLeague(new Match(team1, team2, int.Parse(properInput[3]), new Score(int.Parse(properInput[4]), int.Parse(properInput[5]))));
                    break;
                case "AddPlayerToTeam":
                    Team team = GetTeam(properInput[1]);
                    AddPlayerToTeam(team, new Player(properInput[2], properInput[3], DateTime.Parse(properInput[4]), decimal.Parse(properInput[5])));
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;

            }

        }
        public static void AddTeamToLeague(Team team)
        {
            try
            {
                League.AddTeam(team);
            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static void AddMatchToLeague(Match match)
        {
            try
            {
                League.AddMatch(match);
            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static void AddPlayerToTeam(Team team, Player player)
        {
            try
            {
                team.AddPlayer(player);
            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static void ListTeams()
        {
            foreach (Team team in League.Teams)
            {
                Console.WriteLine(team.ToString());
            }
        }
        public static void ListMatches()
        {
            foreach (Match match in League.Matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
        public static Team GetTeam(string Name)
        {
          
            foreach (Team team in League.Teams)
            {
                if (team.Name == Name)
                {
                    return team;
                }
            }
            return null;
        }
    }
}
