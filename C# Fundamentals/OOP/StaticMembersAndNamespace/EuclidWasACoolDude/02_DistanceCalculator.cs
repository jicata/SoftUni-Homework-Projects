using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidWasACoolDude
{
    static class _02_DistanceCalculator
    {
        public static double DistanceCalc3D(_01_3DPoint pointOne, _01_3DPoint pointTwo)
        {
            double deltaX = pointTwo.X - pointOne.X;
            double deltaY = pointTwo.Y - pointOne.Y;
            double deltaZ = pointTwo.Z - pointOne.Z;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return distance;
        }
    }
}
