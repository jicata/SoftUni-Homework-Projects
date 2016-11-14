namespace UniversitySystem
{
    
    using Models;

    class Program
    {
        static void Main()
        {
            UniversitySystemContext context = new UniversitySystemContext();

            Student student = new Student() {Id =1,FirstName = "gosho", LastName = "peshev"};
            Teacher teacher = new Teacher() {Id = 2,FirstName = "georieva", Email = "georgieva@kkuirrr.bg"};
            Course course = new Course() {Id = 1,Name = "matematika 8mi klas", Credits = 5};
            course.Teacher = teacher;
            course.Students.Add(student);
            context.Courses.Add(course);
            context.SaveChanges();
        }
    }
}
