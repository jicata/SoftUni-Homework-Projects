namespace _05_Sorting
{
    using System;
    public class Sequence : IComparable<Sequence>
    {
        private int[] collection;
        private int numberOfRotations;

        public Sequence(int[] collection, int numberOfRotations)
        {
            this.Collection = collection;
            this.NumberOfRotations = numberOfRotations;
        }

        public int[] Collection
        {
            get
            {
                return collection;
            }

            set
            {
                collection = value;
            }
        }

        public int NumberOfRotations
        {
            get
            {
                return numberOfRotations;
            }

            set
            {
                numberOfRotations = value;
            }
        }


        public int CompareTo(Sequence sequence)
        {
            if (this.Collection.Length < sequence.Collection.Length)
            {
                return -1;
            }
            else if (this.Collection.Length == sequence.Collection.Length)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
