using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Returns an IEnumerable<string>.
        string[] files = Directory.GetFiles("../../");

        List<FileInfo> fileInfo = files.Select(x => new FileInfo(x)).ToList();
        var sortedFiles = fileInfo.OrderBy(x => x.Length).GroupBy(x => x.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // create report file
        StreamWriter writer = new StreamWriter(desktop + "/report.txt");
        foreach (var group in sortedFiles)
        {
            writer.WriteLine(group.Key);

            foreach (var y in group)
            {
                writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
            }
        }
        writer.Close();

        // open report file
        System.Diagnostics.Process.Start(desktop + "/report.txt");
    }
}
