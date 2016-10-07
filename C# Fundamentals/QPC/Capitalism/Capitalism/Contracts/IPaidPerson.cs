using System;


namespace Capitalism.Contracts
{
    public interface IPaidPerson
    {
        string FirstName { get;  }
        string LastName { get; }
        decimal Salary { get; }
    }
}
