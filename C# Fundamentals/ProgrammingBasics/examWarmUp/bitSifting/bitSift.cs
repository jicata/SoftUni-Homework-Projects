using System;


namespace bitSifting
{
    class bitSift
    {
        static void Main()
        {
            //int a = 165;
            //int sieve = 138;
            //int sieve1 = 84;
            //int sieve2 = 154;

            //int penis = 0;
            //int chep = 0;

            //penis = a | sieve;
            //chep = penis ^ sieve;

            //penis = chep | sieve1;
            //chep = penis ^ sieve1;

            //penis = chep | sieve2;
            //chep = penis ^ sieve2;


            //Console.WriteLine(Convert.ToString(a, 2).PadLeft(8, '0'));
            //Console.WriteLine(Convert.ToString(sieve, 2).PadLeft(8, '0'));
            //Console.WriteLine(Convert.ToString(penis, 2).PadLeft(8,'0'));
            //Console.WriteLine(Convert.ToString(chep, 2).PadLeft(8, '0'));

           
            int zeroCounter = 0;
            ulong n = ulong.Parse(Console.ReadLine());
            int numberOfSieves = int.Parse(Console.ReadLine());
            if (numberOfSieves == 0)

            {
                for (int k = 0; k < 64; k++)
                {
                    ulong nee = n >> k;
                    ulong daa = nee & 1;
                    if (daa > 0)
                    {
                        zeroCounter++;

                    }
                    nee = 0;
                    daa = 0;
                }
                Console.WriteLine(zeroCounter);
             return;
            }

            ulong[] sieves = new ulong[numberOfSieves];

            for (int i = 0; i < numberOfSieves; i++)
            {
                sieves[i] = ulong.Parse(Console.ReadLine());
            }

            ulong sieveResult = 0;
            ulong cleanTheSieve = 0;
            int count = 0;

            
            for (int i = 0; i < sieves.Length; i++)
            {
                sieveResult = n | sieves[i];
                cleanTheSieve = sieveResult ^ sieves[i];
                n = cleanTheSieve;
                
                if (i == sieves.Length - 1)
                {
                    for (int j = 0; j < 64; j++)
                    {
                        ulong letsMove = cleanTheSieve >> j;
                       
                        ulong checkIt = letsMove & 1;
                        
                        
                        if (checkIt > 0 )
                        {
                            count++;
                        }
                        checkIt = 0;
                        letsMove = 0;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
