using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandInterpreterLegit
{
    class beepBoop
    {
        static void Main()
        {
            string[] userArray = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            List<string> collection = userArray.ToList();

            string command = Console.ReadLine();

            while(command != "end")
            {
                string[] specificCommands = command.Split();
                switch(specificCommands[0])
                {
                    case "reverse":
                        if (CheckIfValid(specificCommands, collection))
                        {
                            ReverseCommand(specificCommands, collection);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters");
                            command = Console.ReadLine();
                            continue;
                        }
                        break;

                    case "sort":
                        if (CheckIfValid(specificCommands, collection))
                        {
                            SortCommand(specificCommands, collection);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters");
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "rollLeft":
                        if (CheckIfValid2(specificCommands))
                        {
                            RollLeftCommand(specificCommands, collection);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters");
                            command = Console.ReadLine();
                            continue;
                        }
                        
                        break;
                    case "rollRight":
                        if (CheckIfValid2(specificCommands))
                        {
                            RollRightCommand(specificCommands, collection);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters");
                            command = Console.ReadLine();
                            continue;
                        }
                        
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", collection));
        }
        
        
        public static void ReverseCommand(string[] commands, List<string> collection)
        {
            int start = int.Parse(commands[2]);
            int count = int.Parse(commands[4]);
            collection.Reverse(start, count);
            
        }
        public static void SortCommand(string[] commands, List<string> collection)
        {
            int start = int.Parse(commands[2]);
            int count = int.Parse(commands[4]);
            collection.Sort(start, count, StringComparer.InvariantCulture);
        }
        public static void RollLeftCommand(string[] commands, List<string> collectionche)
        {

            int rollingTime = int.Parse(commands[1]);
            string[] newArray = new string[collectionche.Count];
            newArray = collectionche.ToArray();
            string[] tempArray = new string[newArray.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                collectionche[i] = newArray[(i + rollingTime + newArray.Length) % newArray.Length];
            }
           
            return;
            //for (int i = 0; i < theArray.Length; i++)
            //{
            //    tempArray[i] = theArray[(i + secondCount + theArray.Length) % theArray.Length];
            //}
                        

        }
        public static void RollRightCommand(string[] command, List<string> collection)
        {
            int rollingTime = int.Parse(collection[1]) % collection.Count;
            List<string> temp1 = new List<string>();
            List<string> temp2 = new List<string>();
            for (int i = collection.Count - rollingTime+1; i < collection.Count; i++)
            {
                temp1.Add(collection[i]);
            }
            for (int i = 0; i < collection.Count - rollingTime+1; i++)
            {
                temp2.Add(collection[i]);
            }
            List<string> newList = new List<string>(temp1.Concat(temp2));
            for (int i = 0; i < newList.Count; i++)
            {
                collection[i] = newList[i];
            }

        }
        public static bool CheckIfValid(string[] commands, List<string> collection)
        {
            bool flag = false;
            if (int.Parse(commands[2]) < 0 || int.Parse(commands[2]) > collection.Count)
            {
                
                return flag;
            }
            if (int.Parse(commands[4]) <= 0 || int.Parse(commands[4]) > collection.Count)
            {
               
                return flag;
            }
            flag = true;
            return flag;
        }
        public static bool CheckIfValid2(string[] commands)
        {
            bool flag = false;
            if (int.Parse(commands[1]) <= 0)
            {
                return flag;
            }
            flag = true;
            return flag;
            
            
        }
    }

}
