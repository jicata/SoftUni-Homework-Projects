using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    interface IInterestCalculable
    {
        decimal CalculateInterest(int months);
    }
}
