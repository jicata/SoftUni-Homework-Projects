namespace SalesDatabase
{
    using System;
    using System.Linq;
    using Data;

    class Program
    {
        static void Main(string[] args)
        {
           SalesContext context = new SalesContext();

            context.Sales.Count();
        }
    }
}
