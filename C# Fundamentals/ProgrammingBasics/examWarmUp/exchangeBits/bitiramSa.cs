using System;


namespace exchangeBits
{
    class bitiramSa
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int bit1;
            int pos1;
            int bit2;
            int pos2;
            int mask1;
            int mask2;

            for (int i = 3; i < 6; i++)
            {
                pos1 = n >> i;
                bit1 = pos1 & 1;

                pos2 = n >> 21 + i;
                bit2 = pos2 & 1;

                bit1 = bit1 << 21 + i;
                bit2 = bit2 << i;

                mask1 = 1 << 21 + i;
                n = n & ~(mask1);

                mask2 = 1 << i;
                n = n & ~(mask2);

                n = n | bit1;
                n = n | bit2;



            }
            Console.WriteLine(n);
        }
    }
}
