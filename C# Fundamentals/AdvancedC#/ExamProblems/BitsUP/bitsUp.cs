using System;


namespace BitExchange2
{
    class bitExchange2
    {
        static void Main()
        {
            int numberCount = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            int[] numbers = new int[numberCount];

         

            for (int i = 0; i < numberCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                string penis = Convert.ToString(numbers[i], 2).PadLeft(8, '0');
                Console.WriteLine(penis);
            }

            bool flag = false;
            int currentBit = step - 1;

            for (int count = 0; count < numbers.Length; count++)
            {
                for (int bit = 7; bit >= 0; bit--)
                {
                    if (!flag)
                    {
                        flag = true;
                        currentBit = step;
                        continue;
                    }
                    currentBit++;
                    if (currentBit >= step)
                    {
                        currentBit = 0;
                        int mask = 1 << bit;
                        numbers[count] = numbers[count] | mask;


                    }
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                string penis = Convert.ToString(numbers[i], 2).PadLeft(8, '0');
                Console.WriteLine(penis);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

        }
    }
}
