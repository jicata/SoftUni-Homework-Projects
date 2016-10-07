namespace SRABSKO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    class Program
    {
        public static void Main()
        {
            string pattern = @"(\D+)\s@(\D+)\s(\d+)\s(\d+)";
            Regex matcher = new Regex(pattern);
            Dictionary<string, List<SrabskiSinger>> singersByVenue = new Dictionary<string, List<SrabskiSinger>>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (matcher.IsMatch(input))
                {
                    var match = matcher.Match(input);
                    string name = match.Groups[1].ToString();
                    string venue = match.Groups[2].ToString();
                    int ticketPrice = int.Parse(match.Groups[3].ToString());
                    int ticketsSold = int.Parse(match.Groups[4].ToString());
                    long moneyMade = ticketsSold*ticketPrice;

                    if (!singersByVenue.ContainsKey(venue))
                    {
                        singersByVenue.Add(venue, new List<SrabskiSinger>());
                        singersByVenue[venue].Add(new SrabskiSinger(name, moneyMade));
                    }
                    else if (singersByVenue.ContainsKey(venue) && !singersByVenue[venue].Any(s => s.Name == name))
                    {
                        singersByVenue[venue].Add(new SrabskiSinger(name, moneyMade));
                    }
                    else if(singersByVenue.ContainsKey(venue) && singersByVenue[venue].Any(s => s.Name == name))
                    {
                        SrabskiSinger singer = singersByVenue[venue].FirstOrDefault(x => x.Name == name);
                        singer.MoneyMade += moneyMade;

                    }
                }

                input = Console.ReadLine();
            }
            foreach (var venues in singersByVenue.Keys)
            {
                Console.WriteLine(venues);
                foreach (var singer in singersByVenue[venues].OrderByDescending(x=>x.MoneyMade))
                {
                    Console.WriteLine(singer);
                }
            }
        }
    }

    public class SrabskiSinger
    {
        private string name;
        private long moneyMade;

        public SrabskiSinger(string name, long moneyMade)
        {
            this.Name = name;
            this.MoneyMade = moneyMade;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public long MoneyMade
        {
            get
            {
                return moneyMade;
            }

            set
            {
                moneyMade = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("#  {0} -> {1}", this.Name, this.MoneyMade);
            return result;
        }
    }
}
