using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
            :base(width, height)
        {

        }

        public override double CalculateArea()
        {
            return this.width * this.height;
        }
        public override double CalculatePerimeter()
        {
            return (this.height + this.width) * 2;
        }
    }
}
