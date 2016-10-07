using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    class GraduateStudent : Student
    {
        DateTime graduationDate;

        public GraduateStudent(string name, int age, int studentNumber, double averageGrade, string graduationDate)
           : base(name, age, studentNumber, averageGrade)
        {
            this.GraduationDate = DateTime.Parse(graduationDate);
        }
        public DateTime GraduationDate
        {
            get { return graduationDate; }
            set { graduationDate = value; }
        }
        
    }
}
