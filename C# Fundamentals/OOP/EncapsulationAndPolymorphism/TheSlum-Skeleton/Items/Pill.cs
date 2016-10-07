using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
   public  class Pill : Bonus
    {
       public Pill(string id)
           : base(id, 0,0, 100, 1)
       {

       }
    }
}
