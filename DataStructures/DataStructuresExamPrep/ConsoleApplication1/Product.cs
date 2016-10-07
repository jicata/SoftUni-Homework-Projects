namespace ConsoleApplication1
{
    using System;
    public class Product : IComparable<Product>
    {
        private string name;
        private decimal price;
        private string producer;

        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
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

        public decimal Price
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

        public string Producer
        {
            get
            {
                return producer;
            }

            set
            {
                producer = value;
            }
        }

        public int CompareTo(Product other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            if (this.Producer.CompareTo(other.Producer) != 0)
            {
                return this.Producer.CompareTo(other.Producer);
            }
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            string result = string.Format("{0}{1};{2};{3:F2}{4}","{",this.Name,this.Producer, this.Price,"}");
            return result;
        }
    }
}
