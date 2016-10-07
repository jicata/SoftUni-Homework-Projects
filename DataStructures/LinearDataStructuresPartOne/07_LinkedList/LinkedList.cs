namespace _07_LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> Head { get; set; }
        private ListNode<T> Tail { get; set; }

        public void Add(T item)
        {
            if (this.Count() == 0)
            {
                this.Head = new ListNode<T>(item);
                this.Tail = this.Head;
                this.Head.NextNode = this.Tail;
                this.Tail.NextNode = null;
            }
            else
            {
                var newTail = new ListNode<T>(item);
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.Count())
            {
                throw new ArgumentOutOfRangeException("Index does not exist in the collection");
            }
            var currentNode = this.Head;
            for (int i = 1; i < index-1; i++)
            {
                currentNode = currentNode.NextNode;
            }
            currentNode.NextNode = currentNode.NextNode.NextNode;

        }

        public int Count()
        {
            var currentNode = this.Head;
            int count = 0;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.NextNode;
            }
            return count;
        }

        public int FirstIndexOf(T element)
        {
            var currentNode = this.Head;
            bool itExists = false;
            int count = 0;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(element))
                {
                    itExists = true;
                    break;
                }
                count++;
                currentNode = currentNode.NextNode;
            }

            if (!itExists)
            {
                return -1;
            }
            else
            {
                return count;
            }
        }

        public int LastIndexOf(T element)
        {
            var currentNode = this.Head;

            int count = 0;
            int lastIndex = 0;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(element))
                {
                    lastIndex = count;
                }
                count++;
                currentNode = currentNode.NextNode;
            }
            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    
}
