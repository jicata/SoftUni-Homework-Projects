using System;


namespace baiVylcho
{
    class diamondDigger
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int height = width;
            int up = width / 2;
            int low = width / 2;

            for (int i = 0; i< height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i==0 && j == width/2)
                    {
                        Console.Write("*");
                    }
                    else if (i > 0 && j == up)
                    {
                        Console.Write("*");
                    }
                    else if (i > 0 && j == low)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
                if (i<width/2)
                {
                    up++;
                    low--;
                }
                else
                {
                    up--;
                    low++;
                }
                
              
            }

        }
    }
}
