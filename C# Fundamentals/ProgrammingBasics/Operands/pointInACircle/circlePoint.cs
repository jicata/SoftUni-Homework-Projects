using System;


namespace pointInACircle
{
    class circlePoint
    {
        static void Main()
        {
            bool flag = false;
            double center_x = 0;
            double radius_y = 0;
            double area = Math.PI * Math.Pow(2, 2);
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            if (Math.Pow(x - center_x, 2) + Math.Pow(y - radius_y, 2) < Math.Pow(2, 2)) 
            {
                flag = true;
                Console.WriteLine(flag);
            }
            else
            {
                Console.WriteLine(flag);
            }
        }
    }
}
