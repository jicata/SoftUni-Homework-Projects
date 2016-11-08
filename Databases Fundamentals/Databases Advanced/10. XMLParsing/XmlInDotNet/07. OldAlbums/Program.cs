namespace _07.OldAlbums
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            string xmlPath =
     @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\10. XMLParsing\XmlInDotNet\catalog.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            XmlNode root = xmlDoc.DocumentElement;

            XmlNodeList albumsMoreExpensiveThan = root.SelectNodes("album[year<2011]");
            foreach (XmlNode albumNode in albumsMoreExpensiveThan)
            {
                Console.WriteLine($@"Title: {albumNode["name"].InnerText}, Price: {albumNode["price"].InnerText}");
            }
        }
    }
}
