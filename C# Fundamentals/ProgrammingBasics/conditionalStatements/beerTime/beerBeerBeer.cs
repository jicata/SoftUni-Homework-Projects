using System;
using System.Globalization;


namespace beerTime
{
    class beerBeerBeer
    {
        static void Main()
        {
            string enterTime = Console.ReadLine();
            string format = "h:mm tt";

            DateTime dateTime = DateTime.Parse(enterTime);

            TimeSpan start = TimeSpan.Parse("13:00"); // 1 PM
            TimeSpan end = TimeSpan.Parse("3:00");   // 3 AM
            TimeSpan now = dateTime.TimeOfDay;

            if (start <= end)
            {
                // start and stop times are in the same day
                if (now >= start && now <= end)
                {
                    // current time is between start and stop
                }
            }
            else
            {
                // start and stop times are in different days
                if (now >= start || now <= end)
                {
                    Console.WriteLine("beer");
                }
            }
            
            

            

            
        }
    }
}
