namespace Scoreboard
{
    using System;
    public class Scoreboard: IComparable<Scoreboard>
    {
        public Scoreboard(int score, string player)
        {
            this.Score = score;
            this.PlayerName = player;
        }
        public int Score { get; set; }
        public string PlayerName { get; set; }

        public int CompareTo(Scoreboard other)
        {
            int scoreComparison = other.Score.CompareTo(this.Score);
            if (scoreComparison == 0)
            {
                return this.PlayerName.CompareTo(other.PlayerName);
            }
            return scoreComparison;
        }

        public override string ToString()
        {
            return this.PlayerName + " " + this.Score;
        }
    }
}
