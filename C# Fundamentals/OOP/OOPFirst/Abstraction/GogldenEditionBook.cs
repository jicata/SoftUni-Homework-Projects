using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class GogldenEditionBook : Book
    {
        
        public GogldenEditionBook(string title, string author, decimal price)
            : base(title, author, price)
        {

        }
        public override decimal Price
        {
            get 
            {
                return this.price * 1.3m; 
            }
            
        }
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("Type: " + this.GetType());
        //    sb.Append("\n-Title: " + this.Title);
        //    sb.Append("\n-Author: " + this.Author);
        //    sb.Append("\n-Price: " + this.Price+"BGN\n");
        //    return sb.ToString();
        //}

    }
}
