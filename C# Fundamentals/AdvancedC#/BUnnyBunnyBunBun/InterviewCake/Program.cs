namespace InterviewCake
{
    using System;

    class Program
    {
        static void Main()
        {
            //stock_prices_yesterday = [10, 7, 9, 8, 11, 5]
            int[] stockPricesYesterday = new[] {10, 7, 9, 8, 11, 5,19};
            int maxProfit = Int32.MinValue;
           // maxProfit = MaxProfit(stockPricesYesterday, maxProfit);

            int minPrice = stockPricesYesterday[0];
            maxProfit = stockPricesYesterday[1] - stockPricesYesterday[0];
            for (int currentPrice = 1; currentPrice < stockPricesYesterday.Length; currentPrice++)
            {

               
                maxProfit = Math.Max(maxProfit, stockPricesYesterday[currentPrice] - minPrice);
                minPrice = Math.Min(minPrice, stockPricesYesterday[currentPrice]);
            }
           
            Console.WriteLine(maxProfit);
        }

        private static int MaxProfit(int[] stockPricesYesterday, int maxProfit)
        {
            for (int i = 0; i < stockPricesYesterday.Length; i++)
            {
                int boughtStock = stockPricesYesterday[i];
                if (i < stockPricesYesterday.Length - 1)
                {
                    for (int j = i + 1; j < stockPricesYesterday.Length; j++)
                    {
                        int soldStock = stockPricesYesterday[j];
                        int specificProfit = soldStock - boughtStock;
                        if (specificProfit > maxProfit)
                        {
                            maxProfit = specificProfit;
                        }
                    }
                }
            }
            return maxProfit;
        }
    }
}
