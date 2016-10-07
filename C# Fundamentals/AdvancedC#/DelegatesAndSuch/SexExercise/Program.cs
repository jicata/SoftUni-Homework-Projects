using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> dai =new List<int> { 1, 3, 6, 4, 6 , 8};
            var aide = dai.FirstOrDefault(x => x > 6);
            var aidee = dai.MyTakeWhile(x => x < 10);
            Console.WriteLine(string.Join(", ", aidee));
        }
    }
}
