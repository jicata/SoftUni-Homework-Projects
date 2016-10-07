namespace RightLeft
{
    using System;

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sum1 = 0;
            var sum2 = 0;
            for (int i = 1; i <= n*2; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (i <= n)
                {
                    sum1 += number;
                }
                else
                {
                    sum2 += number;
                }           
            }

            if (sum1 == sum2)
            {
                Console.WriteLine("Yes, sum = " + sum1);
            }
            else
            {
                var diff = 0;
                if (sum1 > sum2)
                {
                    diff = sum1 - sum2;
                }
                else
                {
                    diff = sum2 - sum1;
                }
                var absDiff = Math.Abs(sum2 - sum1);
                Console.WriteLine("No, diff = " + absDiff);
            }
        }
    }
}
