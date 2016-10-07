using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace junkjunk
{
    class Program
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> populationCounter = new Dictionary<string, Dictionary<string, int>>();
            while (userInput != "report")
            {
                string[] userProvidedData = userInput.Split('|');
                string country = userProvidedData[1];
                string city = userProvidedData[0];
                int population = int.Parse(userProvidedData[2]);
                if (!populationCounter.ContainsKey(country))
                {
                    populationCounter.Add(country, new Dictionary<string, int>());
                    populationCounter[country].Add(city, population);
                }
              else if (populationCounter.ContainsKey(country))
                {
                    populationCounter[country].Add(city, population);
                }
               
                
                userInput = Console.ReadLine();
            }
            var sorted = populationCounter.OrderByDescending(x => x.Value.Sum(y => y.Value));
            foreach (var pair in sorted) 
            {
                Console.WriteLine("{0} (total population: {1})", pair.Key, pair.Value.Sum(x=>x.Value));
                foreach (var deep in pair.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine("=>{0}: {1}", deep.Key, deep.Value);
                }
            }
        }
        
    }
}
