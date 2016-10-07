using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    class SULS
    {
        static void Main(string[] args)
        {
            //generating polymorphed Persons
            Trainer angel = new SeniorTrainer("Angel", 28);
            Trainer danch0 = new JuniorTrainer("Danch0", 22);
            Student astor = new OnlineStudent("Astor", 25, 1337, 5.2, "OOP fundamentals");
            Student ficho = new DropoutStudent("Ficho", 15, 69, 3.1, "Too cool for school also.. БЪЛГАРИЯ НАД ВСИЧКООО!!!!");
            Student edo = new GraduateStudent("Edo", 25, 666, 5.9, "03.26.2015");
            Student kris = new OnsiteStudent("Kris", 16, 314, 5.1, "OOP fundamentals", 3);
            Student jicata = new OnsiteStudent("Jicata", 23, 420, 5.2, "OOP fundamentals", 3);
            Student johnny = new OnsiteStudent("Johny John", 24, 421, 3.5, "OOP fundamentals", 3);

            //testing out Trainers
            Console.WriteLine("--------------");
            danch0.CreateCourse("OOP");
            danch0.CreateCourse("Piqnstvo");
            angel.DeleteCourse("Piqnstvo");
            Console.WriteLine("--------------");

            //testing out dropouts
            ficho.Reapply();
            Console.WriteLine("--------------");

            //creating a collection of Person
            List<Person> softUniDrones = new List<Person>();
            softUniDrones.Add(angel);
            softUniDrones.Add(danch0);
            softUniDrones.Add(astor);
            softUniDrones.Add(ficho);
            softUniDrones.Add(edo);
            softUniDrones.Add(kris);
            softUniDrones.Add(jicata);
            softUniDrones.Add(johnny);

            //sorting through
            var sorted = softUniDrones.Where(c => c is CurrentStudent).Cast<CurrentStudent>().OrderByDescending(x => x.AverageGrade);
            foreach (var item in sorted)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }
                        

        }
    }
}
