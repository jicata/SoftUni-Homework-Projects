using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class FUCKINZOO
    {
        static void Main(string[] args)
        {
            Animal Kalufka = new Kitten("Kalufka", 5);
            Kalufka.ProduceSound();
            Animal Yanko = new Frog("Yanko", 10, "female");
            Yanko.ProduceSound();
            Animal Jonny = new Dog("Jonny", 2, "male");
            Animal TommyTheCat = new Tomcat("Tommy The Cat", 5);
            TommyTheCat.ProduceSound();

            Animal[] sofiiskiCentralen = { Kalufka, Yanko, Jonny, TommyTheCat };
            double averageAge = sofiiskiCentralen.Average(x => x.Age);
            Console.WriteLine(averageAge);
        }
    }
}
