using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Interfaces;
using Blobs.Models.Attacks;

namespace Blobs.Engine.Factories
{
    class AttackFactory : IAttackFactory
    {
        public IAttack ManufactureAttack(string name)
        {
            switch (name)
            {
                case "PutridFart":
                    return  new PutridFartAttack();
                case "Blobplode":
                    return  new BlobplodeAttack();
                default:
                    throw new ArgumentException("Attack type not recognized");
            }
        }
    }
}
