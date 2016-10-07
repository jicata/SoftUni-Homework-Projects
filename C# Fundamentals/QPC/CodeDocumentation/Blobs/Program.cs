using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Engine;
using Blobs.Engine.Factories;
using Blobs.Interfaces;
using Blobs.Models;

namespace Blobs
{
    class Program
    {
        static void Main(string[] args)
        {
            ICombatHandler combatHandler = new CombatHandler();

            IOutputWriter writer = new OutputWriter();
            IInputReader reader = new InputReader();

            IBehaviourFactory behaviourFactory = new BehaviourFactory();
            IBlobFactory blobFactory = new BlobFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IEngine engine = new Engine.Engine(reader, writer, blobFactory,behaviourFactory,attackFactory, combatHandler);
            engine.Run();
        }
    }
}
