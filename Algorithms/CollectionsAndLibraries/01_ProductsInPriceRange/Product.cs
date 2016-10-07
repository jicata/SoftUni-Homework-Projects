namespace _01_ProductsInPriceRange
{
    using System;
    public class Product :IComparable<Product>
    {
        string name;
        double price;

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
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

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        
        public int CompareTo(Product other)
        {
            return this.price.CompareTo(other.price);
        }
    }
}
