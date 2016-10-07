using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private int id;

        public Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public int Id
        {
            get { return id; }
            set
            { 
                if(value<0 || String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("ID field cannot be empty and ID cannot be negative");
                }
                id = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name fields cannot be empty");
                }
                lastName = value; 
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name fields cannot be empty");
                }
                firstName = value; 
            }
        }
    }
}
