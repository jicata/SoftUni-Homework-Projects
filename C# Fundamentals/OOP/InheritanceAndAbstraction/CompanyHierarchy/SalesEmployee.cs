using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public class SalesEmployee : Employee
    {
        private List<Sale> sales;

        public SalesEmployee(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id, salary, "Sales")
        {
            this.sales = new List<Sale>();
        }

        public IEnumerable<Sale> Sales
        {
            get { return sales; }
        }

        public void AddSale(Sale sale)
        {
            this.sales.Add(sale);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-Name: " + this.FirstName + " " + this.LastName);
            sb.Append("\n-ID: " + this.Id);
            sb.Append("\n--Department: " + this.Department);
            sb.Append("\n--Salary: " + this.Salary);
            sb.Append("\n--Sales: ");
            if (this.sales.Count == 0)
            {
                sb.Append("None");
            }
            else
            {
                foreach (Sale sale in this.sales)
                {
                    sb.Append("\n" + sale.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
