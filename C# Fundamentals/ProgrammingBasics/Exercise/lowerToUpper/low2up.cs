using System;
using System.Globalization;

namespace lowerToUpper
{
    class low2up
    {
        static void Main()
        {
            string input = Console.ReadLine();
            

            foreach (char i in input)
            {
                int ascii = (int)i;
                if (ascii % 3 ==0)
                {
                    input[i].ToUpper(CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
