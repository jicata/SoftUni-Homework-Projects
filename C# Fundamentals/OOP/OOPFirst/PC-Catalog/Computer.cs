using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Catalog
{
    class Computer
    {
        string name;
        List<Component> components;
        decimal price;
        public Computer(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
            
           
        }
        
        public string Name
        {
            get { return name; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                name = value; 
            }
        }
        internal List<Component> Components
        {
            get { return components; }

        }   
        public decimal Price
        {
            get {return price; }
        }
        public void AddComponentToConfig(Component comp)
        {
            this.Components.Add(comp);
            this.price += comp.Price;
        }
        public void ComponentsAndTotalPrice()
        {
            if (this.Components.Count == 0)
            {
                throw new InvalidOperationException("The computer configuration does not contain any components yet!\nAdd components using the AddComponentsToConfig method");
            }
            Console.WriteLine("Configuration name: "+ this.Name);
            Console.WriteLine("Components: ");
            foreach (Component comp in this.Components)
            {
                Console.WriteLine("--Component's name: " +comp.Name);
                Console.WriteLine("--Component's price: " +comp.Price+"BGN");
                if (comp.Details[0] !=null)
                {
                    Console.WriteLine("--Component details:");
                    foreach (String detail in comp.Details)
                    {
                        Console.WriteLine("---->" +detail);
                    }
                }
                
                
            }
            Console.WriteLine("Total price: " + this.price +"BGN");
        }
    }
}
