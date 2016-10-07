using System;
using Blobs.Interfaces;
using Blobs.Models;


namespace Blobs.Engine
{
    public class BlobFactory :IBlobFactory
    {
        public IBlob CreateBlob(string name,int health, int damage, IBehaviour behaviour, IAttack attack)
        {
            return new Blob(name, health, damage, behaviour, attack);
        }
    }
}
