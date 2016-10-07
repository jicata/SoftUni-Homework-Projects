using System;


namespace randomInput
{
    class randomInput
    {
        static void Main()
        {
            Console.WriteLine("Please choose a type: ");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");
            int input = int.Parse(Console.ReadLine());
            string placeHolder = String.Empty;
            int intInput = 0;
            double doubleInput = 0;

            switch (input)
            {
                case 1:
                case 2:
                    {
                        if (input == 1)
                        {
                            Console.WriteLine("Please enter an integer: ");
                            intInput = int.Parse(Console.ReadLine());
                            Console.WriteLine(intInput + 1);
                           
                        }
                        else if (input == 2)
                        {
                            Console.WriteLine("Please enter a double: ");
                            doubleInput = double.Parse(Console.ReadLine());
                            Console.WriteLine(doubleInput + 1);
                            

                        }
                        break;
                        
                    }
                case 3:
                    {
                        Console.WriteLine("Please enter a string: ");
                        placeHolder = Console.ReadLine();
                        Console.WriteLine(placeHolder);
                        break;
                    }
            }

        }
    }
}
