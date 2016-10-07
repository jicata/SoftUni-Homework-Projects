using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace junkjunk
{
    class Program
    {
        static void Main()
        {
            string[] userArrayInput = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            List<string> collection = userArrayInput.ToList();
            string keyword = string.Empty;

            string instructions = Console.ReadLine();
            while (instructions != "end")
            {
                string[] specificInstructions = instructions.Split();
                keyword = specificInstructions[0];
                if (keyword == "reverse" || keyword == "sort")
                {
                    if (ValidIntstructionsFirst(specificInstructions, collection))
                    {
                        if (keyword == "reverse")
                        {
                            ReverseGear(specificInstructions, collection);
                        }
                        if (keyword == "sort")
                        {
                            SortGear(specificInstructions, collection);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                        instructions = Console.ReadLine();
                        continue;
                    }
                }
                if (keyword == "rollLeft" || keyword == "rollRight")
                {
                    if (ValidIntstructionsSecond(specificInstructions))
                    {
                        if (keyword == "rollLeft")
                        {
                            RollGearLeft(specificInstructions, collection);
                        }
                        if (keyword == "rollRight")
                        {
                            RollGearRight(specificInstructions, collection);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                        instructions = Console.ReadLine();
                        continue;
                    }
                }
                instructions = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", collection));

        }
        public static bool ValidIntstructionsFirst(string[] instr, List<string> collec)
        {
            bool valid = true;
            if (int.Parse(instr[2]) < 0 || int.Parse(instr[2]) >= collec.Count)
            {
                valid = false;
                return valid;
            }
            if (int.Parse(instr[4]) < 0 || int.Parse(instr[4]) > collec.Count)
            {
                valid = false;
                return valid;
            }
            if (int.Parse(instr[2]) + int.Parse(instr[4]) > collec.Count)
            {
                valid = false;
                return valid;

            }
            return valid;

        }
        public static bool ValidIntstructionsSecond(string[] instr)
        {
            bool valid = true;
            if (int.Parse(instr[1]) < 0)
            {
                valid = false;
                return valid;
            }
            return valid;
        }
        public static void ReverseGear(string[] instr, List<string> collec)
        {
            int start = int.Parse(instr[2]);
            int count = int.Parse(instr[4]);
            collec.Reverse(start, count);
        }
        public static void SortGear(string[] instr, List<string> collec)
        {
            int start = int.Parse(instr[2]);
            int count = int.Parse(instr[4]);
            collec.Sort(start, count, StringComparer.InvariantCulture);
        }
        public static void RollGearLeft(string[] instr, List<string> collec)
        {
            int rolltimes = int.Parse(instr[1]) % collec.Count;
            List<string> tempList = new List<string>(collec);
            for (int i = 0; i < tempList.Count; i++)
            {
                collec[i] = tempList[(i + rolltimes + tempList.Count) % tempList.Count];
            }
        }
        public static void RollGearRight(string[] instr, List<string> collec)
        {
            int rollTimes = int.Parse(instr[1]) % collec.Count;
            List<string> tempList = new List<string>();
            List<string> tempList2 = new List<string>();


            for (int i = collec.Count - rollTimes; i < collec.Count; i++)
            {
                tempList.Add(collec[i]);

            }
            for (int i = 0; i < collec.Count - rollTimes; i++)
            {
                tempList2.Add(collec[i]);
            }
            List<string> tempList3 = new List<string>(tempList.Concat(tempList2));

            for (int i = 0; i < tempList3.Count; i++)
            {
                collec[i] = tempList3[i];
            }
        }
    }
}
