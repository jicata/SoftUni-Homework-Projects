using System;


namespace by3and7
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int miniCounter = 1;

            while (miniCounter < n)
            {
                if (miniCounter % 3 == 0 || miniCounter % 7 == 0)
                {
                    miniCounter++;
                        continue;
                }
                else
                {
                    Console.Write(miniCounter + " ");
                    miniCounter++;
                }
                
            }
            
        }
    }
}
