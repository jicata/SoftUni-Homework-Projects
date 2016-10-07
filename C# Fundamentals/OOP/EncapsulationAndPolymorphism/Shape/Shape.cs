using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape : IShape
    {
        protected double width;
        protected double height;
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        protected double Width
        {
            get { return width; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be negaitve");
                }
                width = value; }
        }
        protected double Height
        {
            get { return height; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be negative");
                }
                height = value; }
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}
