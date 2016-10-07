using System;


namespace goshoLudaka
{
    class chessBruh
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int count = 0;
            string inputString = Console.ReadLine();
            string trimmedInput = inputString.Replace(" ", string.Empty);
            char[] storedSymbolValue  = new char[inputString.Length];
            int black = 0;
            int white = 0;
            int symbolValue = 0;




            for (int i = 0; i < inputString.Length; i++)
            {
                
                    if (inputString[i] >= 'a' && inputString[i] <= 'z')
                    {
                        storedSymbolValue[i] = inputString[i];

                    }
                    else if (inputString[i] >= 'A' && inputString[i] <= 'Z')
                    {

                        storedSymbolValue[i] = inputString[i];

                    }
                    else if (inputString[i] >= '0' && inputString[i] <= '9')
                    {
                        storedSymbolValue[i] = inputString[i];
                        
                    }
                    else
                    {
                        storedSymbolValue[i] = '\0';
                    }



                   

            }

           
            for (int i = 0; i < size*size; i++)
            {
               if (i<= storedSymbolValue.Length -1)
               {
                   if ( i == 0 || i % 2 == 0)
                   {
                       if (storedSymbolValue[i] >= 'A' && storedSymbolValue[i] <= 'Z')
                       {
                           white += storedSymbolValue[i];
                         //  Console.WriteLine("White({1}) + {0} = {1}", (int)storedSymbolValue[i], white);
                       }
                       else
                       {
                           black += storedSymbolValue[i];
                       }
                       //Console.WriteLine("Black({1}) + {0} = {1}", (int)storedSymbolValue[i], black);
                   }
                   else
                   {
                       if (storedSymbolValue[i] >= 'A' && storedSymbolValue[i] <= 'Z')
                       {
                           black += storedSymbolValue[i];
                         //  Console.WriteLine("Black({1}) + {0} = {1}", (int)storedSymbolValue[i], black);
                       }
                       else
                       {
                           white += storedSymbolValue[i];
                       }
                       //Console.WriteLine("White({1}) + {0} = {1}", (int)storedSymbolValue[i], white);
                   }
                   
               }
               
             

            }
            if (white == black)
            {
                Console.WriteLine("Equal result: {0}", white);
            }
            else if(white > black)
            {
                Console.WriteLine("The winner is: white team");
                Console.WriteLine(white-black);
            }
            else
            {
                Console.WriteLine("The winner is: black team");
                Console.WriteLine(black - white);
            }
           
           

        }
    }
}
