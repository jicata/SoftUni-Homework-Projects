using System;


namespace oddEvenSumMinMax
{
    class maxiMix
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

            string firstInput = Console.ReadLine();
            string[] inputNumbers = firstInput.Split();
            if (firstInput == "")
            {
                inputNumbers = new string[0];
            }

            

            decimal oddMin = int.MaxValue;
            decimal oddMax = int.MinValue;
            decimal oddSum = 0;

            decimal evenMin = int.MaxValue;
            decimal evenMax = int.MinValue;
            decimal evenSum = 0;
            bool flag = true;


           

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                decimal chepan = decimal.Parse(inputNumbers[i]);
                if (flag)
                {
                    oddSum += chepan;
                    oddMin = Math.Min(oddMin, chepan);
                    oddMax = Math.Max(oddMax, chepan);
                }
                else
                {
                    evenSum += chepan;
                    evenMin = Math.Min(evenMin, chepan);
                    evenMax = Math.Max(evenMax, chepan);
                }
                flag = !flag;
            }

           
            if (inputNumbers.Length == 0)
            {
                Console.WriteLine(
                    "OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
                return;
            }

            // float[] numbers = Array.ConvertAll(inputNumbers, float.Parse);

            if (inputNumbers.Length <= 1)
            {
                decimal chep = decimal.Parse(inputNumbers[0]);
                decimal exceptionOddSum = chep;
                decimal exceptionOddMin = chep;
                decimal exceptionOddMax = chep;
                Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum=No, EvenMin=No, EvenMax=No", (double)exceptionOddSum, (double)exceptionOddMin, (double)exceptionOddMax);
                return;
            }
            Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum={3:0.##}, EvenMin={4:0.##}, EvenMax={5:0.##}", (double)oddSum, (double)oddMin, (double)oddMax,
                   (double)evenSum, (double)evenMin, (double)evenMax);
        }
    }
}
