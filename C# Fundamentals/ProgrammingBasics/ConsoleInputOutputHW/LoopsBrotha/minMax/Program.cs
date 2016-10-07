using System;


namespace minMax
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int max = int.MinValue;
            int min = int.MaxValue;
            Console.WriteLine(min);
            double sum = 0;
            double average = 0;

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (x > max)
                {
                    max = x;
                }
                if (x < min)
                {
                    min = x;
                }
                sum += x;

            }
            

           
            average = (double) sum / n;
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(sum);
            Console.WriteLine("{0:0.00}", average);
        }
    }
}
