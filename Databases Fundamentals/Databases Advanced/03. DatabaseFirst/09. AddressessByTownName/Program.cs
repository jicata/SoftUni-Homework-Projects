namespace _09.AddressessByTownName
{
    using System;
    using System.IO;
    using System.Linq;
    using SoftUniDBLib;

    class Program
    {
        static void Main()
        {
            SoftUniDBContext context  = new SoftUniDBContext();
            var addressess =context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                //.Select(a => new {a.AddressText, a.Town.Name, a.Employees.Count, a.Employees}) <--- outputs wrong ordering, but WHY?
                .Take(10);

            foreach (var address in addressess)
            {
                Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            }


            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                foreach (var address in addressess)
                {
                    Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
                }
            }

        }
    }
}
