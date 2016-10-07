using System;

namespace naFacByXFac
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());

            int factorielOne = 1;
            int factorielTwo = 1;
            int division = 0;

            for(int i = 1; i <= n; i++)
            {
                factorielOne *= i;
                if(i <= x)
                {
                    factorielTwo *= i;
                }

               
                
            }
           
            division = factorielOne / factorielTwo;
            Console.WriteLine(division);
        }
    }
}
