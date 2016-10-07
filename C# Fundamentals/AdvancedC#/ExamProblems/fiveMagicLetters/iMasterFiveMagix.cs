using System;


namespace fiveMagicLetters
{
    class iMasterFiveMagix
    {
        static void Main()
        {

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            //weight('a') = 5; weight('b') = -12;  weight('c') = 47;  weight('d') = 7;  weight('e') = -32. 
            //The weight of a sequence of letters c1c2…cn is the calculated by first removing all repeating letters (from right to left) and then calculate the formula:
            //1*weight(c1) + 2*weight(c2) + … + n*weight(cn)

            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    for (int c = 0; c < 4; c++)
                    {
                        for (int d = 0; d < 4; d++)
                        {
                            for (int e = 0; e < 4; e++)
                            {
                                string chep = string.Format("{0}{1}{2}{3}", a, b, c, d);
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
