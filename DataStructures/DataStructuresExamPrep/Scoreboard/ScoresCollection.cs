namespace Scoreboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ScoresCollection
    {
        private Dictionary<string, string> playersByUsername;
        private SortedDictionary<string, string> gamesByGamename;
        private OrderedDictionary<string, OrderedBag<Scoreboard>> scores;

        public ScoresCollection()
        {
            this.playersByUsername = new Dictionary<string, string>();
            this.gamesByGamename = new SortedDictionary<string, string>();
            this.scores = new OrderedDictionary<string, OrderedBag<Scoreboard>>(new PrefixComparator());
        }

        private string RegisterUser(string username, string password)
        {
            if (this.playersByUsername.ContainsKey(username))
            {
                return "Duplicated user";
            }
            this.playersByUsername.Add(username, password);
            return "User registered";
        }

       private string RegisterGame(string gamename, string gamePassword)
        {
            if (this.gamesByGamename.ContainsKey(gamename))
            {
                return "Duplicated game";
            }
            this.gamesByGamename.Add(gamename, gamePassword);
            this.scores.Add(gamename, new OrderedBag<Scoreboard>());
            return "Game registered";
        }

        private string AddScore(string username, string password, string gamename, string gamePassword, int score)
        {
            if (!this.playersByUsername.ContainsKey(username) || this.playersByUsername[username] != password
                || !this.gamesByGamename.ContainsKey(gamename) || this.gamesByGamename[gamename] != gamePassword)
            {
                return "Cannot add score";
            }
            var scoreBoard = new Scoreboard(score, username);
            if (!this.scores.ContainsKey(gamename))
            {
                this.scores.Add(gamename, new OrderedBag<Scoreboard>());
            }
            this.scores[gamename].Add(scoreBoard);
            return "Score added";
        }

        private string ShowScoreboard(string gamename)
        {
            if (!this.scores.ContainsKey(gamename))
            {
                return "Game not found";
            }
            if (this.scores[gamename].Count == 0)
            {
                return "No scores";
            }
            var scores = this.scores[gamename].Take(10);
            int count = 1;
            StringBuilder sb = new StringBuilder();
            foreach (var score in scores)
            {
                sb.AppendLine("#"+count + " " + score);
                count++;
            }
            return sb.ToString().Trim();
        }

        private string DeleteGame(string gamename, string gamePassword)
        {
            if (!this.gamesByGamename.ContainsKey(gamename) || this.gamesByGamename[gamename] != gamePassword)
            {
                return "Cannot delete game";
            }
            this.gamesByGamename.Remove(gamename);
            this.scores.Remove(gamename);
            return "Game deleted";
        }

        private string ListGamesByPrefix(string prefix)
        {
            var upperBound = prefix + char.MaxValue;
            var gamesByPrefix = this.scores.Range(prefix,true,upperBound, false);
            if (gamesByPrefix.Count == 0)
            {
                return "No matches";
            }
            var onlyTen = gamesByPrefix.Keys.Take(10);

            return string.Join(", ", onlyTen);
        }

        public string ProcessCommand(string command)
        {
            string[] commandArgs = command.Split();
            string commandName = commandArgs[0];
            switch (commandName)
            {
                case "RegisterUser":
                    return this.RegisterUser(commandArgs[1], commandArgs[2]);
                case "RegisterGame":
                    return this.RegisterGame(commandArgs[1], commandArgs[2]);
                case "AddScore":
                    return this.AddScore(commandArgs[1], commandArgs[2], commandArgs[3], commandArgs[4],
                        int.Parse(commandArgs[5]));
                case "ShowScoreboard":
                    return this.ShowScoreboard(commandArgs[1]);
                case "ListGamesByPrefix":
                    return this.ListGamesByPrefix(commandArgs[1]);
                case "DeleteGame":
                    return this.DeleteGame(commandArgs[1], commandArgs[2]);
                default:
                    throw new ArgumentException("Unrecognized Command");
            }
        }

        
    }
}
