namespace Export_International_Matches_as_XML
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;

    using Football_EF_Data_Model;
    using System.Globalization;

    static class ExportInternationalMatchesAsXml
    {
        static void Main()
        {
            // Ensure date formatting will use the English names
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var context = new FootballContext();
            var matches = context.InternationalMatches
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.CountryHome.CountryName)
                .ThenBy(m => m.CountryAway.CountryName)
                .Select(m => new
                {
                    CountryCodeHome = m.CountryHome.CountryCode,
                    CountryNameHome = m.CountryHome.CountryName,
                    CountryCodeAway = m.CountryAway.CountryCode,
                    CountryNameAway = m.CountryAway.CountryName,
                    m.HomeGoals,
                    m.AwayGoals,
                    m.MatchDate,
                    m.League.LeagueName
                })
                .ToList();

            var resultXml = new XElement("matches");
            foreach (var match in matches)
            {
                var matchXml = new XElement("match");
                if (match.MatchDate != null)
                {
                    if (match.MatchDate.Value.TimeOfDay == TimeSpan.Zero)
                    {
                        string date = match.MatchDate.Value.ToString("dd-MMM-yyyy");
                        matchXml.Add(new XAttribute("date", date));
                    }
                    else
                    {
                        string dateTime = match.MatchDate.Value.ToString("dd-MMM-yyyy hh:mm");
                        matchXml.Add(new XAttribute("date-time", dateTime));
                    }
                }
                matchXml.Add(new XElement("home-country", match.CountryNameHome,
                    new XAttribute("code", match.CountryCodeHome)));
                matchXml.Add(new XElement("away-country", match.CountryNameAway,
                    new XAttribute("code", match.CountryCodeAway)));
                if (match.HomeGoals != null && match.AwayGoals != null)
                {
                    string score = match.HomeGoals.Value + "-" + match.AwayGoals.Value;
                    matchXml.Add(new XElement("score", score));
                }
                if (match.LeagueName != null)
                {
                    matchXml.Add(new XElement("league", match.LeagueName));
                }
                resultXml.Add(matchXml);
            }

            var resultXmlDoc = new XDocument();
            resultXmlDoc.Add(resultXml);
            resultXmlDoc.Save("international-matches.xml");

            Console.WriteLine("Matches exported to international-matches.xml");
        }
    }
}
