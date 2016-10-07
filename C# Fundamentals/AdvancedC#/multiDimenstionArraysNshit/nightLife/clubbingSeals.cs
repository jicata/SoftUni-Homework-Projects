using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightLife
{
    class clubbingSeals
    {
        static void Main()
        {

            Dictionary<string, Dictionary<string, List<string>>> Cities = new Dictionary<string, Dictionary<string, List<string>>>();
            string userInput = Console.ReadLine();
            while (userInput != "END")
            {
                string[] allUserData = userInput.Split(';');
                string city = allUserData[0];
                string venue = allUserData[1];
                string perfomer = allUserData[2];

                if (!Cities.ContainsKey(city))
                {
                    Cities.Add(city, new Dictionary<string, List<string>>());
                    Cities[city].Add(venue, new List<string>());
                    Cities[city][venue].Add(perfomer);
                }
                else if(Cities.ContainsKey(city) && !Cities[city].ContainsKey(venue))
                {
                    Cities[city].Add(venue, new List<string>());
                    Cities[city][venue].Add(perfomer);
                    
                }
                if (Cities.ContainsKey(city) && Cities[city].ContainsKey(venue) && !Cities[city][venue].Contains(perfomer))
                {
                    Cities[city][venue].Add(perfomer);
                }
                userInput = Console.ReadLine();
                
                
            }

            foreach (string cityKeys in Cities.Keys)
            {
                Console.WriteLine(cityKeys);
                foreach (string venues in Cities[cityKeys].Keys)
                {
                    Console.Write("->{0}: ", venues);
                    
                    foreach (string performers in Cities[cityKeys][venues])
                    {
                        
                        Console.Write("{0} ", performers);
                        
                    }
                    if (Cities[cityKeys][venues].Count > 1)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }

    //Sofia;Biad;Preslava
    //Pernik;Stadion na mira;Vinkel
    //New York;Statue of Liberty;Krisko
    //Oslo;everywhere;Behemoth
    //Pernik;Letishteto;RoYaL
    //Pernik;Stadion na mira;Bankin
    //Pernik;Stadion na mira;Vinkel
    //END

            //Cities.Add(chep, new Dictionary<string,string>());
            //Cities[chep].Add("krisko", "beats");
            //Console.WriteLine(Cities[chep]["krisko"]);
        }
    }
}
