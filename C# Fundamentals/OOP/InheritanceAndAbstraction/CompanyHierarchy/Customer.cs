using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public class Customer : Person, IPurchasable
    {
        private decimal netPurchase;
        public Customer(string firstName, string lastName, int id)
            : base(firstName, lastName, id)
        {
           
        }
        public decimal NetPurchase
        {
            get { return netPurchase; }
        }

        public void Purchase(Sale item)
        {
            this.netPurchase += item.Price;
        }

    }
}
