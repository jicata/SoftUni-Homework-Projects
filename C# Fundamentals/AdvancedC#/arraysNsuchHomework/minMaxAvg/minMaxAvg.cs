using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minMaxAvg
{
    class minMaxAvg
    {
        static void Main()
        {
           int n = int.Parse(Console.ReadLine());

           int i = 0;
           float f = 0;
           List<int> intNumbers = new List<int>();
           int max = int.MinValue;
           int min = int.MaxValue;
           int avg = 0;
           

           List<float> floatNumbers = new List<float>();
           float maxF = float.MinValue;
           float minF = float.MaxValue;
           float avgF = 0;
           

           for (int j = 0; j < n; j++)
           {
               string userInput = Console.ReadLine();
               if (int.TryParse(userInput, out i))
               {
                   intNumbers.Add(i);
               }
               else if(float.TryParse(userInput, out f))
               {
                   if ((int)f == f)
                   {
                       intNumbers.Add((int)f);
                      
                   }
                   else
                   {
                       floatNumbers.Add(f);
                   }
                  

               }

           }
           foreach (int number in intNumbers)
           {
               avg += number;
               if (number > max)
               {
                   max = number;
               }
               if (number < min)
               {
                   min = number;
               }
           }
           foreach (float number in floatNumbers)
           {
               avgF += number;
               if(number > maxF)
               {
                   maxF = number;

               }
               if (number < minF)
               {
                   minF = number;
               }
           }
           
           Console.WriteLine("Max  = {0}, Min = {1}, Sum = {2}. Avg = {3:f2}", max, min, avg, avg/intNumbers.Count);
           Console.WriteLine("Max  = {0}, Min = {1}, Sum = {2}, Avg = {3:f2}", maxF, minF, avgF, avgF / floatNumbers.Count);



          

        }
    }
}
