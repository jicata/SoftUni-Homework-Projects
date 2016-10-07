using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string name, int age, int studentNumber, double averageGrade, string currentCourse)
            : base(name, age, studentNumber, averageGrade, currentCourse)
        {

        }
    }
}
