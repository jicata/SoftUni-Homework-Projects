using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    public class Person
    {
        string name;
        int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return name; }
            set {
                if (String.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name cannot be empty and must be at least two characters long");
                }
                name = value; 
            }
        }
        public int Age
        {
            get { return age; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }
                age = value; }
        }

    }
}
