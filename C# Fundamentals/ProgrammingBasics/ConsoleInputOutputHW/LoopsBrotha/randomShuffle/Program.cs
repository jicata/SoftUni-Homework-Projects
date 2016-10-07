using System;


namespace randomShuffle
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            Random seriozno = new Random();

            for (int i = 0; i < n; i++)
			{
                numbers[i] = i+1;
			}
            for (int t = 0; t < numbers.Length; t++)
            {
                
                int tmp = numbers[t];
                int r = seriozno.Next(t, numbers.Length);
                numbers[t] = numbers[r];
                numbers[r] = tmp;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            
        }
    }
}
