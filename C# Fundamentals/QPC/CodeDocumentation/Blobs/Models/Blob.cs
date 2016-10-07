using System;
using System.Runtime.CompilerServices;
using System.Text;
using Blobs.Interfaces;


namespace Blobs.Models
{
    public class Blob : IBlob
    {
        private int damage;
        private int health;
        private string name;

        public Blob(string name, int health,int damage, IBehaviour behaviour, IAttack attack)
        {
            Damage = damage;
            Health = health;
            Name = name;
            Behaviour = behaviour;
            Attack = attack;
            CurrentDamage = damage;
            CurrentHealth = health;
        }

        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Blob's damage cannot be negative or 0"); // COMMENT: value could be 0 in further expansions of the program
                }
                damage = value;
            }
        }
        
        
        public int Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Health cannot be negative ot 0");
                }
                health = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentException("Blob's name cannot be null or empty");
                }
                name = value;
            }
        }
        public int CurrentHealth { get; set; }
        public int CurrentDamage { get; set; }
        public bool IsUpdated { get; set; }
        public IBehaviour Behaviour { get; }
        public IAttack Attack { get; }


        public void UpdateBehaviour()
        {
            if (this.CurrentHealth <= this.Health / 2 && !this.Behaviour.IsTriggered)
            {
                this.Behaviour.Trigger(this);
                this.IsUpdated = true;
                Console.WriteLine(String.Format("{0} triggered {1}", this.Name, this.Behaviour.GetType().Name));
            }
            else if (Behaviour.IsTriggered)
            {
                this.Behaviour.Apply(this);
                this.IsUpdated = true;
            }
        }


        public override string ToString()
        {
           
            StringBuilder sb = new StringBuilder();
            if (this.CurrentHealth > 0)
            {
                sb.Append(String.Format("Blob {0}: {1} HP, {2} Damage", this.Name, this.CurrentHealth,
                    this.CurrentDamage));
            }
            if (this.CurrentHealth <= 0)
            {
                sb.Append(String.Format("Blob {0} KILLED", this.Name));
            }
            return sb.ToString();

        }
    }
}
