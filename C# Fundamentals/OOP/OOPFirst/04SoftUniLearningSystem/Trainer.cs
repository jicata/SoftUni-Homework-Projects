using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    public class Trainer : Person
    {
       
        public Trainer(string name, int age)
         : base(name, age)
        {

        }
        public virtual void CreateCourse(string course)
        {

        }
        public virtual void DeleteCourse(string course)
        {

        }
    }
}
