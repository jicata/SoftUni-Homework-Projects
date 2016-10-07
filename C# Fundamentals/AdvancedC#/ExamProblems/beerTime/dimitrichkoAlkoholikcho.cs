using System;

namespace beerTime
{
    class dimitrichkoAlkoholikcho
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int lineWidth = n*2;
            int left = n / 2 - 1;
            int right = lineWidth - (n / 2) ;

            
            
            string topOuter = new string(' ', (lineWidth - n) / 2);
            string topInner = new string('*', n + 1);
            string top = string.Format("{0}{1}{0}", topOuter, topInner);
            Console.WriteLine(top);

            for (int i = 0; i < n / 2 + 1; i++)
            {


                string neckOuter = topOuter;
                string neckInner = new string('*', 1);
                string neckInnerFill = new string(' ', n - 1);
                string neck = string.Format("{0}{1}{2}{1}{0}", neckOuter, neckInner, neckInnerFill);
                Console.WriteLine(neck);
            }

            //n/2 - 1
            for (int i = 0; i < n/2 - 1; i++)
            {
                for (int j = 0; j < lineWidth; j++)
                {
                    if (j == left)
                    {
                        Console.Write("*");
                    }
                    else if (j== right)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                left--;
                right++;
            }
            for (int i = 0; i < n; i++)
            {
                string upperCore = new string('.', lineWidth - 2);
                string core = string.Format("{0}{1}{0}", '*', upperCore);
                Console.WriteLine(core);
            }
            for (int i = 0; i < n; i++)
            {
                string lowerCoreFill = new string('@', lineWidth - 2);
                string lowerCore = string.Format("{0}{1}{0}", "*", lowerCoreFill);
                Console.WriteLine(lowerCore);
            }
            string bottom = new string('*', lineWidth);
            Console.WriteLine(bottom);
        }

    }
}
