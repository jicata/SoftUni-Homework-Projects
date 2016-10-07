using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines methods for executing user-provided commands.
    /// </summary>
    public interface ICommandExecutor
    {
        IEngine Engine { get; }
        void ExecuteCommand(string command);
    }
}
