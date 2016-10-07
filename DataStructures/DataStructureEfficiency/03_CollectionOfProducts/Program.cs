
namespace _03_CollectionOfProducts
{
    using System;

    class Program
    {
        static void Main()
        {
            var collection = new ProductCollection();
            collection.Add(1,5,"kur","bashta ti");
            collection.Add(2, 6, "sliva","dvora");
            collection.Add(3,7, "oshte malko","hipodil");
            collection.Add(3, 7, "oshte malkoWE", "hipodil");
            collection.Add(3,10,"Izumrud","GLOBAL MUSIC");
            collection.Add(4,4,"choveche","stiga veche");
            collection.Add(7,6, "Mura","Vafla");
            collection.Add(8,8,"Mura","Kura");
            collection.Add(9,10,"Mura","TiSiZnaes");

            var range = collection.FindRange(4, 6);
            foreach (var product in range)
            {
                Console.WriteLine(product);
            }
        }
    }

}
