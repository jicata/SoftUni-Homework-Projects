using System;
using Blobs.Interfaces;


namespace Blobs.Models
{
    public class CombatHandler : ICombatHandler
    {
        public IAttack ProduceAttack(IBlob blob)
        {
            var attack = blob.Attack.CreateAttack(blob);

            return attack;
        }
        public void PerformAttack(IBlob blob,IBlob target)
        {

            if (!blob.Behaviour.IsTriggered)
            {
                var attack = this.ProduceAttack(blob);
                blob.UpdateBehaviour();
                if (blob.Behaviour.IsTriggered)
                {
                    attack = blob.Attack.ModifyAttack(attack, blob);

                }
               this.RespondToAttack(target,attack);
                return;
            }
            else
            {
                var attack = this.ProduceAttack(blob);
                this.RespondToAttack(target,attack);
            }


        }
        public void RespondToAttack(IBlob blob,IAttack attack)
        {
            blob.CurrentHealth -= attack.Damage;
            if (blob.CurrentHealth <= 0)
            {
                blob.CurrentHealth = 0;
            }
            blob.UpdateBehaviour();
        }
    }
}
