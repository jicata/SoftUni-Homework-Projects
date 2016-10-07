using System;
using System.Collections.Generic;

namespace Collection_of_Persons
{
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private Dictionary<string, Person>  personsByEmail = new Dictionary<string, Person>();
        private Dictionary<string, SortedSet<Person>> personsByDomain = new Dictionary<string, SortedSet<Person>>();
        private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        private OrderedDictionary<int, SortedSet<Person>> personsByAgeRange = 
           new OrderedDictionary<int, SortedSet<Person>>();
        private OrderedDictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge = 
            new OrderedDictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                return false;
            }
            var person = new Person(email, name, age, town);

            this.personsByEmail.Add(person.Email,person);

            var emailDomain = this.ExtractEmailDomain(email);
            this.personsByDomain.AppendValueToKey(emailDomain, person);

            var nameAndTown = this.CombineNameAndTown(name, town);
            this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

            this.personsByAgeRange.AppendValueToKey(age, person);

            this.personsByTownAndAge.EnsureKeyExists(town);
            this.personsByTownAndAge[town].AppendValueToKey(age, person);
            return true;
        }

        private string CombineNameAndTown(string name, string town)
        {
            const string seprator = "|!|";
            return name + seprator + town;
        }

        public int Count
        {
            get { return this.personsByEmail.Count; }
        }

        public Person FindPerson(string email)
        {
            Person person;
            var personExists = this.personsByEmail.TryGetValue(email, out person);
            return person;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person != null)
            {
                this.personsByEmail.Remove(email);
                var emailDomain = this.ExtractEmailDomain(email);
                this.personsByDomain[emailDomain].Remove(person);
                var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
                this.personsByNameAndTown[nameAndTown].Remove(person);
                this.personsByAgeRange[person.Age].Remove(person);
                this.personsByTownAndAge[person.Town][person.Age].Remove(person);
                return true;
            }
            return false;
        }

        private string ExtractEmailDomain(string email)
        {
            var domain = email.Split('@')[1];
            return domain;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.personsByDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var nameAndTown = this.CombineNameAndTown(name, town);
            return this.personsByNameAndTown.GetValuesForKey(nameAndTown);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var agesInRange = this.personsByAgeRange.Range(startAge, true, endAge, true);
            foreach (var age in agesInRange)
            {
                foreach (var person in age.Value)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable<Person> FindPersons(
            int startAge, int endAge, string town)
        {
            if (!this.personsByTownAndAge.ContainsKey(town))
            {
                yield break;
            }
            var agesInTown = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);
            foreach (var ageRange in agesInTown)
            {
                foreach (var person in ageRange.Value)
                {
                    yield return person;
                }
            }
        }
    }
}
