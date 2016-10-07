using System;
using System.Globalization;


namespace examSchedule
{
    class skeDule
    {
        static void Main()
        {
            
            string hour = Console.ReadLine();
            string minutes = Console.ReadLine();
            string timeOfTheDay = Console.ReadLine();
            string format = "h:m tt";
            string extraHours = Console.ReadLine();
            string extraMinutes = Console.ReadLine();

            int plusHours = int.Parse(extraHours);
            int plusMinutes = int.Parse(extraMinutes);

            string timeString = string.Format("{0}:{1} {2}", hour, minutes, timeOfTheDay);
            
            
            DateTime tryOut = DateTime.ParseExact(timeString, format, CultureInfo.InvariantCulture );
           
            DateTime finalHour = tryOut.AddHours(plusHours).AddMinutes(plusMinutes);
            
            string finalFormat = "hh:mm:tt";
            Console.WriteLine(finalHour.ToString(finalFormat));
        }
    }
}
