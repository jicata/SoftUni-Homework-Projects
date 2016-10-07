using System;


namespace MoonGrav
{
    class MoonGrav
    {
        static void Main()
        {
            double earthWeight = double.Parse(Console.ReadLine());
            double Lunar = 17d / 100d;
            Console.WriteLine(earthWeight * Lunar);

        }
    }
}
