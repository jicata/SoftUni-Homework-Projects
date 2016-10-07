using System;


namespace Empire.Models.Units
{
    public class Swordsman : Unit
    {
        private const string Type = "swordsman";
        private const int SwordsmanHealth = 25;
        private const int attack_Damage = 7;

        public Swordsman()
            : base(Type, SwordsmanHealth, attack_Damage)
        {
        }
    }
}
