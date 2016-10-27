namespace _06.NewAddressAndUpdateEmployee
{
    using System;
    using System.IO;
    using System.Linq;
    using SoftUniDBLib;
    using SoftUniDBLib.Models;

    class Program
    {
        static void Main()
        {
            SoftUniDBContext context = new SoftUniDBContext();
            Address adress = new Address();
            adress.AddressText = "Vitoshka 15";
            adress.TownID = 4;

            Employee nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = adress;

            context.SaveChanges();

            var employeeAddressessTop10 =
                context.Employees.OrderByDescending(e => e.Address.AddressID).Take(10).Select(e=>e.Address.AddressText).ToList();
            employeeAddressessTop10.ForEach(x => Console.WriteLine(x));

            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                employeeAddressessTop10.ForEach(x => Console.WriteLine(x));
            }

        }
    }
}
