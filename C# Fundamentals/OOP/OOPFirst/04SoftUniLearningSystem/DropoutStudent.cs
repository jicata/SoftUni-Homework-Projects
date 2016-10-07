using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    class DropoutStudent : Student
    {
        string dropoutReason;
        public DropoutStudent(string name, int age, int studentNumber, double averageGrade, string dropoutReason)
            : base(name, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }
        public string DropoutReason
        {
            get { return dropoutReason; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter a dropout reason.");
                }
                dropoutReason = value; }
        }
        public override void Reapply()
        {
            Console.WriteLine("Student details");
            Console.WriteLine("--Name: "+ this.Name);
            Console.WriteLine("--Age: "+ this.Age);
            Console.WriteLine("--Student Number: " + this.StudentNumber);
            Console.WriteLine("--Average grade: "+ this.AverageGrade);
            Console.WriteLine("--Dropout reason: " + this.DropoutReason);
        }
    }
}
