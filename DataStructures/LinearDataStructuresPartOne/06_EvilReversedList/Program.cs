namespace _06_EvilReversedList
{
    using System;

    class Program
    {
        static void Main()
        {
            ReversedList<int> kur = new ReversedList<int>();
            for (int i = 1; i < 10; i++)
            {
                kur.Add(i);
            }
            Console.WriteLine(kur.Count());

            Console.WriteLine(kur.Capacity());

            Console.WriteLine(kur[9]);

            kur.Remove(4);

            foreach (var asd in kur)
            {
                Console.WriteLine(asd);
            }
        }
    }
}
