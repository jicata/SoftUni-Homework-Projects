using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01HumanStudentWorker
{
    class Student : Human
    {
        private string facultyNumber;
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        public string FacultyNumber
        {
            get { return facultyNumber; }
            set 
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Faculty number cannot be empty and must contain between 5 and 10 letters/numbers");
                }
                facultyNumber = value; 
            }
        }
    }
}
