using System;


namespace bitExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pos = int.Parse(Console.ReadLine());
            int value = int.Parse(Console.ReadLine());
            int bit1 = 1;

            Console.WriteLine(Convert.ToString(n, 2).PadLeft(8, '0'));
            if (value == 0)
            {
                bit1 = bit1 << pos;
                Console.WriteLine(Convert.ToString(bit1, 2).PadLeft(8, '0'));
                Console.WriteLine(Convert.ToString(~bit1, 2).PadLeft(8, '0'));
                n = n & ~(bit1);
                Console.WriteLine(Convert.ToString(n, 2).PadLeft(8, '0'));
            }
            else
            {
                bit1 = bit1 << pos;
                Console.WriteLine(Convert.ToString(bit1, 2).PadLeft(8, '0'));
                n = n | bit1;
                Console.WriteLine(Convert.ToString(n, 2).PadLeft(8, '0'));
            }
            Console.ReadLine();

            
        }
    }
}
