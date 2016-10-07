using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUniLearningSystem
{
    public class JuniorTrainer : Trainer
    {
        public JuniorTrainer(string name, int age)
            : base(name, age)
        {

        }
        public override void CreateCourse(string courseName)
        {
            Console.WriteLine(courseName + " course has been created and added to the cirriculum!");
        }
    }
}
