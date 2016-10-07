namespace _03_ArrayBasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;


        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0; 
        }
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty stack");
            }
            this.Count--;
            T element = this.elements[Count];
            this.elements[Count] = default(T);
            return element;

        }

        public T[] ToArray()
        {
            T[] arrayEd = new T[Count];
            Array.Copy(this.elements,arrayEd, Count);
            Array.Reverse(arrayEd);
            return arrayEd;
        }

        private void Grow()
        {
            T[] newArray = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newArray, Count);
            this.elements = newArray;
        }

    }
}
