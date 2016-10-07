namespace _02_PhoneBook
{
    using System;
    using System.Collections.Generic;
    

    class Program
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "search")
            {
                string[] inputArgs = input.Split('-');
                string name = inputArgs[0];
                string number = inputArgs[1];
                if (phonebook.ContainsKey(name))
                {
                    phonebook[name] = number;
                }
                else
                {
                    phonebook.Add(name, number);
                }
                
                input = Console.ReadLine();
            }

            string searchCommand = Console.ReadLine();
            while (searchCommand != "stop")
            {
                if (phonebook.ContainsKey(searchCommand))
                {
                    Console.WriteLine("{0} -> {1}", searchCommand, phonebook[searchCommand]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", searchCommand);
                }
                searchCommand = Console.ReadLine();
            }
        }
    }
}
