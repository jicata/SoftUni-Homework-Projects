namespace _03_CollectionOfProducts
{
    using System;
    public class Product : IComparable<Product>
    {
        private int id;
        private decimal price;
        private string title;
        private string supplier;

        public Product(int id, decimal price, string title, string supplier)
        {
            this.Id = id;
            this.Price = price;
            this.Title = title;
            this.Supplier = supplier;
        }

        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        public decimal Price
        {
            get { return price; }

            set { price = value; }
        }

        public string Title
        {
            get { return title; }

            set { title = value; }
        }

        public string Supplier
        {
            get { return supplier; }

            set { supplier = value; }
        }

        public override string ToString()
        {
            string result = string.Format("Product: {0} Price: {1} Supplier: {2} ID: {3}", this.title, this.price,
                this.supplier, this.id);
            return result;
        }

        public int CompareTo(Product other)
        {
            return this.id.CompareTo(other.id);
        }
    }
}
