using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitalism.Contracts;
using Capitalism.Engine;

namespace Capitalism
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new OutputWriter();
            IReader reader = new InputReader();
            IEngine engine = new Engine.Engine(reader, writer);
            engine.Run();
        }
    }
}
