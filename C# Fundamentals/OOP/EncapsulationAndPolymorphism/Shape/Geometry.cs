using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Geometry
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(2.3, 3.2);
            Shape rhomb = new Rhombus(5.5, 4.5);
            Circle circle = new Circle(6.5);
            IShape[] arr = { rect, rhomb, circle };

            foreach (IShape shape in arr)
            {
                Console.WriteLine(shape.GetType().Name);
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine();
            }
        }
    }
}
