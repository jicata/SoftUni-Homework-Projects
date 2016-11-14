
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BillsPaymentContext context = new BillsPaymentContext();
            context.Users.Count();
        }
    }
}
