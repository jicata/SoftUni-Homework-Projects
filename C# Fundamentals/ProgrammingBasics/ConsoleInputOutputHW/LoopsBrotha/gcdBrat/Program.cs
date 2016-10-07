using System;


namespace gcdBrat
{
    class Program
    {
        static void Main()
        {
            // a b, a % b = mod ,a - b * mod = result, b % result = mod, b - result * mod
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int firstNumber = Math.Abs(a);
            int secondNumber = Math.Abs(b);
            int result = 0;
            int mod = 1;
            while (mod != 0)
            {
                if (firstNumber != 0 && secondNumber != 0)
                {
                    if (firstNumber > secondNumber)
                    {
                        mod = firstNumber / secondNumber;
                        result = firstNumber - secondNumber * mod;
                        firstNumber = secondNumber;
                        secondNumber = result;
                    }
                    else if (secondNumber > firstNumber)
                    {
                         mod = secondNumber / firstNumber;
                        result = secondNumber - firstNumber * mod;
                        secondNumber = firstNumber;
                        firstNumber = result;
                    }
                    
                }


                if (result == 0)
                {
                    if (a > b)
                    {
                        Console.WriteLine(firstNumber);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(firstNumber);
                        break;
                    }
                }
            }
               
            
            
            
            
        }
    }
}
