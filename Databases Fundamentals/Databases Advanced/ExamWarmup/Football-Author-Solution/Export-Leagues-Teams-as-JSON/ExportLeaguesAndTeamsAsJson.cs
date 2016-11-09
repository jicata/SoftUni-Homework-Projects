namespace Export_Leagues_Teams_as_JSON
{
    using Football_EF_Data_Model;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    class ExportLeaguesAndTeamsAsJson
    {
        static void Main()
        {
            var context = new FootballContext();
            var leaguesWithTeams = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams
                        .OrderBy(t => t.TeamName)
                        .Select(t => t.TeamName)
                })
                .ToList();
            var jsonSerializer = new JavaScriptSerializer();
            var json = jsonSerializer.Serialize(leaguesWithTeams);
            File.WriteAllText("leagues-and-teams.json", json);
            Console.WriteLine("File leagues-and-teams.json exported.");
        }
    }
}
