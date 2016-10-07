using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace diffBtwnDates
{
    class diffDates
    {
        static void Main()
        {
            
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();
            string format = "d.M.yyyy";

            DateTime firstDate = DateTime.ParseExact(firstInput, format, CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondInput, format, CultureInfo.InvariantCulture);

            Console.WriteLine(firstDate);
            Console.WriteLine(secondDate);
            TimeSpan spanOne = secondDate - firstDate;
          
            double totalSpan = 0;
            if (firstDate != secondDate)
            {
                totalSpan = spanOne.Days;
                Console.WriteLine(totalSpan);
            }
            else 
            {
                Console.WriteLine("0");
            }
           
           
        }
    }
}
