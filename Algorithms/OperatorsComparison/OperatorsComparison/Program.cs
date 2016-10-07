using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = {2, 2};
           
            long[] longs = {2, 2};
           
            double[] doubles = {2, 2};

            float[] floats = {2, 2};
            
            decimal[] decimals = {2, 2};
            
            

            System.Diagnostics.Stopwatch clock = new Stopwatch();

            //complex operations
            while (true)
            {
                double result = 0;
                TimeSpan ts = new TimeSpan();

                var leArray = decimals; //switch between arrays here


                for (int i = 0; i < 1000; i++)
                {
                     
                    clock.Start();
                    result = Math.Sqrt((double)leArray[0]); //decimals need casting
                    clock.Stop();
                    ts += clock.Elapsed;
                }

                Console.WriteLine("Math.Sqrt: " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;

                for (int i = 0; i < 1000; i++)
                {
                    clock.Start();
                    result = Math.Log((double)leArray[0]); //decimals need casting
                    clock.Stop();
                    ts += clock.Elapsed;
                }

                Console.WriteLine("Math.Log: " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;

                for (int i = 0; i < 1000; i++)
                {
                    clock.Start();
                    result = Math.Sin((double)leArray[0]); //decimals need casting
                    clock.Stop();
                    ts += clock.Elapsed;
                }

                Console.WriteLine("Math.Sin: " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;
                break;
            }
            return;
            //simple operations
            while (true)
            {
                decimal result = 0;
                TimeSpan ts = new TimeSpan();
                
                var leArray = decimals; //switch between arrays here
              
                
                for (int i = 0; i < 1000; i++)
                {
                    clock.Start();
                    result = leArray[0] + leArray[1];
                    clock.Stop();
                    ts += clock.Elapsed;
                }
                
                Console.WriteLine("+: " + ts.TotalMilliseconds/1000);
                ts = new TimeSpan();
                result = 0;

             
                for (int i = 0; i < 1000; i++)
                { 
                    clock.Start();
                    result = leArray[0] - leArray[1];
                    clock.Stop();
                    ts += clock.Elapsed;
                }
               
                Console.WriteLine("-: " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;

                
                for (int i = 0; i < 1000; i++)
                {
                    clock.Start();
                    ++leArray[0];
                    clock.Stop();
                    ts += clock.Elapsed;
                }
               
                Console.WriteLine("++(pre): " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;



                for (int i = 0; i < 1000; i++)
                { 
                    clock.Start();
                    leArray[0]++;
                    clock.Stop();
                    ts += clock.Elapsed;
                }
                
                Console.WriteLine("++(post): " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;


                for (int i = 0; i < 1000; i++)
                {
                    clock.Start();
                    leArray[0] += 1;
                    clock.Stop();
                    ts += clock.Elapsed;
                }
                
                Console.WriteLine("+=1: " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;


                for (int i = 0; i < 1000; i++)
                {
                    clock.Start();
                    result = leArray[0] * leArray[1];
                    clock.Stop();
                    ts += clock.Elapsed;
                }
                ;
                Console.WriteLine("*: " + ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;


                for (int i = 0; i < 1000; i++)
                {
                    clock.Start();
                    result = leArray[0] / leArray[1];
                    clock.Stop();
                    ts += clock.Elapsed;
                }
                
                Console.WriteLine("/: "+ts.TotalMilliseconds / 1000);
                ts = new TimeSpan();
                result = 0;
                break;
            }
            
        }
    }
}
