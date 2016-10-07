using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringLength
{
    class kaputnishte
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            string edit = string.Empty;
            
            StringBuilder edit3 = new StringBuilder();
            int spaceToEdit = 0;
            if (userInput.Length >= 20)
            {
                edit = userInput.Substring(0, 20);
                Console.WriteLine(edit);
            }
            else 
            {
                spaceToEdit = 20 - userInput.Length;
                edit3.Append(userInput);
                for (int i = 0; i < spaceToEdit; i++)
                {
                    edit3.Append('*');
                }
                Console.WriteLine(edit3);
            }
           
            
        }
    }
}
