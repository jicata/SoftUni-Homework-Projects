using System;


namespace detectiveBoev
{
    class strezovWe
    {
        static void Main()
        {
            string codeWord = Console.ReadLine();
            string encryptedMsg = Console.ReadLine();

            int sumOfCodeSymbols = 0;
            string sumString = "";
            int finalSum = 0;
            char[] encryptedCharAr = encryptedMsg.ToCharArray();
            char[] decryptedSymbols = new char[encryptedMsg.Length];
            int workWithIt = 0;
            

            foreach (char symbol in codeWord)
            {
                sumOfCodeSymbols += symbol;
            }
            sumString = sumOfCodeSymbols.ToString();
           

            foreach (char digit in sumString)
            {
                finalSum += Convert.ToInt32(digit.ToString());

            }
           
           
            
            while (finalSum > 9) 
            {
                sumString = finalSum.ToString();
                finalSum = 0;

                foreach (char digit in sumString)
                {
                    finalSum += Convert.ToInt32(digit.ToString());

                }
            }
            for (int i = 0; i < encryptedCharAr.Length; i++)
            {
                if (encryptedCharAr[i] % finalSum == 0)
                {
                    decryptedSymbols[i] = (char)(encryptedCharAr[i] + finalSum);
                }
                else
                {
                    decryptedSymbols[i] = (char)(encryptedCharAr[i] - finalSum);
                }
            }
            Array.Reverse(decryptedSymbols);
            for (int i = 0; i < decryptedSymbols.Length; i++)
            {
                Console.Write(decryptedSymbols[i]);
            }

            Console.WriteLine();

            
            
        }
    }
}
