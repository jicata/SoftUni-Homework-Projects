using System;
using Blobs.Interfaces;
using Blobs.Models;
using Blobs.Models.Behaviours;


namespace Blobs.Engine.Factories
{
    public class BehaviourFactory : IBehaviourFactory
    {
        public IBehaviour CreateBehaviour(string name)
        {
            switch (name)
            {
                case "Inflated":
                    return new InflatedBehaviour();
                case "Aggressive":
                    return new AggressiveBehaviour();
                default:
                    throw new ArgumentException("Behaviour type not recognized");

            }
        }
    }
}
