using System;
using Blobs.Interfaces;


namespace Blobs.Models.Behaviours
{
    public class InflatedBehaviour : Behaviour
    {
        public override void Trigger(IBlob blob)
        {
            blob.CurrentHealth += 50;
            IsTriggered = true;
        }

        public override void Apply(IBlob blob)
        {
            blob.CurrentHealth -= 10;
            if (blob.CurrentHealth <= 0)
            {
                blob.CurrentHealth = 0;
            }

        }
    }
}
