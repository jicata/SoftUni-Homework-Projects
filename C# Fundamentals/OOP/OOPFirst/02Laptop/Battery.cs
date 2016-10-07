using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LaptopShop
{
    public class Battery
    {
        string type;
        double life;
        public Battery(string type, double life)
        {
            this.Type = type;
            this.Life = life;
        }
        public Battery(string type)
            : this(type, 0)
        {

        }
        public Battery()
            :this(null, 0)
        {

        }

        public string Type
        {
            get { return type; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Battery type must be specified!");
                }
                type = value; }
        }
        public double Life
        {
            get { return life; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Battery life cannot be negative!");
                }
                life = value; }
        }
    }
}
