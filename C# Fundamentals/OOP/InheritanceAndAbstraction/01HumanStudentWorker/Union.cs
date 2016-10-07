using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01HumanStudentWorker
{
    class Union
    {
        static void Main(string[] args)
        {

            List<Human> students = new List<Human>()
            {
                new Student("pesho", "peshev", "1238A82"),
                new Student("gosho", "goshev", "283716DSA"),
                new Student("Cherna", "Rabota", "999283HD"),
                new Student("Ba", "Si", "18272HD0") ,
                new Student("TiSiLud", "DaPisha10", "228383KS")
            };
            List<Human> sortedStudents = students.Cast<Student>().OrderBy(x => x.FacultyNumber).Cast<Human>().ToList();

            List<Human> workers = new List<Human>()
            {
                new Worker("Karl", "Hacks", 100, 11),
                new Worker("Friedrich", "Angles", 95, 11),
                new Worker("Svurshiha", "Imenata", 900, 5),
                new Worker("NeWe", "EbavamSe", 666, 69),
                new Worker("Bat", "Tosho", 1991, 1)
            };

            List<Human> sortedWorkers = workers.Cast<Worker>().OrderByDescending(x => x.MoneyPerHour()).Cast<Human>().ToList();

            List<Human> laborUnion = sortedStudents.Concat(sortedWorkers).ToList();
            laborUnion = laborUnion.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            foreach (Human person in laborUnion)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }
        }
    }
}
