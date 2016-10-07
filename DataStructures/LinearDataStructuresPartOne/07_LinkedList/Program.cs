namespace _07_LinkedList
{
    using System;

    class Program
    {
        static void Main()
        {
            LinkedList<int> kur = new LinkedList<int>();

            kur.Add(10); // first tenner
            kur.Add(20);
            kur.Add(30);
            kur.Add(40); // is removed, brings count down to 3
            kur.Add(50);
            kur.Add(20); // last twenty
            kur.Add(33); // brings count up to 6
            
            kur.Remove(4);

            Console.WriteLine(kur.FirstIndexOf(10));

            Console.WriteLine(kur.LastIndexOf(20));

            Console.WriteLine(kur.Count());


            foreach (var mado in kur)
            {
                Console.WriteLine(mado);
            }
        }
    }
}
