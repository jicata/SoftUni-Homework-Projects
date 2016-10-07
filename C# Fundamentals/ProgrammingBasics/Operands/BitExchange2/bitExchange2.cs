using System;


namespace BitExchange2
{
    class bitExchange2
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine()); // the number
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
            int p = int.Parse(Console.ReadLine()); // position 1
            int q = int.Parse(Console.ReadLine()); // position 2
            int k = int.Parse(Console.ReadLine()); // range
            

            if (p <= 0 || q <= 0)
            {
                Console.WriteLine("Out of range");
                return;
            }

            if (p > q)
            {
                if (p - q < k)
                {
                    Console.WriteLine("No way, jose! - Overlap is imminent");
                    return;
                }
            }
            else if (p < q)
            {
                if (q - p < k)
                {
                    Console.WriteLine("No way, jose! - Overlap is iminent");
                    return;
                }
            }
            

            long numP, bit1, bit2, mask1, mask2;
            for (int i = 0; i<k; i++)
            {
                numP = n >> (p + i);
                bit1 = numP & 1;

                numP = n >> (q + i);
                bit2 = numP & 1;

                bit1 = bit1 << (q + i);
                bit2 = bit2 << (p + i);

                mask1 = 1 << (q + i);
                n = n & ~(mask1);

                mask2 = 1 << (p + i);
                n = n & ~(mask2);

                n = n | bit1;
                n = n | bit2;



            }
            Console.WriteLine(n);
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
        }
    }
}
