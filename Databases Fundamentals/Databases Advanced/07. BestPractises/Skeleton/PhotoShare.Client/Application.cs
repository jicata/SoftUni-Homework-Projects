namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Interfaces;
    using IO;
    using Models;
    using System.Data.Entity;
    using Data.Contracts;
    using Data.Repositories;

    class Application
    {
        static void Main()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            ICommandDispatcher commandDispatcher = new CommandDispatcher(unitOfWork);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IRunnable engine = new Engine(commandDispatcher, reader, writer);
            engine.Run("start");
        }
    }
}
