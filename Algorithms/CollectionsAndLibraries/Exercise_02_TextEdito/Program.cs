namespace Exercise_02_TextEdito
{
    using System;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            BigList<string> textEditorial = new BigList<string>();
            string command = Console.ReadLine();
            while (command != "exit")
            {
                string[] commandargs = command.Split(':');
                string commandName = commandargs[0];
                string stringToManipulate = "";
                if (commandargs.Length > 1)
                {
                    stringToManipulate = commandargs[1].Trim();
                }
                switch (commandName)
                {
                    case "INSERT":
                        textEditorial.AddToFront(stringToManipulate);
                        Console.WriteLine("OK");
                        break;
                    case "APPEND":
                        textEditorial.Add(stringToManipulate);
                        Console.WriteLine("OK");
                        break;
                    case "DELETE":
                        string[] deletionRange = stringToManipulate.Split(',');
                        int from = int.Parse(deletionRange[0]);
                        int count = int.Parse(deletionRange[1]);
                        try
                        {
                            textEditorial.RemoveRange(from, count);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("ERROR");
                        }
                        break;
                    case "PRINT":
                        Console.WriteLine(string.Join(" ", textEditorial));
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
