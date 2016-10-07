using System;
using System.Collections.Generic;

namespace Capitalism.Contracts
{
    public interface IEngine
    {
        ICommandExecutioner CommandExecutioner { get; }
        ICommandHandler CommandHandler { get; }
        ICollection<ICompany> Companies { get; }
        void Run();
    }
}
