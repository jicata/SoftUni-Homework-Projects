using System;


namespace Capitalism.Contracts
{
    public interface IEmployee
    {
        decimal SalaryFactor { get; }
        IDepartment Department { get; }
    }
}
