using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInfo
{
    class CorporateShill
    {
        static void Main()
        {
            //A company has name, address, phone number, fax number, web site and manager. 
            //The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints it back on the console.
            Console.WriteLine("Enter the company details");
            Console.WriteLine("Company name: ");
            string companyName = Console.ReadLine();
            Console.WriteLine("Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Phone Number:");
            int phoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Fax Number:");
            int faxNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Website:");
            string webAddress = Console.ReadLine();
            //manager
            Console.WriteLine("Enter the manager details");
            Console.WriteLine("First name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Phone Number:");
            int managerCellPhone = int.Parse(Console.ReadLine());
            Console.WriteLine("Company name: {0}\nAddress: {1}\nPhone Number: {2}\nFax Number: {3}\nWebsite: {4}", companyName, address, phoneNumber, faxNumber, webAddress);
            Console.WriteLine("Manager's first name: {0}, Last name: {1}, Age: {2}, Phone Number: {3}", firstName, lastName, age, managerCellPhone);
        }
    }
}
