using System;


namespace playCards
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            char[] suite = { '\u2663', '\u2666', '\u2665', '\u2660' };

            for (int i = 2; i < 15; i++)
            {
                for (int j = 0; j < suite.Length; j++)
                {
                   switch (i)
                   {
                       case 2:
                       case 3:
                       case 4:
                       case 5:
                       case 6:
                       case 7:
                       case 8:
                       case 9:
                       case 10:
                           {
                               Console.Write("{0}{1} ", i, suite[j]);
                               
                               break;
                               
                           }
                       case 11:
                           Console.Write("{0}{1} ", "J", suite[j]);
                           break;
                       case 12:
                           Console.Write("{0}{1} ", "Q", suite[j]);
                           break;
                       case 13:
                           Console.Write("{0}{1} ", "K", suite[j]);
                           break;
                       case 14:
                           Console.Write("{0}{1} ", "A", suite[j]);
                           break;
                           
                   }
                   
                }
                Console.WriteLine();
            }
        }
    }
}
