namespace ConsoleApplication1
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Dog kiro = new Dog();
            kiro.bark();
        }
    }


    public class Animal
    {
        public int kur = 101;
        public int legs = 4;

        public virtual void bark()
        {
            Console.WriteLine("djawwwwwf");
        }
    }

    public class Dog : Animal
    {
        public int age = 4;
        public int legs = 3;

        public override void bark()
        {
            Console.WriteLine("woof");
        }
    }

}
