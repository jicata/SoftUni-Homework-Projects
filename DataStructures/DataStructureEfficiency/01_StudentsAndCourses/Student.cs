namespace _01_StudentsAndCourses
{
    using System;
    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            int result = this.LastName.CompareTo(other.LastName);
            if (result == 0)
            {
                result = this.FirstName.CompareTo(other.FirstName);
            }
            return result;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
