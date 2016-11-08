namespace _04.ArtistsAndNumberOfAlbums
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

            Dictionary<string, int> artists = new Dictionary<string, int>();

            foreach (XmlNode childNode in root.ChildNodes)
            {
                foreach (XmlNode node in childNode.ChildNodes)
                {
                    if (node.Name == "artist")
                    {
                        if (!artists.ContainsKey(node.InnerText))
                        {
                            artists.Add(node.InnerText, 1);
                        }
                        else
                        {
                            artists[node.InnerText]++;
                        }
                    }
                }
            }
            foreach (var artist in artists)
            {
                Console.WriteLine("Artist: {0}, album count: {1}",artist.Key, artist.Value);
            }
        }
    }
}
