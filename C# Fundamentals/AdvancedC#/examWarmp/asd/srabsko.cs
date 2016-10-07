using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace asd
{
    class srabsko
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            int totalTickets = 0;
            string pattern = @"(\w*(?:\s\w+)+)\s\@(\D+)\s(\d+)\s(\d+)";
            //@"(\D+)\s\@(\D+)\s(\d+)\s(\d+)"
            string venue = string.Empty;
            string performer = string.Empty;
            
            Dictionary<string, Dictionary<string, int>> venues = new Dictionary<string, Dictionary<string, int>>();

            while(userInput !="End")
            {
                var rgx = new Regex(pattern);
                Match match = rgx.Match(userInput);
                if (match.Success)
                {
                    venue = match.Groups[2].Value;
                    performer = match.Groups[1].Value;
                    totalTickets = int.Parse(match.Groups[3].Value) * int.Parse(match.Groups[4].Value);
                    if (!venues.ContainsKey(venue))
                    {
                        venues.Add(venue,new Dictionary<string, int>());
                    }
                    if (!venues[venue].ContainsKey(performer))
                    {
                        venues[venue].Add(performer, 0);
                    }
                  
                    venues[venue][performer] += totalTickets;
                    
                    
                }
                userInput = Console.ReadLine();
            }



            //from innerPair in outerPair.Value
            //orderby innerPair.Value
            //select new {
            //    OuterKey = outerPair.Key,
            //    InnerKey = innerPair.Key,
            //    Value = innerPair.Value
            //foreach (var pair in eventsInfo)
            //{
            //    Console.WriteLine(pair.Key);
            //    foreach (var concertInfo in pair.Value.OrderByDescending(c => c.Value))
            //    {
            //        Console.WriteLine("#  {0} -> {1}", concertInfo.Key, concertInfo.Value);
            //    }
            //}

            foreach (var pair in venues)
            {
                Console.WriteLine(pair.Key);
                var innerkey = pair.Value;
                
                foreach (var deep in innerkey.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  {0} -> {1}",deep.Key, deep.Value);
                }
                
            }
        }
    }
}
