using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    class Student : Person
    {
        int studentNumber;
        double averageGrade;
        public Student(string name, int age, int studentNumber, double averageGrade)
            :base(name, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public int StudentNumber
        {
            get { return studentNumber; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Student number cannot be negative");
                }
                studentNumber = value; }
        }
        public double AverageGrade
        {
            get { return averageGrade; }
            set { averageGrade = value; }
        }
        public virtual void Reapply()
        {

        }
       
    }
}
