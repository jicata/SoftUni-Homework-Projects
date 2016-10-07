using System;
using Blobs.Interfaces;


namespace Blobs.Models.Attacks
{
    public class PutridFartAttack : Attack
    {
        public PutridFartAttack(int damage) 
            : base(damage)
        {
        }
        public PutridFartAttack()
            : base(0)
        {
        }

        public override IAttack CreateAttack(IBlob blob)
        {
           return new PutridFartAttack(blob.CurrentDamage);
        }
    }
}
