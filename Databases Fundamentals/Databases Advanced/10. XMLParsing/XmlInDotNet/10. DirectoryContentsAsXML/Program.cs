namespace _10.DirectoryContentsAsXML
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            string path = @"C:\Users\Maika\Documents\Books And Materials";
            string destinationPath =
                @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\10. XMLParsing\result.xml";
            XDocument doc = new XDocument(new XElement("root-dir"));
            doc.Root.Add(new XAttribute("path", path));
            GoDown(path, doc);
            doc.Save(destinationPath);
        }

        static void GoDown(string path, XDocument doc)
        {
            var folders = Directory.EnumerateDirectories(path);
            foreach (var folder in folders)
            {
             
                GoDown(folder,doc);

                int indexOf = folder.LastIndexOf(@"\");
                string folderNameTrimmed = folder.Substring(indexOf + 1);

                var files = Directory.EnumerateFiles(folder);

                var topElement = new XElement("dir",
                    new XAttribute("name", folderNameTrimmed));                   ;
                topElement.Add(from file in files
                               select new XElement("file", new XAttribute("name", file.Substring(file.LastIndexOf("\\") + 1))));

                doc.Root.Add(topElement);
            }
            
        }
    }
}
