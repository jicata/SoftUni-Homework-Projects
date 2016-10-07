namespace FastAndStupulous
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.ReadLine();

            Dictionary<string, List<Tuple<string, double>>> cities = new Dictionary<string, List<Tuple<string, double>>>();
            Dictionary<string, List<Tuple<string, DateTime>>> cars = new Dictionary<string, List<Tuple<string, DateTime>>>();
            SortedSet<string> speeders = new SortedSet<string>();
            Dictionary<int, string> citiesByIndex = new Dictionary<int, string>();
            double[,] proximityMatrix = new double[citiesByIndex.Keys.Count, citiesByIndex.Keys.Count];
            BuildCities(cities, citiesByIndex);
            BuildCars(cars);
            proximityMatrix = BuildMatrix(citiesByIndex, cities);
            //var kuraMi = cars.Values.SelectMany(x => x).OrderBy(x => x.Item2);
            foreach (var licensePlate in cars)
            {
                
                string currentLP = licensePlate.Key;
                for (int i = 0; i < licensePlate.Value.Count-1; i++)
                {
                    string startTown = licensePlate.Value[i].Item1;
                    DateTime timeAtStart = licensePlate.Value[i].Item2;
                    int startIndex = 0;
                    for (int j = i+1; j < licensePlate.Value.Count; j++)
                    {

                        string nextTown = licensePlate.Value[j].Item1;
                        DateTime nextTime = licensePlate.Value[j].Item2;
                        double timePassed = Math.Abs((timeAtStart - nextTime).TotalHours);
                        int destinationIndex = 0;
                        for (int k = 0; k < citiesByIndex.Keys.Count; k++)
                        {
                            if (citiesByIndex[k] == startTown)
                            {
                                startIndex = k;
                            }
                            if (citiesByIndex[k] == nextTown)
                            {
                                destinationIndex = k;
                            }
                        }

                        if (!double.IsPositiveInfinity(proximityMatrix[startIndex, destinationIndex]) &&
                            proximityMatrix[startIndex, destinationIndex] > timePassed)
                        {
                            speeders.Add(currentLP);

                        }
                    }
                }
           

            }
            foreach (var item in speeders)
            {
                Console.WriteLine(item);
            }
            //foreach (var index in citiesByIndex)
            //{

            //    Console.WriteLine("At index {0} lies the city of {1}", index.Key, index.Value);
            //}

        }

        private static double[,] BuildMatrix(Dictionary<int, string> citiesByIndex, Dictionary<string, List<Tuple<string, double>>> cities)
        {
            int n = citiesByIndex.Keys.Count;
            double[,] proximityMatrix = new double[citiesByIndex.Keys.Count,citiesByIndex.Keys.Count];
            for (int from = 0; from < proximityMatrix.GetLength(0); from++)
            {
                for (int to = 0; to < proximityMatrix.GetLength(1); to++)
                {
                    if (from == to)
                    {
                        proximityMatrix[from, to] = 0;
                    }
                    else
                    {
                        string sourceTown = citiesByIndex[from];
                        string destinationTown = citiesByIndex[to];
                        var townSpecific = cities[sourceTown].FirstOrDefault(c => c.Item1 == destinationTown);
                        if (townSpecific != null)
                        {
                            proximityMatrix[from, to] = townSpecific.Item2;
                        }
                        else
                        {
                            proximityMatrix[from, to] = double.PositiveInfinity;
                        }
                    }
                }
            }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (proximityMatrix[i, k] + proximityMatrix[k, j] < proximityMatrix[i, j])
                        {
                            proximityMatrix[i, j] = proximityMatrix[i, k] + proximityMatrix[k, j];
                        }
                    }
                }
            }
            return proximityMatrix;
        }

        private static void BuildCars(Dictionary<string, List<Tuple<string, DateTime>>> cars)
        {
            string carsInfo = Console.ReadLine();
            while (carsInfo != "End")
            {
                string[] carsDetails = carsInfo.Split();
                string cityCam = carsDetails[0];
                string licensePlate = carsDetails[1];
                DateTime time = DateTime.Parse(carsDetails[2]);
                var camTime = new Tuple<string, DateTime>(cityCam, time);
                if (!cars.ContainsKey(licensePlate))
                {
                    cars[licensePlate] = new List<Tuple<string, DateTime>>();
                }
                cars[licensePlate].Add(camTime);
                carsInfo = Console.ReadLine();
            }
        }

        private static void BuildCities(Dictionary<string, List<Tuple<string, double>>> cities, Dictionary<int, string> citiesByIndex)
        {
            string information = Console.ReadLine();
            int index = 0;
            while (information != "Records:")
            {
                string[] citiesInfo = information.Split();
                string firstCity = citiesInfo[0];
                string secondCity = citiesInfo[1];


                double distance = double.Parse(citiesInfo[2]);
                double maxSpeedAllowed = double.Parse(citiesInfo[3]);
                double time = distance / maxSpeedAllowed;
                var firstCityTuple = new Tuple<string, double>(firstCity, time);
                var secondCityTuple = new Tuple<string, double>(secondCity, time);
                if (!cities.ContainsKey(firstCity))
                {
                    cities[firstCity] = new List<Tuple<string, double>>();
                    citiesByIndex[index] = firstCity;
                    index++;
                }

                cities[firstCity].Add(secondCityTuple);

                if (!cities.ContainsKey(secondCity))
                {
                    cities[secondCity] = new List<Tuple<string, double>>();
                    citiesByIndex[index] = secondCity;
                    index++;
                }

                cities[secondCity].Add(firstCityTuple);
                information = Console.ReadLine();
            }
        }


        private static void CitiesPrint(Dictionary<string, List<Tuple<string, double>>> cities)
        {
            foreach (var city in cities)
            {
                Console.WriteLine("From " + city.Key);
                foreach (var destinationCity in city.Value)
                {
                    Console.Write(" to " + destinationCity.Item1 + " for " + destinationCity.Item2 + " time");
                    Console.WriteLine();
                }
            }
        }
    }
}
