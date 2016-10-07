using System;

namespace sunLighjt
{
    class tumnoE
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int centerOfLine = (n * 3) / 2;
            int left = 0;
            int right = n * 3 - 1;

            //top
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n*3; j++)
                {
                    if (i==0 && j == centerOfLine)
                    {
                        Console.Write("*");
                    }
                    else if (i > 0 && (j == left || j == right || j == centerOfLine))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                  
                }
                left++;
                right--;
                Console.WriteLine();
            }
            left--;
            right++;
            //center
            for (int i = 0; i < n; i++)
            {
                string center = new string('*', n * 3);
                string middleOuterFill = new string('.', n);
                string middleInnerFill = new string('*', n);
                string middle = string.Format("{0}{1}{0}", middleOuterFill, middleInnerFill);
                if (i != n / 2)
                {
                    Console.WriteLine(middle);
                }
                else
                {
                    Console.WriteLine(center);
                }
            }
            //bottom
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n*3; j++)
                {
                    if (i == n-1 && j == centerOfLine)
                    {
                        Console.Write("*");
                    }
                    else if (i !=n-1 && (j == left || j == right || j == centerOfLine))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                left--;
                right++;
                Console.WriteLine();
            }
            

        }
    }
}
