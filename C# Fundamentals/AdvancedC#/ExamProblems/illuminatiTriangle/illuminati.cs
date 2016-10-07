using System;

public class Triangle
{
    public static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());

        double ab = Math.Sqrt(Math.Pow(bX - aX, 2) + Math.Pow(bY - aY, 2));

        double bc = Math.Sqrt(Math.Pow(bX - cX, 2) + Math.Pow(bY - cY, 2));

        double ac = Math.Sqrt(Math.Pow(aX - cX, 2) + Math.Pow(aY - cY, 2));

        bool isTriangle = (ab + bc > ac && ab + ac > bc && bc + ac > ab);
        double perimeter = (ab + bc + ac) / 2;
        double area = 0;

        if (isTriangle)
        {
            area = Math.Sqrt(perimeter * ((perimeter - ab) * (perimeter - bc) * (perimeter - ac)));
            Console.WriteLine("Yes");
            Console.WriteLine("{0:0.00}", area);

        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:0.00}", ab);
        }
    }
}