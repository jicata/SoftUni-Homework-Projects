namespace UniversitySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student : UniversityPerson
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public double AverageGrade { get; set; }

        public int Attendance { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        
    }
}
