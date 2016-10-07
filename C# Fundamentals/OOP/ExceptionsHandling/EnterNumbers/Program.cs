using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int start = 0;
            int end = 100;
            int[] numbers = new int[10];
            int counter = 0;
            int lastNumber = start;
            while (counter < 10)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    Console.WriteLine("Please enter a number in the range {0} - {1}", lastNumber, end);
                    Console.WriteLine("Numbers entered so far: {0}", counter);
                    
                    int number = EnterNumber(start, end);
                    if (number > lastNumber)
                    {
                        numbers[counter] = number;
                        lastNumber = number;
                    }
                    else
                    {
                        
                        throw new ArgumentException(String.Format("Entered number must be larger than last number - {0}", lastNumber));
                    }
                    
                    counter++;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message+"\n");
                    
                }
            }
            
        }

       
        public static int EnterNumber(int start, int end)
        {
            int lastNumber = 0;

            string console = Console.ReadLine();
            int penis;
            bool num = int.TryParse(console, out penis);
            if (!num)
            {
                throw new ArgumentException("Please enter a valid integer");
            }
            if (num)
            {
                int numm = int.Parse(console);
                if (numm < start || numm > end)
                {
                    throw new ArgumentException(String.Format("Integer must be after start({0}) and before end({1})",start, end));
                }
                
            }
            return int.Parse(console);

        }
    }
}
