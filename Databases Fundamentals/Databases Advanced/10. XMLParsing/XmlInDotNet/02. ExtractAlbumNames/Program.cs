namespace _02.ExtractAlbumNames
{
    using System;
    using System.Linq;
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


            foreach (XmlNode childNode in root.ChildNodes)
            {
                foreach (XmlNode node in childNode.ChildNodes)
                {
                    if (node.Name == "name")
                    {
                        Console.WriteLine(node.InnerText);
                    }
                }
            }
        }
    }
}
