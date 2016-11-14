namespace UniversitySystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class UniversitySystemContext : DbContext
    {
        public UniversitySystemContext()
            : base("name=UniversitySystemContext")
        {
        }

        public IDbSet<UniversityPerson> UniversityPersons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Map(s =>
            {
                s.MapInheritedProperties();
                s.ToTable("Students");
            });

            modelBuilder.Entity<Teacher>().Map(t =>
            {
                t.MapInheritedProperties();
                t.ToTable("Teachers");
            });
            base.OnModelCreating(modelBuilder);
        }
    }

    
}