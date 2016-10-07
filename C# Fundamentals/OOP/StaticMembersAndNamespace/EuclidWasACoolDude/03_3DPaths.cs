using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidWasACoolDude
{
    public class _03_3DPaths
    {
        private List<_01_3DPoint> points;
        public _03_3DPaths()
        {
            this.points = new List<_01_3DPoint>();
        }
        public List<_01_3DPoint> Points
        {
            get { return points; }
           
        }

        public void AddPointToPath(_01_3DPoint point)
        {
            this.points.Add(point);
        }


    }
}
