using System;


namespace OddOrEven
{
    class oddity
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            bool odd = false;
            if (a % 2 == 0)
            {

                Console.WriteLine(odd);
            }
            else 
            {
                odd = true;
                Console.WriteLine(odd);
            }
        }
    }
}
