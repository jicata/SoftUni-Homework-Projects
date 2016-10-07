using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rhombus : Shape
    {
        

        public Rhombus(double width, double height)
            :base(width,height)
        {

        }
        public override double CalculateArea()
        {
            return this.width * this.height;
        }
        public override double CalculatePerimeter()
        {
            return this.width * 4;
        }
   
    }
}
