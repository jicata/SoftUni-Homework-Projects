using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class sqrt
    {
        static void Main(string[] args)
        {
            
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n <= 0)
                {
                    throw new ArgumentException("Invalid number");
                }
                Console.WriteLine(Math.Sqrt((double)n));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
