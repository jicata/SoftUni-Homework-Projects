using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebookR
{
    class zultiStampe
    {
        static void Main()
        {
            Dictionary<string,string> myPhoneBook = new Dictionary<string,string>();
            string rawUserInput = Console.ReadLine();
            while(rawUserInput != "search")
            {
                string[] userInput = rawUserInput.Split('-');
                myPhoneBook.Add(userInput[0], userInput[1]);
                rawUserInput = Console.ReadLine();
            }
            if (rawUserInput == "search")
            {
                string searchInput = Console.ReadLine();
                while(!string.IsNullOrEmpty(searchInput))
                {
                    if (myPhoneBook.ContainsKey(searchInput))
                    {
                        string value = myPhoneBook[searchInput];
                        Console.WriteLine("{0} --> {1}",searchInput, value);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist!", searchInput);
                    }
                    searchInput = Console.ReadLine();

                }

            }
        }
    }
}
