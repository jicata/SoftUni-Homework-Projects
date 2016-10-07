using System;
class PointInsideACircleAndOutsideOfRectangle
{
    static void Main()
    {
        Console.Write("Input coodinate \"x\": ");
        double x = double.Parse(Console.ReadLine());
        double xCircle = 1;
        Console.Write("Input coordinate \"y\": ");
        double y = double.Parse(Console.ReadLine());
        double yCircle = 1;
        double r = 1.5; //circle radius

        bool inCircle = false;
        bool inRectangle = false;

        //Rectangle borders
        double left = -1;
        double top = 1;
        double width = 6;
        double height = 2;

        double rectTop = top;
        double rectLeft = left;
        double rectBottom = top - height;
        double rectRight = left + width;

        if (((x - xCircle) * (x - xCircle)) + ((y - yCircle) * (y - yCircle)) <= r * r)
        {
            inCircle = true;

            if ((x >= rectLeft && x <= rectRight) && (y >= rectBottom && y <= rectTop))
            {
                inRectangle = true;
            }
            else if (x < rectLeft || x > rectRight)
            {
                inRectangle = false;
            }
            else if (y < rectBottom || y > rectTop)
            {
                inRectangle = false;
            }
        }
        else
        {
            inCircle = false;

            if ((x >= rectLeft && x <= rectRight) && (y >= rectBottom && y <= rectTop))
            {
                inRectangle = true;
            }
            else if (x < rectLeft || x > rectRight)
            {
                inRectangle = false;
            }
            else if (y < rectBottom || y > rectTop)
            {
                inRectangle = false;
            }
        }

        if (inCircle && !inRectangle)
        {
            Console.WriteLine("Inside the circle and outside the rectangle? Yes");
        }
        else
        {
            Console.WriteLine("Inside the circle and outside the rectangle? No");
        }
    }
}