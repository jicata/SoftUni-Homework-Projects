namespace DataExport
{
    using System;
    using System.IO;
    using System.Linq;
    using MassDefect.Data;
    using Newtonsoft.Json;

    class Program
    {
        static void Main()
        {
            MassDefectContext context = new MassDefectContext();
            ExportPlanetsWhichAreNotAnomalyOrigins(context);
            ExportPeopleWhichHaveNotBeenVictims(context);
            ExportTopAnomaly(context);
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var topAnomaly =
                context.Anomalies.OrderByDescending(a => a.Victims.Count)
                    .Take(1)
                    .Select(
                        a =>
                            new
                            {
                                id = a.Id,
                                originPlanet = new {name = a.OriginPlanet.Name},
                                teleportPlanet = new {name = a.TeleportPlanet.Name},
                                victimsCount = a.Victims.Count
                            });
            string jsonString = JsonConvert.SerializeObject(topAnomaly, Formatting.Indented);
            File.WriteAllText("../../anomaly.json", jsonString);
        }

        private static void ExportPeopleWhichHaveNotBeenVictims(MassDefectContext context)
        {
            var peopleThatAreNotVictims =
                context.Persons.Where(p => !p.Anomalies.Any())
                    .Select(p => new {name = p.Name, homePlanet = new {name = p.Planet.Name} });
            string jsonString = JsonConvert.SerializeObject(peopleThatAreNotVictims, Formatting.Indented);
            File.WriteAllText("../../people.json", jsonString);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var planets = context.Planets.Where(p => !p.AnomaliesOriginPlanet.Any()).Select(p => new { name = p.Name}).ToList();
            string jsonString = JsonConvert.SerializeObject(planets, Formatting.Indented);
            File.WriteAllText("../../planets.json", jsonString);
        }
    }
}
