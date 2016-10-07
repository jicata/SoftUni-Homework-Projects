using System;


namespace VladiTheVolley
{
    class volleyballer
    {
        static void Main()
        {
            // Vladi loves a lot to play volleyball. However, he is a programmer now and he is very busy. Now he is able to play only in the holidays and in the weekends.
            // Vladi plays in 2/3 of the holidays and each Saturday, but not every weekend – only when he is not at work and only when he is not going to his hometown.
            // Vladi goes at his hometown h weekends in the year. The other weekends are considered “normal”. Vladi is not at work in 3/4 of the normal weekends.
            // When Vladi is at his hometown, he always plays volleyball with his old friends once, at Sunday. 
            // In addition, if the year is leap, Vladi plays volleyball 15% more times additionally. We assume the year has exactly 48 weekends suitable for volleyball.
            string typeOfYear = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int timeAtHome = int.Parse(Console.ReadLine());

            double holidayPlay = 2d / 3d * holidays;
            double normalPlayTime = 0.75 * (48.00 - timeAtHome);
            double totalPlayTime = holidayPlay + timeAtHome + normalPlayTime;

            double leap = (15d / 100d * (totalPlayTime));


            if (typeOfYear == "leap")
            {
                Console.WriteLine(Math.Floor(totalPlayTime +leap));
            }
            else
            {
                Console.WriteLine(Math.Floor(totalPlayTime));
            }
           

            // (2/3*holidays) + timeAtHome + 3/4* (total weeks (48) - timeAthome - holidays)

        }
    }
}
