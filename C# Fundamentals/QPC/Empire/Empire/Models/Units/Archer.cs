using System;


namespace Empire.Models.Units
{
    public class Archer : Unit
    {
        private const string Type = "archer";
        private const int ArcherHealth = 25;
        private const int attack_Damage = 7;

        public Archer() 
            :  base(Type, ArcherHealth,attack_Damage)
        {
        }
    }
}
