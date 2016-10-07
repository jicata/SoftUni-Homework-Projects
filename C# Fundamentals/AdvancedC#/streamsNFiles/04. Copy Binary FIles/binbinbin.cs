using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.Copy_Binary_FIles
{
    class binbinbin
    {
        static void Main()
        {
            string path = @"..\..\tooSober.jpg";
            string destination = @"..\..\utre.jpg";
            using (FileStream openFile = new FileStream(path, FileMode.Open))
            {
                using (FileStream copyFile = new FileStream(destination, FileMode.Create))
                {
                    //BinaryReader reader = new BinaryReader(openFile);
                    byte[] buffer = new byte[4096];
                    while(true)
                    {
                        int kappa = openFile.Read(buffer, 0, buffer.Length/4);
                        if (kappa == 0)
                        {
                            break;
                        }
                        copyFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
