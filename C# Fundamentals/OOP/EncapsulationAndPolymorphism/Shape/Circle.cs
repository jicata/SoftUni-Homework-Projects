using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius
        {
            get { return radius; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Radius cannot be negative");
                }
                radius = value; }
        }
        public double CalculateArea()
        {
            return (this.radius * this.radius) * Math.PI;
        }
        public double CalculatePerimeter()
        {
            return (this.radius*Math.PI)*2;
        }
    }
}
