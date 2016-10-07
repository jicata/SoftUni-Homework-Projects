using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeage
{
   public  class Player
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private decimal salary;

        public Player(string firstName, string lastName, DateTime dateOfBirth, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            set {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must be at least 3(three) characters longs!");
                }
                firstName = value; 
            }
        }
        public string LastName
        {
            get { return lastName; }
            set {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must be at least 3(three) characters longs!");
                }
                lastName = value; 
            }
        }
        public decimal Salary
        {
            get { return salary; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative!");
                }
                salary = value; 
            }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set {
                if (value.Year < 1980)
                {
                    throw new ArgumentOutOfRangeException("Player cannot be born before the rockin' '80s");
                }
                dateOfBirth = value; 
            }
        }
        


    }
}
