using System;


namespace advancedIntegers
{
    class advancedIntegeers
    {
        static void Main()
        {
            Random randomElement = new Random();
            int[] coolArray = new int[10];
            int chep = 0;
            for (int i = 0; i < coolArray.Length; i++)
            {
                int element = randomElement.Next(1, 101);
                coolArray[i] = element;

                Console.WriteLine(coolArray[i]);
            }
            Console.WriteLine();
            for (int j = 0; j < coolArray.Length-1; j++)
            {
                chep += coolArray[j];
                coolArray[j] = chep;
                Console.WriteLine(coolArray[j]);
            }
            

        }
    }
}
