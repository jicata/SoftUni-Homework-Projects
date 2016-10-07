using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace genericMethodSort
{
    class genericMethod
    {
        static void Main()
        {
            string letsGo = "";
            DateTime[] dates = 
           {
            new DateTime(1992,9,23), new DateTime(2006,9,15), new DateTime(2015,9,23)
           };
            GenericSelectionSort(dates);
            letsGo = string.Join(", ", dates);
            Console.WriteLine(letsGo);
            Console.WriteLine("------------------");

            int[] someInts = { 2, 3, 1, 4, 5, 6, 12, 65, 231, 244, 23, 42, 2222 };
            GenericSelectionSort(someInts);
            letsGo = string.Join(", ", someInts);
            Console.WriteLine(letsGo);
            Console.WriteLine("------------------");


            string[] names = { "Матей", "Криси", "Сашето", "Jicata", "Дългия", "KoiLiNe", "MainataDetSediPonqkogaDoMen" };
            GenericSelectionSort(names);
            letsGo = string.Join(", ", names);
            Console.WriteLine(letsGo);
            Console.WriteLine("------------------");
            
        }
        public static T[] GenericSelectionSort<T>(T[] myArray) where T: IComparable

        {
            
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = i+1; j < myArray.Length; j++)
                {
                    
                    if (myArray[j].CompareTo(myArray[i]) > 0)
                    {
                        T temp = myArray[i];
                        myArray[i] = myArray[j];
                        myArray[j] = temp;
                    }
                }
            }
            return myArray;

        }
    }
}
