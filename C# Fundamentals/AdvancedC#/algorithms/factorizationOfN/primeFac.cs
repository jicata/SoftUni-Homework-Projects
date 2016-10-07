using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorizationOfN
{
    class primeFac
    {
        static void Main()
        {
            int userInput = int.Parse(Console.ReadLine());
            int legit = userInput;
            List<int> primeFactors = new List<int>();
            int divisor = 2;

            while (userInput != 1)
            {
                if (userInput % divisor == 0)
                {

                    primeFactors.Add(divisor);
                    userInput = userInput / divisor;
                    continue;
                }
                else
                {
                    divisor++;
                }
            }
            Console.Write("{0} = ", legit);
            Console.WriteLine(string.Join(" * ", primeFactors));

            //List<int> primes = GeneratePrimesNaive(userInput / 2);
            //List<int> primeFactors = new List<int>();
            //int divisor = 0;
            //for (int i = 0; i < primes.Count; i++)
            //{
            //    divisor = primes[i];
            //    if (userInput % divisor == 0)
            //    {
            //        primeFactors.Add(divisor);
            //        userInput = userInput / divisor;
                    
            //    }
                

            //}
            //Console.Write("{0} = ", legit);
            //Console.Write(string.Join(" * ", primeFactors));
            //Console.WriteLine();
            
        }
        public static List<int> GeneratePrimesNaive(int n)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }
    }
}
