using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Warrior : Character, IAttack
    {
        private int attackPoints;

        public Warrior(string id, int x, int y, Team team)
            :base(id,x,y,200, 100, team,2)
        {
            this.AttackPoints = 150;
        }
        public int AttackPoints
        {
            get { return attackPoints; }
            set {attackPoints = value;}
            
        }
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character coal = targetsList.FirstOrDefault(x => x is Character && x != this && x.Team != this.Team && x.IsAlive);
            return coal;
        }
        protected override void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.AttackPoints -= item.AttackEffect;
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }
        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);

        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }
        public override string ToString()
        {
            return string.Format(
                "Name: {0}, Team: {2}, Health: {1}, Defense: {3}, Attack: {4}",
                this.Id,
                this.HealthPoints,
                this.Team,
                this.DefensePoints,
                this.AttackPoints);
        }

    }
}
