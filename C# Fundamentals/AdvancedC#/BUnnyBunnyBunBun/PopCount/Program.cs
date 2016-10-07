namespace PopCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        public static void Main()
        {
            List<Country> countries = new List<Country>();

            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] inputArgs = input.Split('|');
                string cityName = inputArgs[0];
                string countryName = inputArgs[1];
                long cityPop = long.Parse(inputArgs[2]);
                if (!countries.Any(x => x.name == countryName))
                {
                    countries.Add(new Country(countryName));
                    var country = countries.FirstOrDefault(x => x.name == countryName);
                    country.cities.Add(new City(cityPop, cityName));
                }
                else
                {
                    var country = countries.FirstOrDefault(x => x.name == countryName);
                    country.cities.Add(new City(cityPop, cityName));
                }
                input = Console.ReadLine();
            }
            foreach (Country country in countries)
            {
                country.CalculatePops();
                //country.cities.OrderByDescending(x => x.population);
            }

            var sortedCountries = countries.OrderByDescending(x => x.population);
            foreach (Country sortedCountry in sortedCountries)
            {
                Console.WriteLine(sortedCountry.name + string.Format(" (total population: {0})", sortedCountry.population));
                foreach (City city in sortedCountry.cities.OrderByDescending(x=>x.population))
                {
                    Console.WriteLine(string.Format("=>{0}: {1}", city.name, city.population));
                }
            }
        }
    }

    public class City
    {
        public long population;
        public string name;

        public City(long population, string name)
        {
            this.population = population;
            this.name = name;
        }
    }

    public class Country
    {
        public long population;
        public string name;
        public List<City> cities;

        public Country(string name)
        {

            this.name = name;
            this.cities = new List<City>();
        }

        public void CalculatePops()
        {
            foreach (var city in this.cities)
            {
                this.population += city.population;
            }
        }
    }
}
