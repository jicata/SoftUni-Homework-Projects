using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    using System.Globalization;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            int eventCount = int.Parse(Console.ReadLine());

            OrderedMultiDictionary<DateTime,string> eventsByDate = new OrderedMultiDictionary<DateTime, string>(true);

            for (int i = 0; i < eventCount; i++)
            {
                string[] eventAndDate = Console.ReadLine().Split('|');
                string eventName = eventAndDate[0];
               //DateTime date = DateTime.ParseExact(eventAndDate[1], "dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture);
                DateTime date = DateTime.Parse(eventAndDate[1]);
                if (!eventsByDate.ContainsKey(date))
                {
                    eventsByDate.Add(date, eventName);
                }
                else
                {
                   eventsByDate[date].Add(eventName);
                }

            }

            int rangeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < rangeCount; i++)
            {
                string[] dateRange = Console.ReadLine().Split('|');
                DateTime fromDate = DateTime.Parse(dateRange[0]);
                DateTime toDate = DateTime.Parse(dateRange[1]);
                var range = eventsByDate.Range(fromDate, true, toDate, true);
                foreach (var item in range)
                {

                    foreach (var innerItem in range[item.Key])
                    {
                        Console.WriteLine("{0} | {1:dd-MMM-yyyy}", innerItem, item.Key);
                    }

                }
            }
        }
    }
}
