using System;


namespace bookProblem
{
    class bookWorm
    {
        static void Main()
        {
            long pages = long.Parse(Console.ReadLine());
            long campDays = long.Parse(Console.ReadLine());
            long pagesPerDay = long.Parse(Console.ReadLine());
            long daysInMonth = 30;
            long readingDaysInMonth = daysInMonth - campDays;

            

            if (readingDaysInMonth == 0)
            {
                Console.WriteLine("never");
                return;
            }
            double pagesPerMonth = readingDaysInMonth * pagesPerDay;
            double pagesEveryMonth = pages / pagesPerMonth;
            
            if (pagesPerMonth> pages || pagesPerMonth == pages)
            {
                
                Console.WriteLine("{0:0} years {1:0} months", 0, 1);
            }
            else
            {
                

                Console.WriteLine("{0:0} years {1:0} months", Math.Floor(pagesEveryMonth / 12), Math.Ceiling(pagesEveryMonth % 12));
                
            }
               
           

            // pages / (daysInMonth - campDays) * pagesPerDay
            // pagesPerMonth
        }
    }
}
