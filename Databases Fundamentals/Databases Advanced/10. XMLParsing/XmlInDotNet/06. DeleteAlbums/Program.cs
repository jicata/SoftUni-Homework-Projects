namespace _06.DeleteAlbums
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

            XmlNodeList albumsMoreExpensiveThan = root.SelectNodes("album[price>20.00]");
            foreach (XmlNode node in albumsMoreExpensiveThan)
            {
                root.RemoveChild(node);
            }

            xmlDoc.Save(@"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\10. XMLParsing\XmlInDotNet\cheapAssBooks.xml");
        }
    }
}
