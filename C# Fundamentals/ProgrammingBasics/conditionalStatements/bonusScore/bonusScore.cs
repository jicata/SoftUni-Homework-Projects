using System;


namespace bonusScore
{
    class bonusScore
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            if (a==0 || a < 0 || a >9)
            {
                Console.WriteLine("Invalid score");
                return;

            }
            if (a<=3)
            {
                Console.WriteLine(a*10);

            }
            else if (a >= 4 && a <= 6)
            {
                Console.WriteLine(a * 100);
            }
            else if (a >= 7 && a <= 9)
            {
                Console.WriteLine(a * 1000);
            }
        }
    }
}
