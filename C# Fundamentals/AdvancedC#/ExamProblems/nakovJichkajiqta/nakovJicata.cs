using System;


namespace nakovJichkajiqta
{
    class nakovJicata
    {
        static void Main()
        {
            double cables = double.Parse(Console.ReadLine());

            double workableCables = cables;
            double cableLength = 0;
            string cableMeasure = "";
            double totalCableLength = 0;
            double remainingCable = 0;
            double studentCable = 0;


            for (int i = 0; i < cables; i++)
            {
                cableLength = double.Parse(Console.ReadLine());
                cableMeasure = Console.ReadLine();
                if (cableMeasure == "centimeters")
                {
                    if (cableLength < 20)
                    {
                        workableCables--;
                        continue;
                    }
                }
                if (cableMeasure == "meters")
                {
                    cableLength *= 100;
                }
                totalCableLength += cableLength;

            }
            totalCableLength = totalCableLength - 3 * (workableCables - 1);
            remainingCable = totalCableLength % 504;
            studentCable = (totalCableLength - remainingCable) / 504;

            Console.WriteLine(studentCable);
            Console.WriteLine(remainingCable);
        }
    }
}
