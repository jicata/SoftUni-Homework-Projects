namespace Hands_of_cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
           
            Dictionary<string, Dictionary<int, HashSet<int>>> houseOfCards = new Dictionary<string, Dictionary<int, HashSet<int>>>();
            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] inputArgs = input.Split(new char[] { ',', ':', }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                if (!houseOfCards.ContainsKey(name))
                {
                    houseOfCards[name] = new Dictionary<int, HashSet<int>>();
                    for (int i = 1; i <= 4; i++)
                    {
                        houseOfCards[name].Add(i,new HashSet<int>());
                    }
                }
                for (int i = 1; i < inputArgs.Length; i++)
                {
                    string card = inputArgs[i].Trim();
                    int suitePower = 0;
                    int cardFace = 0;
                    if (card.Length > 2)
                    {
                        suitePower = GetSuite(card[2].ToString());
                        cardFace = GetFace(card.Substring(0, 2));
                    }
                    else
                    {
                        suitePower = GetSuite(card.Substring(1));
                        cardFace = GetFace(card.Substring(0, 1));
                    }

                   
                    if (!houseOfCards[name][suitePower].Contains(cardFace))
                    {
                        houseOfCards[name][suitePower].Add(cardFace);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var houseOfCard in houseOfCards)
            {
                int sum = 0;
                foreach (var innerPair in houseOfCard.Value)
                {
                    sum += innerPair.Key*innerPair.Value.Sum();
                }
                Console.WriteLine("{0}: {1}", houseOfCard.Key, sum);
                
            }
        }

        private static int GetFace(string face)
        {
            switch (face)
            {
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return int.Parse(face);
            }
        }

        private static int GetSuite(string suite)
        {
            switch (suite)
            {
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
                case "C":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}
