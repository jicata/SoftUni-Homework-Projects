using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    class KurtovoKonare
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount acc1 = new DepositAccount("Individual", 100, 1.2);
                BankAccount acc2 = new LoanAccount("Company", 2000, 2.2);
                BankAccount acc3 = new MortgageAccount("Individual", 6969, 3.3);
                BankAccount acc4 = new DepositAccount("Company", 1001, 3.3);

                BankAccount[] bankAccounts = {acc1, acc2, acc3, acc4 };

                foreach (IInterestCalculable acc in bankAccounts)
                {
                    Console.WriteLine(acc.CalculateInterest(4));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            
        }
    }
}
