namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using Models;
    using Models.Enums;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = false;
        }



        protected override void Seed(StudentSystemContext context)
        {
         
          
           // SeedTags(context);
            //SeedLicenses(context);
            //SeedResources(context);
            //SeedStudents(context);
            //SeedCourses(context);
            //SeedHomeworks(context);

        }

        private void SeedTags(StudentSystemContext context)
        {
            List<Tag> tags = new List<Tag>()
            {
                new Tag() {Name = "#ValidenTag"},
                new Tag() {Name = "bezHashtag"},
                new Tag() {Name = "    #shashtagMaSus   spei   so ve"},
                new Tag() {Name = "#mnogodalgoimezatagbebratooooooooooooo"}
            };
            tags.ForEach(t=>context.Tags.Add(t));
            context.SaveChanges();
        }

        private void SeedLicenses(StudentSystemContext context)
        {
            List<License> licenses = new List<License>
            {
                new License() {Name = "Open Source"},
                new License() {Name = "Closed Source"},
                new License() {Name = "Private"}
            };
            foreach (var license in licenses)
            {
                context.Licenses.Add(license);
            }
            context.SaveChanges();


        }

        private void SeedResources(StudentSystemContext context)
        {
            string[] resources =
                File.ReadAllLines(
                    @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\CodeFirstExercises\resources.txt")
                    .Skip(1)
                    .ToArray();

            int licenseCount = context.Licenses.Count();
            Random rand = new Random();
            foreach (var resource in resources)
            {
                string[] detailsResource = resource.Split('\t');
                string resourceName = detailsResource[0];
                TypeOfResource resourceType = (TypeOfResource)Enum.Parse(typeof(TypeOfResource), detailsResource[1]);
                string resourceUrl = detailsResource[2];

                int licenseId = rand.Next(0, licenseCount);
                License license = context.Licenses.Find(licenseId);
                Resource newResource = new Resource()
                {
                    Name = resourceName,
                    ResourceType = resourceType,
                    Url = resourceUrl
                };
                newResource.License.Add(license);
                context.Resources.Add(newResource);
            }
            context.SaveChanges();
        }

        private void SeedHomeworks(StudentSystemContext context)
        {
            string[] homeworks =
                File.ReadAllLines(
                    @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\CodeFirstExercises\homeworks.txt")
                    .Skip(1)
                    .ToArray();

            var studentsWithCourses = context.Students.Where(s => s.Courses.Any()).ToList();
            int studentsCount = studentsWithCourses.Count();

            Random rand = new Random();
            foreach (var homework in homeworks)
            {
                string[] detailsHomework = homework.Split('\t');
                string homeworkContent = detailsHomework[0];
                TypeOfContent contentType = (TypeOfContent)Enum.Parse(typeof(TypeOfContent), detailsHomework[1]);
                DateTime submissionDate = DateTime.Parse(detailsHomework[2]);

                int studentId = rand.Next(0, studentsCount);
                Student student = studentsWithCourses[studentId];

                Homework newHomework = new Homework()
                {
                    Content = homeworkContent,
                    ContentType = contentType,
                    SubmissionDate = submissionDate
                };
                newHomework.Student = student;
                newHomework.Course = student.Courses.ToList()[rand.Next(0, student.Courses.Count)];
                context.Homeworks.Add(newHomework);
            }
            context.SaveChanges();
        }

        private void SeedCourses(StudentSystemContext context)
        {
            string[] courses =
                File.ReadAllLines(
                    @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\CodeFirstExercises\courses.txt")
                    .Skip(1)
                    .ToArray();

            int resourceCount = context.Resources.Count();
            int studentsCount = context.Students.Count();
            Random rnd = new Random();
            foreach (var course in courses)
            {
                string[] courseDetails = course.Split('\t');
                string courseName = courseDetails[0];
                string courseDesc = courseDetails[1];
                DateTime courseStart = DateTime.Parse(courseDetails[2]);
                DateTime courseEnd = DateTime.Parse(courseDetails[3]);
                decimal coursePrice = decimal.Parse(courseDetails[4]);

                int resourceId = rnd.Next(0, resourceCount);
                int studentId = rnd.Next(0, studentsCount);
                Resource resource = context.Resources.Find(resourceId);
                Student student = context.Students.Find(studentId);

                Course newCourse = new Course()
                {
                    Name = courseName,
                    Description = courseDesc,
                    StartDate = courseStart,
                    EndDate = courseEnd,
                    Price = coursePrice
                };
                //var homeworks = context.Homeworks.Where(h => h.StudentId == studentId);
                //foreach (var homework in homeworks)
                //{
                //    newCourse.Homeworks.Add(homework);
                //}
                newCourse.Resources.Add(resource);
                newCourse.Students.Add(student);
                context.Courses.Add(newCourse);


            }
            context.SaveChanges();
        }

        private void SeedStudents(StudentSystemContext context)
        {
            string[] students = File.ReadAllLines(
                    @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\CodeFirstExercises\students.txt")
                    .Skip(1)
                    .ToArray();


            foreach (var student in students)
            {
                string[] studentDetails = student.Split('\t');
                string studentName = studentDetails[0];
                DateTime registeredOn = DateTime.Parse(studentDetails[1]);
                DateTime birthday = DateTime.Parse(studentDetails[2].Trim());

                Student newStudent = new Student()
                {
                    Name = studentName,
                    RegistrationDate = registeredOn,
                    Birthday = birthday
                };
                context.Students.Add(newStudent);
            }
            context.SaveChanges();

        }
    }
}
