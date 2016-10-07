namespace Algorithms_1
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            StupidList<int> smartList = new StupidList<int>();

            int n = 100000;
           
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i <= 2; i++)
            {
                smartList.Add(i);
            }
            sw.Stop();
            TimeSpan ts1 = sw.Elapsed;
           
            for (int i = 2; i <=n ; i++)
            {
                smartList.Add(i);
            }
    
            sw.Restart();
            for (int i = 0; i <= 2; i++)
            {
                smartList.Add(i);
            }
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine(ts1);
            Console.WriteLine(ts2);
        }
    }
}
