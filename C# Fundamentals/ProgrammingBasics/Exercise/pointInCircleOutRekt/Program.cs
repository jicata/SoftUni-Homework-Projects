using System;

namespace pointInCircleOutRekt
{
    class Program
    {
        static void Main()
        {
            //(top=1, left=-1, width=6, height=2). 

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            double circleCenterX = 1;
            double circleCenterY = 1;

            double circleDiameter = Math.Pow(1.5, 2);

            bool isInsideCircle = Math.Pow(x - circleCenterX, 2) + Math.Pow(y - circleCenterY, 2) < circleDiameter;
            bool isOutsideRekt = x > 1 || x < 6 && y > -1 || y < 2;
            if (isInsideCircle && isOutsideRekt)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            // bool isInsideLowerRekt = ((x >= 0) && (x <= width))&& ((y >= 0) && (x <= h));


        }
    }
}
