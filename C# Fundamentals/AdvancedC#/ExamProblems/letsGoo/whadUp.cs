using System;


namespace letsGoo
{
    class whadUp
    {
        static void Main()
        {
            
            
            double fieldGoals = double.Parse(Console.ReadLine());
            int fieldGoalAttempts = int.Parse(Console.ReadLine());
            int theePointFieldGoal = int.Parse(Console.ReadLine());
            int turnOvers = int.Parse(Console.ReadLine());
            double offensiveRebounds = double.Parse(Console.ReadLine());
            double opponentDefRebounds = double.Parse(Console.ReadLine());
            double freeThrows = double.Parse(Console.ReadLine());
            int freeThrowAttempts = int.Parse(Console.ReadLine());


            double eFG = (fieldGoals + (0.5*theePointFieldGoal)) / fieldGoalAttempts;
            double TOV = turnOvers / (fieldGoalAttempts + (0.44 * freeThrowAttempts) + turnOvers);
            double ORB = offensiveRebounds  / (offensiveRebounds + opponentDefRebounds);
            double FT = freeThrows / fieldGoalAttempts;

            Console.WriteLine("eFG% {0:F3}", eFG);
            Console.WriteLine("TOV% {0:F3}", TOV);
            Console.WriteLine("ORB% {0:F3}", ORB);
            Console.WriteLine("FT% {0:F3}", FT);
           
        }
    }
}
