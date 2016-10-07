using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Catalog
{
    class Component
    {
        string name;
        List<string> details;
        decimal price;
        public Component(string name,decimal price, string detail)
        {
            this.Name = name;
            this.Price = price;
            this.details = new List<string>();
            this.details.Add(detail);

        }
        public Component(string name, decimal price)
            : this (name, price, null)
        {

        }
        public string Name
        {
            get { return name; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                name = value; }
        }
        public List<string> Details
        {
            get { return details; }
            
        }
        public decimal Price
        {
            get { return price; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Price of a component cannot be negative");
                }
                price = value; }
        }
        public void AddDetailToComponent(string detail)
        {
            this.details.Add(detail);
        }
        
        
    }
}
