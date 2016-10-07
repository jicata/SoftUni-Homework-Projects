using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    public class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string name, int age)
            :base(name, age)
        {

        }
        public override void DeleteCourse(string courseName)
        {
            Console.WriteLine(courseName + " course has been removed from ther cirruculum!");
        }
    }
}
