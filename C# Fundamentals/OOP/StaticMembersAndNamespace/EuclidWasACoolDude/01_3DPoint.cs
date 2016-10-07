using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidWasACoolDude
{

    public  class _01_3DPoint
    {
        private static readonly _01_3DPoint startingPoint = new _01_3DPoint(0, 0, 0);
        private int x;
        private int y;
        private int z;
        

        public _01_3DPoint(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public _01_3DPoint(int x, int y)
            : this(x, y, 0)
        {

        }
        public _01_3DPoint(int x)
            : this(x,0,0)
        {

        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Z
        {
            get { return z; }
            set { z = value; }
        }
        public static _01_3DPoint StartingPoint{
            get { return startingPoint; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X:" + this.X + " ");
            sb.Append("Y:" + this.Y + " ");
            sb.Append("Z:" + this.Z);
            return sb.ToString();
        }
    }
}
