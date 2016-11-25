namespace JSONImports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DTOs;
    using MassDefect.Data;
    using MassDefect.Models;
    using Newtonsoft.Json;

    class Program
    {
        private const string ErrorMessage = @"Error: Invalid data.";
        private const string SolarSystemsPath = "../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../datasets/stars.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string PersonsPath = "../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../datasets/anomalies.json";
        private const string AnomaliesVictimsPath = "../../../datasets/anomaly-victims.json";

        static void Main()
        {

            MassDefectContext context = new MassDefectContext();
            // Injecting context for easier testing,
            // trading performance for better overall control
            // and improved maintainability
            // (IoC https://msdn.microsoft.com/en-us/library/ff921087.aspx?f=255&MSPPError=-2147217396)

            ImportSolarSystems(context);
            ImportStars(context);
            ImportPlanets(context);
            ImportPersons(context);
            ImportAnomalies(context);
            ImportAnomaliesVictims(context);

        }

        private static void ImportAnomaliesVictims(MassDefectContext context)
        {
            string jsonString = GetJsonString(AnomaliesVictimsPath);
            List<AnomaliesVictimsDTO> anomaliesVictimsDtos =
                JsonConvert.DeserializeObject<List<AnomaliesVictimsDTO>>(jsonString);
            foreach (var anomaliesVictimsDto in anomaliesVictimsDtos)
            {
                if (anomaliesVictimsDto.Id == 0 || string.IsNullOrEmpty(anomaliesVictimsDto.Person))
                {
                    Console.WriteLine(ErrorMessage);
                }
                else
                {
                    Person person = GetPersonByName(anomaliesVictimsDto.Person, context);
                    Anomaly anomaly = GetAnomalyById(anomaliesVictimsDto.Id, context);
                    if (person != null || anomaly != null)
                    {
                        anomaly.Victims.Add(person);
                    }
                }
            }
            context.SaveChanges();
        }
      
        private static void ImportAnomalies(MassDefectContext context)
        {
            string jsonString = GetJsonString(AnomaliesPath);
            List<AnomalyDTO> anomaliesDtos = JsonConvert.DeserializeObject<List<AnomalyDTO>>(jsonString);
            foreach (var anomaliesDto in anomaliesDtos)
            {
                if (string.IsNullOrEmpty(anomaliesDto.OriginPlanet) || string.IsNullOrEmpty(anomaliesDto.TeleportPlanet))
                {
                    Console.WriteLine(ErrorMessage);
                }
                else
                {
                    Anomaly anomaly = new Anomaly()
                    {
                        OriginPlanet = GetPlanetByName(anomaliesDto.OriginPlanet, context),
                        TeleportPlanet = GetPlanetByName(anomaliesDto.TeleportPlanet, context)
                    };
                    if (anomaly.OriginPlanet == null || anomaly.TeleportPlanet == null)
                    {
                        Console.WriteLine(ErrorMessage);
                    }
                    else
                    {
                        context.Anomalies.Add(anomaly);
                        Console.WriteLine("Successfully imported anomaly.");
                    }
                }
            }
            context.SaveChanges();
        }

        private static void ImportPersons(MassDefectContext context)
        {
            string jsonString = GetJsonString(PersonsPath);
            List<PersonDTO> personDtos = JsonConvert.DeserializeObject<List<PersonDTO>>(jsonString);
            foreach (var personDto in personDtos)
            {
                if (string.IsNullOrEmpty(personDto.Name) || string.IsNullOrEmpty(personDto.HomePlanet))
                {
                    Console.WriteLine(ErrorMessage);
                }
                else
                {
                    Person person = new Person()
                    {
                        Name = personDto.Name,
                        Planet = GetPlanetByName(personDto.HomePlanet, context)
                    };
                    if (person.Planet == null)
                    {
                        Console.WriteLine(ErrorMessage);
                    }
                    else
                    {
                        context.Persons.Add(person);
                        Console.WriteLine($@"Successfully imported Person {person.Name}");
                    }
                }
            }
            context.SaveChanges();
        }

        private static void ImportPlanets(MassDefectContext context)
        {
            string jsonString = GetJsonString(PlanetsPath);
            List<PlanetDTO> planetDtos = JsonConvert.DeserializeObject<List<PlanetDTO>>(jsonString);
            foreach (var planetDto in planetDtos)
            {
                if (string.IsNullOrEmpty(planetDto.Name) || string.IsNullOrEmpty(planetDto.SolarSystem) ||
                    string.IsNullOrEmpty(planetDto.Sun))
                {
                    Console.WriteLine(ErrorMessage);
                }
                else
                {
                    Planet planet = new Planet()
                    {
                        Name = planetDto.Name,
                        SolarSystem = GetSolarSystemByName(planetDto.SolarSystem, context),
                        Star = GetStarByName(planetDto.Sun, context)
                    };
                    if (planet.Star == null || planet.SolarSystem == null)
                    {
                        Console.WriteLine(ErrorMessage);
                    }
                    else
                    {
                        context.Planets.Add(planet);
                        Console.WriteLine($@"Successfully imported Planet {planetDto.Name}");
                    }
                }
            }
            context.SaveChanges();

        }

        private static void ImportStars(MassDefectContext context)
        {
            string jsonString = GetJsonString(StarsPath);
            List<StarDTO> starDtos = JsonConvert.DeserializeObject<List<StarDTO>>(jsonString);
            foreach (var starDto in starDtos)
            {
                if (string.IsNullOrEmpty(starDto.Name) || string.IsNullOrEmpty(starDto.SolarSystem))
                {
                    Console.WriteLine(ErrorMessage);
                }
                else
                {
                    Star star = new Star()
                    {
                        Name = starDto.Name,
                        SolarSystem = GetSolarSystemByName(starDto.SolarSystem, context)
                    };
                    if (star.SolarSystem == null)
                    {
                        Console.WriteLine(ErrorMessage);
                    }
                    else
                    {
                        context.Stars.Add(star);
                        Console.WriteLine($@"Successfully imported Star {starDto.Name}");
                    }
                }
            }
            context.SaveChanges();
        }

        private static void ImportSolarSystems(MassDefectContext context)
        {
            string jsonString = GetJsonString(SolarSystemsPath);
            List<SolarSystemDTO> solarSystemsDtos = JsonConvert.DeserializeObject<List<SolarSystemDTO>>(jsonString);
            foreach (var solarSystemDto in solarSystemsDtos)
            {
                if (string.IsNullOrEmpty(solarSystemDto.Name))
                {
                    Console.WriteLine(ErrorMessage);
                }
                else
                {
                    SolarSystem system = new SolarSystem()
                    {
                        Name = solarSystemDto.Name
                    };
                    context.SolarSystems.Add(system);
                    Console.WriteLine($@"Successfully imported Solar System {solarSystemDto.Name}");
                }
            }
            context.SaveChanges();
        }

        private static Planet GetPlanetByName(string planetName, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == planetName);
        }

        private static SolarSystem GetSolarSystemByName(string solarSystemName, MassDefectContext context)
        {
            return context.SolarSystems.FirstOrDefault(ss => ss.Name == solarSystemName);
        }

        private static Star GetStarByName(string starName, MassDefectContext context)
        {
            return context.Stars.FirstOrDefault(s => s.Name == starName);
        }

        private static Anomaly GetAnomalyById(int anomalyId, MassDefectContext context)
        {
            return context.Anomalies.Find(anomalyId);
        }

        private static Person GetPersonByName(string personName, MassDefectContext context)
        {
            return context.Persons.FirstOrDefault(p => p.Name == personName);
        }

        private static string GetJsonString(string path)
        {
            string jsonString = File.ReadAllText(path);
            return jsonString;
        }
    }
}
