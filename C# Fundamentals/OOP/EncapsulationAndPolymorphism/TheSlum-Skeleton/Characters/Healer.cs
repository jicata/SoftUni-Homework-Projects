using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        private int healingPoints;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = 60;
        }

        public int HealingPoints
        {
            get { return healingPoints; }
            set { healingPoints = value; }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character coal = targetsList.OrderBy(x=>x.HealthPoints).First(x=>x.Team == this.Team && x.IsAlive && x!=this);
            return coal;
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
                "Name: {0}, Team: {2}, Health: {1}, Defense: {3}, Healing: {4}",
                this.Id,
                this.HealthPoints,
                this.Team,
                this.DefensePoints,
                this.HealthPoints);
        }
    }
}
