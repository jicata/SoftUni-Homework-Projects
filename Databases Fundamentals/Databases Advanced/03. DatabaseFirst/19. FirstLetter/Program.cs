namespace _19.FirstLetter
{
    using System;
    using System.IO;
    using System.Linq;
    using SoftUniDBLib;

    class Program
    {
        static void Main()
        {
            GringottsContext context = new GringottsContext();

            var letters = context.WizzardDeposits
                .Where(w=>w.DepositGroup=="Troll Chest")
                .Select(w => w.FirstName.Substring(0,1))
                .Distinct()
                .ToList();

            foreach (var letter in letters.OrderBy(x=>x))
            {
                Console.WriteLine(letter);
            }

            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                foreach (var letter in letters.OrderBy(x => x))
                {
                    Console.WriteLine(letter);
                }
            }

        }
    }
}
