using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LaptopShop
{
    class RestaRTcOMpuTers
    {
        static void Main(string[] args)
        {
            string model = "Lenovo 2 Yoga Pro";
            string manufacturer = "Lenovo";
            string processor = "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)";
            int RAM = 8;
            string GPU = "Intel HD Graphics 4400";
            string HDD = "128GB SSD";
            string screen = "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display";
            Battery battery = new Battery("Li-Ion, 4-cells, 2550 mAh");
            decimal price = -1;

            try
            {
                Laptop laptopka = new Laptop(model, price, manufacturer, processor, RAM, GPU, HDD, screen, battery);
                Console.WriteLine(laptopka.ToString());
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
