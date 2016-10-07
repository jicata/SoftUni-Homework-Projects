namespace JustSomeDemos
{
    using System;
    using System.Collections.Generic;


    public abstract class Food
    {
        private string name;
        double nutritionalValue;
        public int calories;

        protected Food(string name, double nutritionalValue, int calories)
        {
            this.name = name;
            this.nutritionalValue = nutritionalValue;
            this.calories = calories;
        }

    }

    public class Seaweed : Food
    {
        public Seaweed(string name, double nutritionalValue, int calories) 
            : base(name, nutritionalValue, calories)
        {
        }
    }

    public class Slama : Seaweed
    {
        public Slama(string name, double nutritionalValue, int calories)
            : base(name, nutritionalValue, calories)
        {
        }
    }
    public abstract class Animal
    {
        string name;
        string favouriteFood;
        int age;

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public Animal(string name, string favouriteFood, int age)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
            this.Age = age;
        }

        public virtual string StateFavFood()
        {
            return this.favouriteFood;
        }

        public abstract void MakeNoise();
        public abstract void ConsumeFood(Food food);
    }
    public class Cow : Animal
    {
        private int bodyMassIndex = 15;
        public Cow(string name, string favouriteFood, int age)
            :base(name, favouriteFood,age)
        {
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Moo");
        }

        public override void ConsumeFood(Food food)
        {
            this.bodyMassIndex += food.calories/10;
        }
    }
    public class Penguin: Animal
    {
        public int numberOfWings;
        public int wingPower;

        public Penguin(string name, string favouriteFood, int age)
            :base(name, favouriteFood, age)
        {
        }

       
        public override void MakeNoise()
        {
            Console.WriteLine("Peep");
        }

        public override void ConsumeFood(Food food)
        {
            this.wingPower += food.calories;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal pingy = new Penguin("pingy","seaweed", 9);
            Animal betsy = new Cow("betsy", "slama", 7);
           
          
            List<Animal> animals = new List<Animal>();
            animals.Add(pingy);
            animals.Add(betsy);
            foreach (var animal in animals)
            {
                string favFood = animal.StateFavFood();
                animal.MakeNoise();
            }
           
            
        }
    }
}
