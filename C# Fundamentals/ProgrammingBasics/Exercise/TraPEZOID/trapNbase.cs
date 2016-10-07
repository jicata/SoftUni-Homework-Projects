using System;


namespace TraPEZOID
{
    class trapNbase
    {
        static void Main()
        {
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());
            double h = int.Parse(Console.ReadLine());
            double area = ((a + b) / 2) * h;
            Console.WriteLine(area);
        }
    }
}
