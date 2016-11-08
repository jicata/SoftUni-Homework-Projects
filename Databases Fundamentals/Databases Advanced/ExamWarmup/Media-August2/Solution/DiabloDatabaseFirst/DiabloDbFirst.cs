namespace DiabloDatabaseFirst
{
    using System;
    using System.Linq;

    public class DiabloDbFirst
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .Select(ch => ch.Name);

            foreach (var character in characters)
            {
                Console.WriteLine(character);
            }
        }
    }
}
