using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> countryData = new Dictionary<string, Dictionary<string, long>>();
            while(line!="report")
            {
                var lineArgs = line.Split('|');
                string city = lineArgs[0];
                string country = lineArgs[1];
                long population = long.Parse(lineArgs[2]);
                line = Console.ReadLine();
                
                if(!countryData.ContainsKey(country))
                {
                    countryData[country] = new Dictionary<string, long>();
                }
                countryData[country].Add(city, population);
                
            }

            //foreach (var pair in countryData.OrderByDescending(c=> c.Value["Total population"]))
            //{
            //    Console.WriteLine(("{0} (total population: {1})", pair.Key, pair.Value["total population"]);
            //    foreach (var item in collection)
            //{
		 
	        }
            }
        }
    }
}
