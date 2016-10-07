using System;


namespace sunglasses
{
    class sunglassed
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int rightHere = (int)Math.Floor((decimal)n / 2);
            
            for (int i = 0; i< n; i++)
            {
                if (i == 0 || i == n -1 )
                {
                    PrintTopBot(n);
                }
                else
                {
                    PrintMid(n, i);
                }
            }
            
         }
        private static void PrintMid (int n, int i)
        {
            //middle + fill
            string lens = new string('/', n * 2 - 2);
            string middleFill = string.Format("{0}{1}{0}", '*', lens);

            string bridge = new string(' ', n);
            if (i == n/2)
            {
               bridge = new string('|', n);
            }
            string middleFrame = string.Format("{0}{1}{0}", middleFill, bridge);
            Console.WriteLine(middleFrame);
           //middle + connection
        }
        private static void PrintTopBot(int n)
        {
            //top + bottom
            string top = new string('*', n * 2);
            string emptySpaces = new string(' ', n);
            string topUp = string.Format("{0}{1}{0}", top, emptySpaces);
            Console.WriteLine(topUp);

            //top + bottom
        }
    }
}
