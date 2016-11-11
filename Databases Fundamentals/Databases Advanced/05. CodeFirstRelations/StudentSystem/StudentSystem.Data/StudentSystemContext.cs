namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class StudentSystemContext : DbContext
    {     
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }
        public virtual IDbSet<Course> Courses { get; set; }
        public virtual IDbSet<Homework> Homeworks { get; set; }
        public virtual IDbSet<Resource> Resources { get; set; }
        public virtual IDbSet<License> Licenses { get; set; }
        public virtual IDbSet<Album> Albums { get; set; }
        public virtual IDbSet<Picture> Pictures { get; set; }
        public virtual IDbSet<Tag> Tags { get; set; }

       
    }
}