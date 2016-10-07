using System;


namespace TenYearsFromNow
{
    class Program
    {
        static void Main()
        {
            DateTime birthday = DateTime.Parse("09.23.1992");
            DateTime today = DateTime.Now;
            int age = today.Year - birthday.Year;
            if (
                today.Month < birthday.Month
                ||
                ((today.Month == birthday.Month)) && (today.Day < birthday.Day)
               )
            {
                age--;
            }
            Console.WriteLine("Today I am " + age + " years old. And in ten years from now I will be " + (age + 10) + " years old.");
        }
    }
}
