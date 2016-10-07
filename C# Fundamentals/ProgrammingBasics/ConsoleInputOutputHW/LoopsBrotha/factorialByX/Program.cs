using System;


namespace factorialByX
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());

            float factorial = 1;
            float sum = 1;

            int power = x;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
                sum += factorial / x;
                Console.WriteLine(sum);
                x *= power;
            }
            Console.WriteLine("{0:F5}", sum);
        }
    }
}
