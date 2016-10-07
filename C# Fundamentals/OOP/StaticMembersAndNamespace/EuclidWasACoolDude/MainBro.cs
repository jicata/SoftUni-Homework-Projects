using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidWasACoolDude
{
    class MainBro
    {
        static void Main(string[] args)
        {
            
            string destination = ""; ///<----------- PUT YOUR OWN PATH/DESTINATION FILE HERE
                                    
            //creating a point from the 3DPoint class
            _01_3DPoint point = new _01_3DPoint(0, 1, 3);
            
            //creating a pathsList from the 3DPaths class
            _03_3DPaths paths = new _03_3DPaths();

            //calculating distance between a 3D point and StartingPoint
            Console.WriteLine(_02_DistanceCalculator.DistanceCalc3D(point, _01_3DPoint.StartingPoint));

            //utilising some methods of the 3DPaths class
            paths.AddPointToPath(point);
            paths.AddPointToPath(_01_3DPoint.StartingPoint);

            //utilising the SavePathTo method from the Storage class
            _03_Storage.SavePathTo(paths, destination);

            //utilising the LoadPathFrom method from the Storage class
            _03_3DPaths puteki = _03_Storage.LoadPathFrom(destination);

            for (int i = 0; i < puteki.Points.Count; i++)
            {
                Console.WriteLine(puteki.Points[i].ToString());
            }
        }
    }
}
