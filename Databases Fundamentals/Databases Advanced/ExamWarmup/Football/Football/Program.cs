namespace Football
{
    using System;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            XDocument doc = new XDocument(new XElement("matches"));
            Football context = new Football();

            //foreach (var internationalMatch in context.InternationalMatches)
            //{
            //    if (internationalMatch.MatchDate.HasValue)
            //    {
            //        Console.WriteLine(internationalMatch.MatchDate.Value.ToString());
            //    }


            //}

            //var matches =
            //    context.InternationalMatches.OrderBy(im => im.MatchDate)
            //        .ThenBy(im => im.HomeCountry.CountryName)
            //        .ThenBy(im => im.AwayCountry.CountryName)
            //        .Select(
            //            im =>
            //                new
            //                {
            //                    MatchDate = im.MatchDate,
            //                    HomeCountry = im.HomeCountry,
            //                    AwayCountry = im.AwayCountry,
            //                    HomeGoals = im.HomeGoals,
            //                    AwayGoals = im.AwayGoals,
            //                    League = im.League
            //                });

            //foreach (var internationalMatch in matches)
            //{
            //    var machElement = new XElement("mach");
            //    if (internationalMatch.MatchDate.HasValue)
            //    {
            //        DateTime date = internationalMatch.MatchDate.Value;
            //        if (date.Hour == 0 && date.Minute == 0 && date.Second == 0)
            //        {
            //            machElement.Add(new XAttribute("date", date.ToShortDateString()));
            //        }
            //        else
            //        {
            //            machElement.Add(new XAttribute("date-time", date.ToString()));
            //        }
            //    }
            //    machElement.Add(
            //        new XElement("home-country",
            //            new XAttribute("code", internationalMatch.HomeCountry.CountryCode),
            //            internationalMatch.HomeCountry.CountryName),
            //        new XElement("away-country",
            //            new XAttribute("code", internationalMatch.AwayCountry.CountryCode),
            //            internationalMatch.AwayCountry.CountryName));
            //    if (internationalMatch.AwayGoals.HasValue || internationalMatch.HomeGoals.HasValue)
            //    {
            //        int homeGoals = 0;
            //        int awayGoals = 0;
            //        if (internationalMatch.HomeGoals.HasValue)
            //        {
            //            homeGoals = internationalMatch.HomeGoals.Value;
            //        }
            //        if (internationalMatch.AwayGoals.HasValue)
            //        {
            //            awayGoals = internationalMatch.AwayGoals.Value;
            //        }
            //        var scoreElement = new XElement("score", $"{homeGoals}-{awayGoals}");
            //        machElement.Add(scoreElement);
            //    }
            //    if (internationalMatch.League != null)
            //    {
            //        var leagueElement = new XElement("league", internationalMatch.League.LeagueName);
            //        machElement.Add(leagueElement);
            //    }
            //    doc.Root.Add(machElement);

            //}
            //string savePath =
            //    @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\ExamWarmup\Football\international-matches.xml";
            //doc.Save(savePath);

            string path =
                @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\ExamWarmup\Football-Author-Solution\Import-Leagues-and-Teams-From-XML\leagues-and-teams.xml";

            XDocument docky = XDocument.Load(path);
            int counter = 1;
            bool leagueExists = false;
            string leagueName = string.Empty;
            foreach (var descendant in docky.Root.Descendants("league"))
            {
                Console.WriteLine($"Processing league #{counter} . . .");
                foreach (var leagueElement in descendant.Elements())
                {
                    
                    if (leagueElement.Name == "league-name")
                    {
                        leagueName = leagueElement.Value;
                        if (context.Leagues.Any(l => l.LeagueName == leagueName))
                        {
                            Console.WriteLine($"Existing league: {leagueName}");
                        }
                        else
                        {
                            Console.WriteLine($"Created league: {leagueName}");
                        }
                        leagueExists = true;
                    }
                    if (leagueElement.Name == "teams")
                    {
                        foreach (var teamElement in leagueElement.Elements())
                        {
                            string countryName = null;
                            string name = string.Empty;
                            if (teamElement.Attributes().Any(te => te.Name == "country"))
                            {
                                countryName = teamElement.Attribute("country").Value;
                            }

                            name = teamElement.Attribute("name").Value;
                            if (!string.IsNullOrEmpty(countryName))
                            {
                                if (context.Teams.Any(t => t.TeamName == name && t.Country.CountryName == countryName))
                                {
                                    //Existing team in league: Manchester United belongs to UK Premier League
                                   

                                    Console.WriteLine($"Existing team: {name} ({countryName})");
                                    if (leagueExists)
                                    {
                                        Console.WriteLine($"Existing team in league: {name} belongs to {leagueName}");
                                    }
                                }
                                else
                                {
                                   
                                    Console.WriteLine($"Created team: {name} ({countryName})");
                                    if (leagueExists)
                                    {
                                        // Added team to league: Krivokracite to league Unofficial Friendly Games
                                        Country country =
                                            context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                                        Team team = null;
                                        if (country != null)
                                        {
                                            team = new Team() {TeamName = name, Country = country};
                                        }
                                        else
                                        {
                                            country = new Country() {CountryName = countryName};
                                            team = new Team() { TeamName = name, Country = country };
                                        }
                                        context.Teams.Add(team);
                                        Console.WriteLine($"Added team to league: {name} to league {leagueName}");
                                    }
                                }
                            }
                            else
                            {
                                if (context.Teams.Any(t => t.TeamName == name && t.Country == null))
                                {
                                    if (leagueExists)
                                    {
                                        Console.WriteLine($"Existing team in league: {name} belongs to {leagueName}");
                                    }

                                    Console.WriteLine($"Existing team: {name} (no country)");
                                }
                                else
                                {
                                    if (leagueExists)
                                    {
                                        Team team = new Team() {TeamName = name};
                                        context.Teams.Add(team);
                                        // Added team to league: Krivokracite to league Unofficial Friendly Games
                                        Console.WriteLine($"Added team to league: {name} to league {leagueName}");
                                    }
                                    Console.WriteLine($"Created team: {name} (no country)");
                                }
                            }                    
                        }
                    }
                }
                counter++;
                Console.WriteLine();
                leagueExists = false;
            }
            context.SaveChanges();
        }
    }
}
