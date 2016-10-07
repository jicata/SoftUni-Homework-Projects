using System;
using System.Collections.Generic;

namespace decryptLeMasage
{
    class tititi
    {
        static void Main()
        {
            string letsStart = Console.ReadLine();
            string emptyOne = string.Empty;
            
            string userInput = "";

            int count = 0;
            List<string> messages = new List<string>();
            char decryptedChar = ' ';
            string decryptedMessage = "";
            char specialChar = ' ';
            
          

            while (letsStart.ToUpper() != "START")
            {
                letsStart = Console.ReadLine();
              

            }
            while (userInput.ToUpper() != "END")
            {
                
                userInput = Console.ReadLine();
                
                if (userInput.ToUpper() == "END" || string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                else if (!string.IsNullOrWhiteSpace(userInput) && userInput.ToUpper() != "END")
                {
                    count++;
                }

                //
                //looping thru the input 
                //

                foreach (char symbol in userInput)
                {
                    //capital letter check
                    if (symbol >= 'A' && symbol < 'N')
                    {
                        decryptedChar = (char)(symbol + 13);

                        decryptedMessage += decryptedChar.ToString();
                    }
                    else if (symbol >= 'N' && symbol <= 'Z')
                    {
                        decryptedChar = (char)(symbol - 13);

                        decryptedMessage += decryptedChar.ToString();
                    }
                    //lower case check
                    else if (symbol >= 'a' && symbol < 'n')
                    {
                        decryptedChar = (char)(symbol + 13);

                        decryptedMessage += decryptedChar.ToString();
                    }
                    else if (symbol >= 'n' && symbol <= 'z')
                    {
                        decryptedChar = (char)(symbol - 13);

                        decryptedMessage += decryptedChar.ToString();
                    }
                    //numbers check
                    

                    else if (symbol >= '0' && symbol <= '9')
                    {
                        string oneThruNine = symbol.ToString();
                        decryptedMessage += oneThruNine;

                    }
                    //special symbols
                    if (!(symbol >= 'A' && symbol < 'N') &&
                        !(symbol >= 'N' && symbol <= 'Z') &&
                        !(symbol >= 'a' && symbol < 'n') &&
                        !(symbol >= 'n' && symbol <= 'z') &&
                        !(symbol >= '0' && symbol <= '9'))
                    {
                        switch (symbol)
                        {
                            case '+': specialChar = ' '; break;
                            case '%': specialChar = ','; break;
                            case '&': specialChar = '.'; break;
                            case '#': specialChar = '?'; break;
                            case '$': specialChar = '!'; break;


                        }
                        decryptedChar = specialChar;
                        decryptedMessage += decryptedChar.ToString();
                    }

                }

                char[] reversePsyche = decryptedMessage.ToCharArray();
                Array.Reverse(reversePsyche);
                string enigmaBusted = new string(reversePsyche);
                messages.Add(enigmaBusted);
                decryptedMessage = " ";



            }
           
            if (count == 0)
            {
                Console.WriteLine("No message received.");
            }
            else
            {
                Console.WriteLine("Total number of messages: {0}",count);
                foreach (var item in messages)
                {
                    Console.WriteLine(item);
                }
                
            }
        }
    }
}
