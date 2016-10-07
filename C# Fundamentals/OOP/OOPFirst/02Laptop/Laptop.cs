using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LaptopShop
{
    class Laptop
    {
        //model, manufacturer, processor, RAM, graphics card, HDD, screen, battery, battery life 
        private string model;
        private decimal price;
        private string manufacturer;
        private string processor;
        private int Ram;
        private string graphicsCard;
        private string HDD;
        private string screen;
        private Battery battery;

        public Laptop(string model, decimal price, string manufacturer, string processor, int Ram, string graphicsCard, string HDD, string screen, Battery battery)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.RAM = Ram;
            this.GraphicsCard = graphicsCard;
            this.HDD1 = HDD;
            this.Screen = screen;
            this.battery = battery;
        }
        public Laptop(string model, decimal price, string manufacturer, string processor, int Ram, string graphicsCard)
            : this(model, price, manufacturer, processor, Ram, graphicsCard, null, null, null)
        {

        }
        public Laptop(string model, decimal price)
            : this(model, price,null, null, 0, null, null, null, null)
        {

        }

        public string Model
        {
            get { return model; }
            set {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Model cannot be empty string!");
                }
                model = value; }
        }
        public decimal Price
        {
            get { return price; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                price = value; }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            set {
                if (value!= null && value.Length == 0)
                {
                    throw new ArgumentException("Manufacturer cannot be empty string!");
                }
                manufacturer = value; }
        }
        public string Processor
        {
            get { return processor; }
            set {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Processor cannot be empty string!");
                } 
                processor = value;
            }
        }
        public int RAM
        {
            get { return Ram; }
            set { 
                if (value<0)
                {
                    throw new ArgumentException("RAM cannot be negative!");
                }
                Ram = value; }
        }
        public string GraphicsCard
        {
            get { return graphicsCard; }
            set {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Graphics Card cannot be empty string!");
                }
                graphicsCard = value; }
        }
        public string HDD1
        {
            get { return HDD; }
            set {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("HDD cannot be empty string!");
                }
                HDD = value; }
        }
        public string Screen
        {
            get { return screen; }
            set {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Screen cannot be empty string!");
                }
                screen = value; }
        }
        public Battery Battery
        {
            get { return battery; }
            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Model: " + this.Model);
            if (Manufacturer != null)
            {
                sb.Append("\nManufacturer: " + this.Manufacturer);
            }
            if (Processor != null)
            {
                sb.Append("\nProcessor: " + this.Processor);
            }
            if (RAM != 0)
            {
                sb.Append("\nRAM: " + this.RAM + "GB");
            }
            if (GraphicsCard != null)
            {
                sb.Append("\nGraphics Card: " + this.GraphicsCard);
            }
            if (HDD1 != null)
            {
                sb.Append("\nHDD: " + this.HDD1);
            }
            if (Screen != null)
            {
                sb.Append("\nScreen: " + this.Screen);
            }
            if (Battery != null)
            {
                if (Battery.Type != null)
                {
                    sb.Append("\nBattery: " + Battery.Type);
                }
                if (Battery.Life > 0 )
                {
                    sb.Append("\nBattery life: " + Battery.Life);
                }
                
            }
            sb.Append("\nPrice: " + this.Price + "lv");
            //string details = String.Format("Model: {0}\nPrice: {1}", Model, Price);
            return sb.ToString();
        }
        
        
        
        
    }
}
