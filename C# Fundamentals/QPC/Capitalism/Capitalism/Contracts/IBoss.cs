using System;
using System.Collections.Generic;


namespace Capitalism.Contracts
{
    public interface IBoss
    {
        ICollection<IEmployee> Subordinates { get; } 
    }
}
