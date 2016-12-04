namespace ACTester
{
    using System;
    using ACTester.Core;
    using Models;

    public class ACTesterMain
    {
        public static void Main()
        {
            CarAirConditioner con1 = new CarAirConditioner("putka","maina", 420);
            CarAirConditioner con2 = con1;
            con2.Model = "Toshiba";
            Console.WriteLine(con1.Model);
            Console.WriteLine(con2.Model);
            return;
            var engine = new Engine();
            engine.Run();
        }
    }
}
