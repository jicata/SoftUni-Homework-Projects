namespace _08.OldAlbumsLINQ
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            string xmlPath =
     @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\10. XMLParsing\XmlInDotNet\catalog.xml";
            XDocument doc = XDocument.Load(xmlPath);

            var todo = doc.Descendants().Elements("album");
            var oldAlbums = doc.Descendants().Elements("album")
                .Where(d => int.Parse(d.Descendants().FirstOrDefault(p => p.Name == "year").Value) < 2011)
                .Select(i => new {Name = i.Elements("name").First().Value, Price = i.Elements("price").First().Value});

            foreach (var oldAlbum in oldAlbums)
            {
                Console.WriteLine($@"{oldAlbum.Name} {oldAlbum.Price}");
            }

        }
    }
}
