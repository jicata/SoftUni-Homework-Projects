using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Tomcat : Cat
    {
        const string gender = "male";
        public Tomcat(string name, int age)
            : base(name, age, gender)
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("{0} had many a story to tell...but it was a rare occasion SUCH AS THIS, that he did", this.Name);
        }
    }
}
