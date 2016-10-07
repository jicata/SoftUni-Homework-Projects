using System;


namespace petyaEKurva
{
    class qjHuiPetya
    {

        static void Main()
        {

            int sum = int.Parse(Console.ReadLine());
            int diff = int.Parse(Console.ReadLine());
            int abc = 0;
            int def = 0;
            int ghi = 0;
           
            int counter = 0;

            for (int i = 111; i <= 777; i++)
            {
                
                
                abc = i;
                def = abc + diff;
                ghi = def + diff;
                if (abc <= 777 && def <= 777 && ghi <= 777)
                {
                    if (!isLegitNumber(abc) || !isLegitNumber(def) || !isLegitNumber(ghi))
                    {
                        continue;
                    }
                    if (isSumLegit(abc, def, ghi, sum))
                    {
                        string one = abc.ToString();
                        string two = def.ToString();
                        string three = ghi.ToString();
                        string number = one + two + three;
                        Console.WriteLine(number);
                        counter++;
                    }
                }
             }
            if(counter == 0)
                {
                    Console.WriteLine("No");
                   
                }
            
            
        }

        private static bool isSumLegit(int num, int num1, int num2, int sum)
        {
            
            int thisSum = 0;

            string theWholeNumber = string.Format("{0}{1}{2}",num, num1, num2);
            foreach(char k in theWholeNumber)
            {
                int digit = int.Parse(k.ToString());
                thisSum += digit;
            }
            if (thisSum == sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool isLegitNumber(int num)
        {
                 string number = num.ToString();
                 int badNumbers = 0;
                 foreach (char j in number)
                 {
                     int digit = int.Parse(j.ToString());
                     if (1 > digit || digit > 7)
                     {
                         badNumbers++;
                     }
                 }
            if (badNumbers==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
    }
}
