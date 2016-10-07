using System;
using Blobs.Interfaces;


namespace Blobs.Models.Attacks
{
    public class BlobplodeAttack : Attack
    {


       public BlobplodeAttack(int damage) 
            : base(damage)
        {
        }
        public BlobplodeAttack()
            : this(0)
        {
        }
        public override IAttack CreateAttack(IBlob blob)
        {
            blob.CurrentHealth = (int)Math.Ceiling(blob.CurrentHealth/2d);
            if (blob.CurrentHealth < 1)
            {
                blob.CurrentHealth = 1;
            }
            return new BlobplodeAttack(blob.CurrentDamage*2);
        }


    }
}
