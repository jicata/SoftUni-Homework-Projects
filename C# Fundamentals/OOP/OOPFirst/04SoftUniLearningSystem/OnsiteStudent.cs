using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    class OnsiteStudent : CurrentStudent
    {
        int numberOfVisits;
        public OnsiteStudent(string name, int age, int studentNumber, double averageGrade, string currentCourse, int numberOfVisits)
            : base(name, age, studentNumber, averageGrade, currentCourse)
        {
            this.NumberOfVisits = NumberOfVisits;
        }

        public int NumberOfVisits
        {
            get { return numberOfVisits; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Number of visits cannot be negative");
                }
                numberOfVisits = value; }
        }

    }
}
