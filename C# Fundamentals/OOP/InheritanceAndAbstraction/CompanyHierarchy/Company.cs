using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace CompanyHierarchy
{
    class Company
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            Project csgo = new Project("FarmPoCqlDen", DateTime.Parse("23/09/1992"), "GlobalPotato", "Closed");
            Sale steamSale =  new Sale("!!!STEAM SALE!!!", DateTime.Parse("24.12.2015"), 20);

            Person Royal = new Manager("Ro", "YaL", 2, 450, "Sales");
            Person drone1 = new SalesEmployee("dron", "edno", 665, 380);
            Person drone2 = new Developer("dron", "dve", 667, 380);
            Person nsaSpy = new Employee("nsa", "spy", 1337, 379, "Marketing");
            Person kgbSpy = new Employee("Nikita", "Kruschev", 1958, 1964, "Accounting");

            (drone1 as SalesEmployee).AddSale(steamSale);
            (drone2 as Developer).AddProject(csgo);
            (Royal as Manager).AddEmployee((kgbSpy as Employee));

            List<Person> personi = new List<Person>();
            personi.Add(Royal);
            personi.Add(drone1);
            personi.Add(drone2);
            personi.Add(nsaSpy);
            personi.Add(kgbSpy);

            foreach (Person persona in personi)
            {
                Console.WriteLine(persona);
                Console.WriteLine();
            }
            Customer crusty = new Customer("Crusty", "The Clown", 999);
            crusty.Purchase(steamSale);
            Console.WriteLine(crusty.NetPurchase);


           
        }
    }
}
