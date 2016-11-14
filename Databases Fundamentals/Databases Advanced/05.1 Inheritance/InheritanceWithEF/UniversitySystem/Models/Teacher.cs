namespace UniversitySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Teacher : UniversityPerson
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }

        public string Email { get; set; }

        public decimal SalaryPerHour { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        
    }
}
