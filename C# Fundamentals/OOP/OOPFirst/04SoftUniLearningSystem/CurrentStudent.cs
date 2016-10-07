using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    class CurrentStudent : Student
    {
        string currentCourse;
        public CurrentStudent(string name, int age, int studentNumber, double averageGrade, string currentCourse)
            : base(name, age, studentNumber, averageGrade)
        {
            this.Course = currentCourse;
        }
        public string Course
        {
            get { return currentCourse; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name cannot be empty");
                }
                currentCourse = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + this.Name);
            sb.Append("\nAge: " + this.Age);
            sb.Append("\nStudent Number: " + this.StudentNumber);
            sb.Append("\nAverage Grade: " + this.AverageGrade);
            sb.Append("\nCurrent Course: " + this.Course);
            return sb.ToString();
        }

    }
}
