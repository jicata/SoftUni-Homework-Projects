using System;


namespace Rektangles
{
    class rek9
    {
        static void Main()
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double area = height * width;
            double perimeter = 2 * (height + width);
            Console.WriteLine(perimeter + " " + area);

        }
    }
}
