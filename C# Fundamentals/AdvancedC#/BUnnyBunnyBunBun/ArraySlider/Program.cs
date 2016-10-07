namespace ArraySlider
{
    using System;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            BigInteger[] slide = Console.ReadLine().Trim().Split(new []{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(x => BigInteger.Parse(x)).ToArray();

            string command = Console.ReadLine();
            int currentIndex = 0;

            while (command != "stop")
            {
                string[] commandArgs = command.Split();
                int offset = int.Parse(commandArgs[0]);
                char operatoR = char.Parse(commandArgs[1]);
                int operand = int.Parse(commandArgs[2]);

                currentIndex = DiscoverPoisiton(currentIndex, offset, slide);
                BigInteger numberToOperate = slide[currentIndex];
                BigInteger result = PerformOperation(numberToOperate, operatoR, operand);
                slide[currentIndex] = result;
                

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Format("[{0}]", string.Join(", ", slide)));
        }

        private static BigInteger PerformOperation(BigInteger numberToOperate, char operatoR, int operand)
        {
            BigInteger result = 0;
            switch (operatoR)
            {
                case '&':
                    result = numberToOperate & operand;
                    break;
                case '|':
                    result = numberToOperate | operand;
                    break;
                case '^':
                    result = numberToOperate ^ operand;
                    break;
                case '+':
                    result = numberToOperate + operand;
                    break;
                case '-':
                    result = numberToOperate - operand;
                    break;
                case '*':
                    result = numberToOperate*operand;
                    break;
                case '/':
                    if (operand > 0)
                    {
                        result = numberToOperate / operand;
                    }
                    break;
                default:
                    throw  new ArgumentException("Unrecognized operator");
            }
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }

        private static int DiscoverPoisiton(int currentIndex, int offset, BigInteger[] array)
        {

            int newIndex = (currentIndex + offset)%array.Length;
            if (newIndex < 0)
            {
                newIndex = array.Length - Math.Abs(newIndex);
            }
            return newIndex;
        }
    }
}
