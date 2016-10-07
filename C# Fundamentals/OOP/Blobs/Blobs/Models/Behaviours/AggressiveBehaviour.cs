using System;
using Blobs.Interfaces;


namespace Blobs.Models
{
    public class AggressiveBehaviour : Behaviour
    {
        public override void Trigger(IBlob blob)
        {
            blob.CurrentDamage = blob.CurrentDamage * 2;
            IsTriggered = true;
        }

        public override void Apply(IBlob blob)
        {
            blob.CurrentDamage -= 5;
            if (blob.CurrentDamage < blob.Damage)
            {
                blob.CurrentDamage = blob.Damage;
            }
        }
    }
}
