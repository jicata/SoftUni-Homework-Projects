using System;


namespace JoroTheFootballer
{
    class Joro
    {
        static void Main()
        {
            //. Now he is able to play only in the holidays and in the weekends. Joro plays in 1/2 of the holidays and twice in the weekends: each Saturday and each Sunday, 
            // but not every weekend – only when he is not tired and only when he is not going to his hometown. Joro goes at his hometown h weekends in the year. 
            // The other weekends are considered “normal”. Joro is not tired in 1/3 of the normal weekends. When Joro is at his hometown, he always plays football with his old friends once, at Sunday. 
            // In addition, if the year is leap, Joro plays football 3 more times additionally, in non-weekend days. We assume the year has exactly 52 weekends.

            //•	The string “t” for leap year or “f” for year that is not leap.
            //•	The number p – number of holidays in the year (which are not Saturday or Sunday).
            //•	The number h – number of weekends that Joro spends in his hometown.
            //•	The numbers p is in range [0...300] and h is in range [0…52].
            Console.WriteLine("Leap (t) or not (f): ");
            string leap = Console.ReadLine();
            Console.WriteLine("Holidays: ");
            int holidays = int.Parse(Console.ReadLine());
            Console.WriteLine("Weekends home: ");
            int weekendsHome = int.Parse(Console.ReadLine());
            int totalWeekdays = 52 - weekendsHome;

            double TotalPlayDays =
                holidays * 1d / 2d +
                weekendsHome +
                totalWeekdays * 2d / 3d;
            if (leap == "t")
            {
                TotalPlayDays = TotalPlayDays + 3;
            }
            Console.WriteLine("Total play days: ");
            Console.WriteLine((int)TotalPlayDays);

        }
    }
}
