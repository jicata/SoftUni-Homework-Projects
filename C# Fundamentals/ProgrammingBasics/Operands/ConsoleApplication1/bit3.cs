using System;


namespace ConsoleApplication1
{
    class bit3
    {
        static void Main()
        {
            bool flag = false;
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
            int p = int.Parse(Console.ReadLine());
            int moveIt = n >> p;
            int foundIt = moveIt & 1;
            if (foundIt == 1)
            {
                flag = true;
                Console.WriteLine(flag);
            }
            else
            {
                Console.WriteLine(flag);
            }
        }
    }
}
