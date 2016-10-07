using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeage
{
    public class Team
    {
        private string name;
        private string nickname;
        private DateTime dateFounded; 
        private List<Player> players;

        public Team(string name, string nickname, DateTime dateFoudned)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.players = new List<Player>();
        }
        public string Name
        {
            get { return name; }
            set {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Name should be at least 5(five) characters long!");
                }
                name = value; 
            }
        }
        public string Nickname
        {
            get { return nickname; }
            set {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Name should be at least 5(five) characters long!");
                } 
                nickname = value;
            }
        }
        public IEnumerable<Player> Players
        {
            get { return players; }
        }
        public DateTime DateFounded
        {
            get { return dateFounded; }
            set {
                if (dateFounded.Year < 1850)
                {
                    throw new ArgumentOutOfRangeException("Team cannot be founded earlier than 1850");
                }
                dateFounded = value;
            }
        }
        public void AddPlayer(Player player)
        {
            if (IsPlayerOnTheTeam(player))
            {
                throw new InvalidOperationException("Player is already on the team");
            }
            players.Add(player);
        }
        public bool IsPlayerOnTheTeam(Player player)
        {
            bool isOnTeam = false;
            foreach (Player igrach in this.Players)
            {
                if (igrach.FirstName == player.FirstName && igrach.LastName == player.LastName)
                {
                    isOnTeam = true;
                    return isOnTeam;
                }
            }
            return isOnTeam;
        }
        public override string ToString()
        {
            string name = String.Format("Team prieview for : {0} \nName: {0}; Nickname: {1}; Founded: {2}{3}{4}",this.Name, this.Nickname, this.DateFounded.Year, this.DateFounded.Month, this.DateFounded.Day);
            return name;
        }

    }
}
