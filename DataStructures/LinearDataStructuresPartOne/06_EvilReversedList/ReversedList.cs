namespace _06_EvilReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] arrayList;
        private int currentIndex;

        public ReversedList()
        {
            this.arrayList = new T[8];
            this.currentIndex = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count())
                {
                    throw new ArgumentOutOfRangeException("Index was outside the bounds of the collection");
                }
                return this.arrayList[this.Count() - index];
            }
            set
            {
                if (index < 0 || index > this.Count())
                {
                    throw new ArgumentOutOfRangeException("Index was outside the bounds of the collection");
                }
                this.arrayList[this.Count() - index] = value;
            }
            
        }

        public void Add(T element)
        {
            if (this.currentIndex >= this.arrayList.Length)
            {
                int newLength = this.arrayList.Length * 2;
                T[] newArrayList = new T[newLength];
                Array.Copy(this.arrayList, newArrayList,this.arrayList.Length);
                this.arrayList = newArrayList;
            }
            this.arrayList[this.currentIndex] = element;
            this.currentIndex++;

        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.Count())
            {
                throw new ArgumentOutOfRangeException("Index was outside the bounds of the collection");
            }

            T temp = default(T);
            this.arrayList[this.Count() - index] = temp;
        }

        public int Count()
        {
            return this.currentIndex;
        }

        public int Capacity()
        {
            return this.arrayList.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            T item = this.arrayList[index];
            while (index != this.currentIndex)
            {
                item = this.arrayList[index];
                yield return item;
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
