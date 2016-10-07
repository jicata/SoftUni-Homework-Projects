using System;


namespace arroW
{
    class arro
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());

            string outerTopFill = new string('.', (width - 1) / 2);
            string innerTopFill = new string('#', width);
            string top = string.Format("{0}{1}{0}", outerTopFill, innerTopFill);
            

            string outerMiddleFill = outerTopFill;
            string innerMiddleFill = new string('.', width - 2);
            string middle = string.Format("{0}{1}{2}{1}{0}", outerMiddleFill, '#', innerMiddleFill);
           

            string outerCenterFill = new string('#', (width + 1) / 2);
            string innerCenterFill = innerMiddleFill;
            string center = string.Format("{0}{1}{0}", outerCenterFill, innerCenterFill);
           
            for (int i = 0; i < width; i++)
            {
                if (i==0)
                {
                    Console.WriteLine(top);
                }
                else if (i == width - 1)
                {
                    Console.WriteLine(center);
                }
                else
                {
                    Console.WriteLine(middle);
                }
            }
            int lineWidth = width + (width -1);
            int left = 1;
            int right = lineWidth - 2;
            for (int i = 0; i < width - 1; i++)
			{
			    for (int j = 0; j < lineWidth; j++)
			    {
                    if (j==left)
                    {
                        Console.Write("#");
                    }
                    else if (j==right)
                    {
                        Console.Write("#");
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
        }
    }
}
