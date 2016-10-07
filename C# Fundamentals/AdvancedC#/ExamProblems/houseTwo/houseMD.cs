using System;


namespace houseTwo
{
    class houseMD
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int left = width / 2;
            int right = width / 2;
            string middle = new string('*', width);

             for (int i = 0; i < width/2; i++)
             {
                 for (int j = 0; j < width; j++)
                 {

                     if (i == 0 && j == width / 2)
                     {
                         Console.Write("*");
                     }
                     else if (i > 0 && j == left)
                     {
                         Console.Write("*");
                     }
                     else if (i > 0 && j == right)
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
             Console.Write(middle);
             Console.WriteLine();
            string outerFill = new string('.', width/4);
            string fill = new string('.',width - ((width / 4)*2 + 2));
            string foundation = string.Format("{0}{1}{2}{1}{0}", outerFill, '*', fill);

            string botFill = new string('*', width -(width/4 * 2));
            string bot = string.Format("{0}{1}{0}", outerFill, botFill);
             for (int i = 1; i <= width / 2; i++)
             {
                 if (i < width/2)
                 {
                     Console.WriteLine(foundation);
                 }
                 else 
                 {
                     Console.WriteLine(bot);
                 }
             }

            

        }
    }
}
