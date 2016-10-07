namespace _01_ProductsInPriceRange
{
    using System;
    using System.Security.Cryptography;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
           OrderedMultiDictionary<double, string> productsByPrice = new OrderedMultiDictionary<double, string>(true);

            string[] products = new[]
            {
                "milk", "banana", "beer", "lukanka", "banski starec", "tarator", "mastika", "djonga", "koker shpaniol"
            };

            double[] prices = new[]
            {
                0.1, 3.4, 13.37, 0.20, 1.2, 2.50, 15, 50, 100
            };
            int maxIndexProducts = products.Length;
            int maxIndexPrices = prices.Length;

            Random rng = new Random();

            int product = rng.Next(0, maxIndexProducts);
            int price = rng.Next(0, maxIndexPrices);

            for (int i = 0; i < 50; i++)
            {
                productsByPrice[prices[price]].Add(products[product]);
                rng = new Random(i*i);
                product = rng.Next(0, maxIndexProducts);
                price= rng.Next(0, maxIndexPrices);
            }
            for (int i = 0; i < 10; i++)
            {
                rng = new Random(i*i);
                int secondPrice = rng.Next(0, maxIndexPrices);
                price = rng.Next(0, maxIndexPrices);
                var range = productsByPrice.Range(prices[price], true,prices[secondPrice], true);
              

                int index = 0;
                foreach (var item in range)
                {
                    Console.WriteLine("Price: {0} БЪЛГАРСКИ ЛЕВА" , item.Key);
                    foreach (var innerItem in range[item.Key])
                    {
                        if (index >= 20)
                        {
                            break;
                        }
                        Console.WriteLine("--" + innerItem);
                        index++;
                    }
                    if (index >= 20)
                    {
                        break;
                    }
                }
                Console.WriteLine();
            }
            //ako ti vurje da nabarash djonga za 15, imam telefoni da znaesh
            
        }
    }
}
