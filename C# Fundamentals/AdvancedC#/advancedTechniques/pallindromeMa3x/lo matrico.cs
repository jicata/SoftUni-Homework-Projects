using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pallindromeMa3x
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            string[,] palindromeda = new string[rows,col];
            string[] letters = {"a", "b", "c", "d", "e", "f", "g", "h", "i"};

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 0)
                    {
                        palindromeda[i, j] = string.Format("{0}{1}{0}", letters[i], letters[j]);

                    }
                    else if (i==1)
                    {
                        palindromeda[i, j] = string.Format("{0}{1}{0}", letters[i], letters[j+1]);

                    }
                    else 
                    {
                        palindromeda[i, j] = string.Format("{0}{1}{0}", letters[i], letters[j+2]);

                    }
                   
                    Console.Write("{0} ", palindromeda[i,j]);
                }
                Console.WriteLine();
            }

            //if (i == 0)
            //{
            //    string kuche = "";


            //    switch (j)
            //    {
            //        case 0: kuche = "a";
            //            break;
            //        case 1: kuche = "b";
            //            break;
            //        case 2: kuche = "c";
            //            break;
            //        case 3: kuche = "d";
            //            break;
            //        case 4: kuche = "e";
            //            break;
            //        case 5: kuche = "f";
            //            break;

            //    }
            //    string aCol = string.Format("{0}{1}{0}", "a", kuche);

            //    palindromeda[i, j] = aCol;

            //}
        }
    }
}
