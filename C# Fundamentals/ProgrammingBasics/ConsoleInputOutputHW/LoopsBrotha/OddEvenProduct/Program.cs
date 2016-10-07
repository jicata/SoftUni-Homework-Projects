using System;


namespace OddEvenProduct
{
    class Program
    {
        static void Main()
        {
            string[] kindaCool = Console.ReadLine().Split();
            int[] coolArray = Array.ConvertAll(kindaCool, int.Parse);

            int evenProduct = 1;
            int oddProduct = 1;

            for (int i = 0; i < coolArray.Length; i++)
            {
                if (i == 0)
                {
                    oddProduct *= coolArray[i];
                }
                if (i == 1)
                {
                    evenProduct *= coolArray[i];
                }
                if (i> 1 && i % 2 == 0)
                {
                    oddProduct *= coolArray[i];
                    
                }
                else if (i > 1 && i % 2 > 0)
                {
                    evenProduct *= coolArray[i];
                }
            }
            if (evenProduct == oddProduct)
            {
                Console.WriteLine("Yes, {0}", evenProduct);
            }
            else
            {
                Console.WriteLine("No, odd product = {0}, even product = {1}", oddProduct, evenProduct);
            }
        }
    }
}
