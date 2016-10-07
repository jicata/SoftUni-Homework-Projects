namespace Loop1
{
    using System;
    using System.Data.Common;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("*");
            }
            else
            {
                if (n % 2 == 0)
                {
                    int leftRightDash = (n - 1) / 2;
                    for (int i = 0; i <= (n / 2) - 1; i++)
                    {

                        int mid = n - (2 * leftRightDash) - 2;

                        Console.Write(new string('-', leftRightDash));
                        Console.Write('*');
                        if (mid > 0)
                        {
                            Console.Write(new string('-', mid));
                        }

                        Console.Write('*');
                        Console.Write(new string('-', leftRightDash));
                        Console.WriteLine();
                        leftRightDash--;


                    }
                    leftRightDash = 1;
                    for (int i = 0; i < (n / 2) - 1; i++)
                    {

                        int mid = n - (2 * leftRightDash) - 2;

                        Console.Write(new string('-', leftRightDash));
                        Console.Write('*');
                        if (mid > 0)
                        {
                            Console.Write(new string('-', mid));
                        }

                        Console.Write('*');
                        Console.Write(new string('-', leftRightDash));
                        Console.WriteLine();
                        leftRightDash++;


                    }

                }
                else
                {
                    int leftRightDash = (n - 1) / 2;

                    Console.WriteLine("{0}{1}{0}", new string('-', leftRightDash), '*');
                    leftRightDash--;
                    for (int i = 0; i <= (n / 2) - 1; i++)
                    {

                        int mid = n - (2 * leftRightDash) - 2;

                        Console.Write(new string('-', leftRightDash));
                        Console.Write('*');
                        if (mid > 0)
                        {
                            Console.Write(new string('-', mid));
                        }

                        Console.Write('*');
                        Console.Write(new string('-', leftRightDash));
                        Console.WriteLine();
                        leftRightDash--;


                    }
                    leftRightDash = 1;
                    for (int i = 0; i < (n / 2) - 1; i++)
                    {

                        int mid = n - (2 * leftRightDash) - 2;

                        Console.Write(new string('-', leftRightDash));
                        Console.Write('*');
                        if (mid > 0)
                        {
                            Console.Write(new string('-', mid));
                        }

                        Console.Write('*');
                        Console.Write(new string('-', leftRightDash));
                        Console.WriteLine();
                        leftRightDash++;


                    }
                    Console.WriteLine("{0}{1}{0}", new string('-', leftRightDash), '*');
                }
            }
            


        }
    }
}
