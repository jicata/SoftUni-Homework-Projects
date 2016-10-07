using System;


namespace bitExchange
{
    class bitExchange
    {
        static void Main()
        {
            int numP, bit1, bit2, mask1, mask2;
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(16, '0'));
            //swap bits 3,4,5 with bits 24,25,26
            for (int i = 0; i < 3; i++)
            {
                numP = num >> (3 + i);
                bit1 = numP & 1;
                numP = num >> (24 + i);
                bit2 = numP & 1;

                bit1 = bit1 << (24 + i);
                bit2 = bit2 << (3 + i);

                mask1 = 1 << (24 + i);
                num = num & ~(mask1);

                mask2 = 1 << (3 + i);
                num = num & ~(mask2);

                num = num | bit1;
                num = num | bit2;

            }
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(16, '0'));
        }
    }
}
