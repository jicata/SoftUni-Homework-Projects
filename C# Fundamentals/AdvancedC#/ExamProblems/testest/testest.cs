using System;


namespace wiggleWiggle
{
    class Program
    {
        static void Main()
        {
            int n = 187;
            int pos1 = 0;
            int bin1 = 1;
            int mask1 = 0;
            int count = 0;
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(8, '0'));

            for (int i = 0; i < 7; i++)
            {
                
                if (i == 0 || i % 2 == 0)
                {
                    pos1 = n >> i;
                    Console.WriteLine(Convert.ToString(pos1, 2).PadLeft(8, '0'));
                    bin1 = pos1 & 1;
                    Console.WriteLine(Convert.ToString(bin1, 2).PadLeft(8, '0'));
                    bin1 = bin1 << i;
                    Console.WriteLine(Convert.ToString(bin1, 2).PadLeft(8, '0'));
                    mask1 = bin1 | mask1;
                   
                    Console.WriteLine(Convert.ToString(mask1, 2).PadLeft(8, '0'));
                    bin1 = 1;
                    pos1 = 0;
                }
                count++;
            }
        }
    }
}
