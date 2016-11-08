namespace _03.AllArtistsAlphabetically
{
    using System;
    using System.Collections.Generic;
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


            SortedSet<string> artists = new SortedSet<string>();
            foreach (XmlNode childNode in root.ChildNodes)
            {
                foreach (XmlNode node in childNode.ChildNodes)
                {
                    if (node.Name == "artist")
                    {
                        artists.Add(node.InnerText);
                    }
                }
            }
            Console.WriteLine(string.Join("\n", artists));

        }
    }
}
