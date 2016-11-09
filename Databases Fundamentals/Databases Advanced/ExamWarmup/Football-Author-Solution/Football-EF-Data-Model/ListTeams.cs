namespace Football_EF_Data_Model
{
    using System;
    using System.Linq;

    class ListTeams
    {
        static void Main()
        {
            var context = new FootballContext();
            Console.WriteLine(string.Join(", ", context.Teams.Select(t => t.TeamName)));
        }
    }
}
