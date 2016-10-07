using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.Olympics_Are_Coming
{
    class olimpiado
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            Dictionary<string,List<string>> countries = new Dictionary<string,List<string>>();
            while (userInput != "report")
            {
                string[] athletesCountries = userInput.Trim().Split('|');
                string athlete = Regex.Replace(athletesCountries[0].Trim(), @"\s+", " ");
                string country = Regex.Replace(athletesCountries[1].Trim(), @"\s+", " ");
                int wins = 1;


                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new List<string>());
                    
                    
                }
                countries[country].Add(athlete);
                userInput = Console.ReadLine();
            }
            


            var orderedCountryData = countries
             .OrderByDescending(x => x.Value.Count);

            foreach (KeyValuePair<string, List<string>> country in orderedCountryData)
            {
                Console.Write(country.Key);
                Console.Write(" ({0} participants): ", country.Value.Distinct().Count());
                Console.Write("{0} wins", country.Value.Count);
                Console.WriteLine();

            }
           
            
        }
    }
}
//Data = Data.OrderByDescending(x => x.Value["name"])
//           .ToDictionary(x => x.Key, x => x.Value);
