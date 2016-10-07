using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class Book
    {
        private string title;
        private string author;
        protected decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return title; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be null or empty");
                }
                title = value; }
        }
        public string Author
        {
            get { return author; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Author name cannot be null or empty");
                }
                author = value; }
        }
        public virtual decimal Price
        {
            get { return price; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                price = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: "+ this.GetType().Name);
            sb.Append("\n-Title: " + this.Title);
            sb.Append("\n-Author: " + this.Author);
            sb.Append("\n-Price: " + this.Price + "BGN\n");
            return sb.ToString();
            
        }

    }
}
