namespace _17.RemoveTowns
{
    using System;
    using System.Linq;
    using SoftUniDBLib;

    class Program
    {
        static void Main()
        {
            SoftUniDBContext context = new SoftUniDBContext();

            string townName = Console.ReadLine();

            var addressess =
                context.Towns.Where(t => t.Name == townName);
            var employees = context.Employees;



            foreach (var employee in employees)
            {
                foreach (var town in addressess)
                {
                    if (employee.AddressID != null && town.Addresses.Contains(employee.Address))
                    {
                        employee.AddressID = null;
                        break;
                    }
                }
            }
            foreach (var town in addressess)
            {
                Console.WriteLine($"{town.Addresses.Count} addresses in {town.Name} deleted");
                town.Addresses.Clear();
                context.Towns.Remove(town);
            }
            context.SaveChanges();

        }
    }
}
