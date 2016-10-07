using System;


namespace OddEvenSum
{
    class oddEven
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] coolAraya = new int[2*n];
            for (int j=0; j<coolAraya.Length; j++)
            {
                coolAraya[j] = int.Parse(Console.ReadLine());
            }
            int evenSum = 0;
            int oddSum = 0;
            int diff = 0;
            for (int i=0; i<coolAraya.Length; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    oddSum += coolAraya[i];
                }
                else
                {
                    evenSum += coolAraya[i];
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes, sum={0}", oddSum);
            }
            else
            {
                diff = Math.Abs(oddSum - evenSum);
                Console.WriteLine("No, diff={0}", diff);
            }
        }
    }
}
