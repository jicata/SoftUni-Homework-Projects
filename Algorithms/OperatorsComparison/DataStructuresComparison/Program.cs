using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresComparison
{
    public class Person
    {
        private string phoneNumber;
        private string name;

        public Person(string name, string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.Name = name;
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> listStructure = new List<Person>();
            Dictionary<string, string> dictionaryStructure = new Dictionary<string, string>();

            string findHim = string.Empty;

            int numberOfEntries = 10000000;
            Random rand = new Random();
            int randomIndex = rand.Next(0, numberOfEntries); //using a random index to specify a string          
   
            for (int i = 0; i < numberOfEntries; i++)
            {
                long phoneLong = rand.Next(10000000, 99999999);
                string phone = phoneLong.ToString();
                string name = GetRandomString();
                listStructure.Add(new Person(name, phone));
                dictionaryStructure.Add(name, phone);
                if (i == randomIndex)
                {
                    findHim = name; //will search for this specific string
                }
            }


            Stopwatch stopwatch = new Stopwatch();
            int functionCalls = 1000; //number of calls to the search methods
            stopwatch.Start();
            for (int i = 0; i < functionCalls; i++)
            {
                SearchInList(findHim, listStructure);
            }
            stopwatch.Stop();
            Console.WriteLine("List: " + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < functionCalls; i++)
            {
                SearchInDictionary(findHim, dictionaryStructure);
            }
            stopwatch.Stop();
            Console.WriteLine("Dictionary: " + stopwatch.Elapsed.TotalMilliseconds);
           
            
        }

        public static Person SearchInList(string name, IList<Person> listStructure)
        {
            foreach (Person person in listStructure)
            {
                if (person.Name == name)
                {
                    return person;
                }
            }
            return null;
        }

        public static string SearchInDictionary(string name, IDictionary<string, string> dictionaryStructure)
        {
            return dictionaryStructure[name];
        }

        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}
