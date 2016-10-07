using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Person
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != null)
                { 
                    if (value.Length < 1) 
                    {
                        throw new ArgumentException("Name must contain at least one character!");
                    }

                }
               
                name = value;
            }

        }
        public int Age
        {
            get { return this.age; }
            set
            {
                
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Age must be between 0(zero) and 100(hundred)!");
                }
                this.age = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (!String.IsNullOrEmpty(value) &&!value.Contains('@'))
                {
                    throw new ArgumentOutOfRangeException("Email must include @");
                }
                email = value;
            }
        }
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public Person(string name, int age) 
            : this(name, age,null)
        {
            
        }
        
        
        public override string ToString()
        {
            string all = String.Format("Name: {0}\nAge: {1}\nE-mail: {2}", this.name, this.age, this.email==null ? "N0 e-mail provided" : this.email);
            return all;
            
        } 
    }
}
