namespace _01_StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string path = @"C:\Users\Maika\Documents\visual studio 2015\Projects\DataStructureEfficiency\students.txt";

            string[] everyLine = File.ReadAllLines(path);

            SortedDictionary<string, SortedSet<Student>> studentsByCourse = new SortedDictionary<string, SortedSet<Student>>();

            for (int i = 0; i < everyLine.Length; i++)
            {
                string[] studentCourseArgs = everyLine[i].Split('|');
                string studentFirstName = studentCourseArgs[0].Trim();
                string studentLastName = studentCourseArgs[1].Trim();
                string courseName = studentCourseArgs[2].Trim();
                var student = new Student(studentFirstName, studentLastName);
                if (!studentsByCourse.ContainsKey(courseName))
                {
                    studentsByCourse.Add(courseName, new SortedSet<Student>());
                }

                if (studentsByCourse[courseName].Contains(student))
                {
                    Console.WriteLine("Student {0} already enrolled in course {1}", student, courseName);
                }
                else
                {
                    studentsByCourse[courseName].Add(student);
                }
                
            }
            foreach (var course in studentsByCourse)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }
    }
}
