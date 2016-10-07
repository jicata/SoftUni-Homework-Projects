using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leliaVanche
{
    class canSheMakeIt
    {
        static void Main()
        {
            //•	The number h (the required work hours to finish the project) is on the first input line.
            //•	The number d (the days available to finish the project) is on the second input line.
            //	The number p (the productivity in percent) is on the third input line
            Console.WriteLine("Enter the required work hours to finish the project: ");
            int requiredHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the days available to finish the project: ");
            int availableDays = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Lelia Vanche's productivity(it will be calculated in percentage): ");
            double mood = double.Parse(Console.ReadLine());
            double productivity = mood / 100d;
            double actualDays = Math.Abs(availableDays - (1d / 10d) * availableDays);
            double canSheMakeIt = Math.Floor((actualDays * 12) * productivity);
            Console.WriteLine(canSheMakeIt);
            if (canSheMakeIt < requiredHours)
            {
                Console.WriteLine(requiredHours - canSheMakeIt);
                Console.WriteLine("Sorry, Lelia Vanche, go back to the Jenski Pazar");
               
            }
            else
            {
                Console.WriteLine(canSheMakeIt - requiredHours);
                Console.WriteLine("Nice job Lelia Vanche! Have a Lukche");
            }
        }
    }
}
