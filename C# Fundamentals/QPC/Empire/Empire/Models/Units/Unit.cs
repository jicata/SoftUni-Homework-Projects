using System;
using Empire.Interfaces;


namespace Empire.Models
{
    public abstract class Unit : IUnit
    {
        public int Health { get; private set; }
        public int AttackDamage { get; private set; }

        protected   Unit(string type, int health, int attackDamage)
        {
            
        }
    }
}
