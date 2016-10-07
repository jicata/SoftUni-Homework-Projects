using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            
               
            try
            {
                //components
                Component motherboard = new Component("Generic Motherboard", 50.0M);
                Component GPU = new Component("Generic GPU", 130.0M, "Generic as fuck");
                Component processor = new Component("Generic processor", 99.9M);
                Component headphones = new Component("KingstonHyperX", 69.69M, "IT'S JUST HYPERX");

                //computers
                Computer ShpekI = new Computer("Shpek I");
                Computer ShpekII = new Computer("Shprek II");
                Computer ShpekIII = new Computer("Master Shpek");
                ShpekI.AddComponentToConfig(motherboard);
                ShpekII.AddComponentToConfig(processor);
                ShpekII.AddComponentToConfig(GPU);
                ShpekIII.AddComponentToConfig(GPU);
                ShpekIII.AddComponentToConfig(headphones);

                //list of computers
                List<Computer> computers = new List<Computer>();
                computers.Add(ShpekI);
                computers.Add(ShpekII);
                computers.Add(ShpekIII);

                foreach (Computer config in computers.OrderBy(x => x.Price))
                {
                    config.ComponentsAndTotalPrice();
                    Console.WriteLine("---------------------");
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
