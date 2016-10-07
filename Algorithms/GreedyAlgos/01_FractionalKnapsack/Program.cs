namespace _01_FractionalKnapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    public class MyComp : IComparer<double>
    {

        public int Compare(double x, double y)
        {
            if (x < y)
            {
                return 1;
            }
            else if (y < x)
            {
                return -1;
            }
            return 0;
        }
    }
    public class MyTupleComp : IComparer<Tuple<double, int>>
    {
        public int Compare(Tuple<double, int> x, Tuple<double, int> y)
        {
            if (x.Item1/x.Item2 < y.Item1/y.Item2)
            {
                return 1;
            }
            else if (y.Item1/y.Item2 < x.Item1/x.Item2)
            {
                return -1;
            }
            return 0;
        }
    }

    class Program
    {
        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split(':');
            int capacity = int.Parse(firstLine[1].Trim());

            string[] secondLine = Console.ReadLine().Split(':');
            int items = int.Parse(secondLine[1].Trim());

           // SortedDictionary<double, int> itemsPriceWeigth = new SortedDictionary<double, int>(new MyComp());
            List<Tuple<double, int>> alternative = new List<Tuple<double, int>>();

            for (int i = 0; i < items; i++)
            {
                string[] itemDetails = Console.ReadLine()
                    .Split(new char[] {'-', '>'}, StringSplitOptions.RemoveEmptyEntries);

                int itemValue = int.Parse(itemDetails[0]);
                int itemWeight = int.Parse(itemDetails[1]);

               // itemsPriceWeigth.Add(itemValue, itemWeight);
                alternative.Add(new Tuple<double, int>(itemValue, itemWeight));
            }

            alternative.Sort(new MyTupleComp());
            FractionalKnapsack(alternative, capacity);
        }

        private static void FractionalKnapsack(SortedDictionary<double, int> itemsPriceWeight, int capacity)
        {
            double currentWeight = 0;
            double totalPrice = 0;
            foreach (var itemPair in itemsPriceWeight)
            {
                if (currentWeight >= capacity)
                {
                    break;
                }
                double itemValue = itemPair.Key;
                int itemWeight = itemPair.Value;
                if (currentWeight + itemWeight <= capacity)
                {
                    currentWeight += itemWeight;
                    totalPrice += itemValue;
                    Console.WriteLine("Take 100% of item with price {0:F2} and weight {1:F2}", itemValue, itemWeight);
                }
                else
                {
                    double remainingCapacity = capacity - currentWeight;
                    double fraction = itemWeight - remainingCapacity;
                    currentWeight += remainingCapacity;
                    totalPrice += itemValue - ((fraction/itemWeight)*itemValue);
                    Console.WriteLine("Take {0:F2}% of item with price {1:F2} and weight {2:F2}", 100-(fraction/itemWeight)*100,itemValue, itemWeight);
                }
            }
            Console.WriteLine("Total price: {0:F2}", totalPrice);
        }
        private static void FractionalKnapsack(List<Tuple<double, int>> itemsPriceWeight, int capacity)
        {
            double currentWeight = 0;
            double totalPrice = 0;
            foreach (var itemPair in itemsPriceWeight)
            {
                if (currentWeight >= capacity)
                {
                    break;
                }
                double itemValue = itemPair.Item1;
                int itemWeight = itemPair.Item2;
                if (currentWeight + itemWeight <= capacity)
                {
                    currentWeight += itemWeight;
                    totalPrice += itemValue;
                    Console.WriteLine("Take 100% of item with price {0:F2} and weight {1:F2}", itemValue, itemWeight);
                }
                else
                {
                    double remainingCapacity = capacity - currentWeight;
                    double fraction = itemWeight - remainingCapacity;
                    currentWeight += remainingCapacity;
                    totalPrice += itemValue - ((fraction / itemWeight) * itemValue);
                    Console.WriteLine("Take {0:F2}% of item with price {1:F2} and weight {2:F2}", 100 - (fraction / itemWeight) * 100, itemValue, itemWeight);
                }
            }
            Console.WriteLine("Total price: {0:F2}", totalPrice);
        }
    }
}
