namespace _05.ArtistsAlbumsXpath
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

            foreach (var artist in artists)
            {
                XmlNodeList albumsByArtist = root.SelectNodes($@"album[artist = '{artist}']");
                Console.WriteLine("Artist: {0}, album count: {1}", artist, albumsByArtist.Count);
            }
        }
    }
}
