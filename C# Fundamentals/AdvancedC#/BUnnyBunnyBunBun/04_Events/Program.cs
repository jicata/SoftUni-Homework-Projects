namespace _04_Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"^#([a-zA-Z]+[^\s]):(?:\s)*?@([a-zA-Z]+[^\s])(?:\s)*?((?:[0-1][0-9]|2[0-3]):[0-5][0-9])\b";
            Regex eventsMatcher = new Regex(pattern);
            //List<Event> events = new List<Event>();
            Dictionary<string, List<Event>> events = new Dictionary<string, List<Event>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (eventsMatcher.IsMatch(input))
                {
                    Match matches = eventsMatcher.Match(input);
                    string person = matches.Groups[1].ToString();
                    string location = matches.Groups[2].ToString();
                    string stringTime = matches.Groups[3].ToString();
                    var time = DateTime.ParseExact(stringTime, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay;

                    if (!events.ContainsKey(location))
                    {
                        events.Add(location, new List<Event>());
                        events[location].Add(new Event(person, time));
                    }
                    else if (events.ContainsKey(location) && !events[location].Any(x=>x.person ==person))
                    {
                        events[location].Add(new Event(person, time));
                    }
                    else if (events.ContainsKey(location) && events[location].Any(x => x.person == person))
                    {
                        var eventche = events[location].First(x => x.person == person);
                        eventche.times.Add(time);
                    }
                }
            }
            string[] locations = Console.ReadLine().Split(',');
            Array.Sort(locations);
            for (int i = 0; i < locations.Length; i++)
            {
                if (events.ContainsKey(locations[i]))
                {
                    int count = 1;
                    Console.WriteLine("{0}:",locations[i]);
                    foreach (var evend in events[locations[i]].OrderBy(x=>x.person))
                    {
                        var times = evend.times;
                        List<string> properTimes= new List<string>();
                        
                        foreach (var time in times)
                        {
                            string timeString = time.ToString();
                            string hrsMins = timeString.Substring(0, timeString.Length - 3);
                            properTimes.Add(hrsMins);
                           
                        }
                        properTimes.Sort();
                        Console.WriteLine("{0}. {1} -> {2}", count, evend.person, string.Join(", ", properTimes));
                        count++;
                    }
                }
                
            }
        }
    }

    public class Event
    {
        public string person;
        public List<TimeSpan> times= new List<TimeSpan>();

        public Event(string person, TimeSpan time)
        {
            this.person = person; 
            this.times.Add(time);
        }
    }
}
