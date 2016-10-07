using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Kitten : Cat
    {
        const string gender = "female";
        public Kitten(string name, int age)
            : base(name, age, gender)
        {

        }
        
    }
}
