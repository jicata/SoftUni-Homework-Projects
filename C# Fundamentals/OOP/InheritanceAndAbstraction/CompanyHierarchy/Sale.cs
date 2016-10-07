using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
     public class Sale
    {
        string productName;
        DateTime date;
        decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }
        public string ProductName
        {
            get { return productName; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name cannot be empty");
                }
                productName = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { 
                if (value < 0){
                    throw new ArgumentException("Price cannot be negative");
                }
                price = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("---Product name: " + this.ProductName);
            sb.Append("\n---Product date: " + this.Date.ToLongDateString());
            sb.Append("\n---Product price: " + this.Price);
            return sb.ToString();
        }
    }
}
