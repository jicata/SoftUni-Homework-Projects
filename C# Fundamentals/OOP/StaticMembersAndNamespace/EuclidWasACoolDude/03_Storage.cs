using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace EuclidWasACoolDude
{
    public static class _03_Storage
    {
        public static void SavePathTo(_03_3DPaths paths, string destination)
        {
            FileStream fs = new FileStream(destination, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fs)) 
            {
                for (int i = 0; i < paths.Points.Count; i++)
                {
                    string path = paths.Points[i].ToString();
                    writer.WriteLine(path);
                }
            }

        }
        public static _03_3DPaths LoadPathFrom(string destination)
        {
            _03_3DPaths paths = new _03_3DPaths();
            FileStream fs = new FileStream(destination, FileMode.Open);
            using (StreamReader reader = new StreamReader(fs))
            {
                
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = Regex.Replace(line, @"\D+", " ");
                    string[] vertices = line.Trim().Split();
                    _01_3DPoint point = new _01_3DPoint(int.Parse(vertices[0]), int.Parse(vertices[1]), int.Parse(vertices[2]));
                    paths.AddPointToPath(point);
                    line = reader.ReadLine();
                }
            }
            return paths;
        }
    }
}
