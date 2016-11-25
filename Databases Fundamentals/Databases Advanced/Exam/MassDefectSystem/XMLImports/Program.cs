namespace XMLImports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using MassDefect.Data;
    using MassDefect.Models;

    class Program
    {
        private const string ErrorMessage = @"Error: Invalid data.";
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";
        static void Main()
        {
            MassDefectContext context = new MassDefectContext();
            XDocument newAnomaliesXml = XDocument.Load(NewAnomaliesPath);
            var anomalies = newAnomaliesXml.XPathSelectElements("anomalies/anomaly");
            ImportAnomalyAndVictims(anomalies, context);
        }

        private static void ImportAnomalyAndVictims(IEnumerable<XElement> anomalies, MassDefectContext context)
        {
            foreach (var anomalyXElement in anomalies)
            {
                var anomalyOriginPlanet = anomalyXElement.Attribute("origin-planet");
                var anomalyTeleportPlanet = anomalyXElement.Attribute("teleport-planet");
                if (anomalyOriginPlanet == null || anomalyTeleportPlanet == null)
                {
                    Console.WriteLine(ErrorMessage);
                }
                else
                {
                    var newAnomaly = new Anomaly()
                    {
                        OriginPlanet = GetPlanetByName(anomalyOriginPlanet.Value, context),
                        TeleportPlanet = GetPlanetByName(anomalyTeleportPlanet.Value, context)
                    };
                    if (newAnomaly.OriginPlanet == null || newAnomaly.TeleportPlanet == null)
                    {
                        Console.WriteLine(ErrorMessage);
                    }
                    else
                    {
                        var victims = anomalyXElement.XPathSelectElements("victims/victim");
                        bool validVictims = true;
                        foreach (var victimElement in victims)
                        {
                            validVictims = ImportVictim(victimElement, context, newAnomaly);
                            if (!validVictims)
                            {
                                break;
                            }
                        }
                        // will be hit only if ALL victims are valid
                        if (validVictims)
                        {
                            context.Anomalies.Add(newAnomaly);
                        }
                    }

                }
            }
           context.SaveChanges();
        }

        private static bool ImportVictim(XElement victimElement, MassDefectContext context, Anomaly newAnomaly)
        {
            var name = victimElement.Attribute("name");
            if (name == null)
            {
                Console.WriteLine(ErrorMessage);
                return false;
            }
            Person person = GetPersonByName(name.Value, context);
            if (person == null)
            {
                Console.WriteLine(ErrorMessage);
                return false;
            }
            Console.WriteLine("Successfully imported anomaly.");
            newAnomaly.Victims.Add(person);
            return true;
        }

        private static Person GetPersonByName(string personName, MassDefectContext context)
        {
            return context.Persons.FirstOrDefault(p => p.Name == personName);
        }

        private static Planet GetPlanetByName(string planetName, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == planetName);
        }
    }
}
