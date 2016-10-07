using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    class EmployeeData
    {
        static void Main()
        {
            //First name: Amanda
            //Last name: Jonson
            //Age: 27
            //Gender: f
            //Personal ID: 8306112507
            //Unique Employee number: 27563571
            string firstName = "First name: Amanda";
            string lastName = "Last name: Jonson";
            byte age = 27;
            string gender = "Gender: f";
            long ID = 8306112507;
            int EmployeeNumber = 27563571;
            Console.WriteLine(firstName);
            Console.WriteLine(lastName);
            Console.WriteLine("Age: " + age);
            Console.WriteLine(gender);
            Console.WriteLine("Personal ID: " + ID);
            Console.WriteLine("Unique Employee Number: " + EmployeeNumber);
            

        }
    }
}
