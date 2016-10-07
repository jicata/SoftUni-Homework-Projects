using System;


namespace starrr
{
    class rockStar
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int futureLeft =n -1 ;
            int futureRight = n+1;
            int left = n;
            int right = n;
            double middle = Math.Floor((double)(n*2) / 2);
            int actualMid = (int)middle;

            string topOut = new string('.', n);
            string topIn = new string('*', 1);
            string top = string.Format("{0}{1}{0}", topOut, topIn);
            Console.Write(top);

            for (int i = 0; i < n/2; i++)
            {
                for (int j = 0; j < (2*n)+1; j++)
                {
                    
                    if (i > 0  && j == left )
                    {
                        Console.Write("*");
                    }
                    else if (i > 0 && j== right)
                    {
                        Console.Write("*");
                    }

                    else if (i>0)
                    {
                        Console.Write(".");
                    }
                }
                right++;
                left--;
                Console.WriteLine();
            }
            string center = new string('*', n / 2 + 1);
            string centerIn = new string('.', n -1);
            string realCenter = string.Format("{0}{1}{0}", center, centerIn);
            Console.WriteLine(realCenter);
            left = 1;
            right = (n*2) -1;

            for (int i = 0; i < n/2; i++)
            {
                for (int j = 0; j < (n*2) + 1; j++)
                {
                    if (j == left)
                    {
                        Console.Write("*");
                    }
                    else if (j==right)
                    {
                        Console.Write("*");
                    }
                    else if(i == (n/2) - 1 && j == n)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
                left++;
                right--;
            }

            left-=2;
            right+=2;
            for (int i = 0; i < n/2; i++)
            {
                for (int j = 0; j < (n*2)+1; j++)
                {
                    if (i == n / 2 - 1)
                    {
                        Console.Write(realCenter);
                        break;
                    }
                    if (j== left || j==futureLeft)
                    {
                        Console.Write("*");
                    }
                    else if(j==right || j==futureRight)
                    {
                        Console.Write("*");
                    }
                  
                    else
                    {
                        Console.Write(".");
                    }
                    
                }
                Console.WriteLine();
                left--;
                futureLeft--;
                right++;
                futureRight++;

            }
        }
    }
}
