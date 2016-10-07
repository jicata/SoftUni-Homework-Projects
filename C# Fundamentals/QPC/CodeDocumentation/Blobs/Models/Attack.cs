using System;
using Blobs.Interfaces;


namespace Blobs.Models
{
    public abstract class Attack : IAttack
    {
        protected Attack(int damage)
        {
            Damage = damage;
        }
        
        public int Damage { get; set; }
        public abstract IAttack CreateAttack(IBlob blob);
        
        
        public IAttack ModifyAttack(IAttack attack, IBlob blob)
        {
            string behaviourName = blob.Behaviour.GetType().Name.ToString();
            switch (behaviourName)
            {
                case "AggressiveBehaviour":
                    attack.Damage += blob.CurrentDamage;
                    return attack;
                case "InflatedBehaviour":
                    return attack;
                default:
                    throw  new ArgumentException("Unknown attack");
            }
        }
           }
}
