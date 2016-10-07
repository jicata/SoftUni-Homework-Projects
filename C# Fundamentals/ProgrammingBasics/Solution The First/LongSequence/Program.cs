using System;
using System.Text;

namespace LongSequence
{
    class Sequencing
    {
        static void Main()
        {
            StringBuilder NumberToPrint = new StringBuilder();
            for (int i = 2; i < 1002; i++)
            {
                if (i % 2 == 0)
                {
                   NumberToPrint.AppendLine(i.ToString());
                }
                else
                {
                   
                    NumberToPrint.AppendLine((i*(-1)).ToString());
                }
               
            }
            Console.Write(NumberToPrint);
            Console.ReadLine();
        }
    }
}
