namespace _04_LinkedListBasedStack
{
    using System;
    using System.Collections.Generic;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count { get; set; }

        public void Push(T element)
        {
            var newNode = new Node<T>(element);
            newNode.NextNode = this.firstNode;
            this.firstNode = newNode;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty stack");
            }
            var element = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
            List<T> ocb = new List<T>();
            var currentNode = this.firstNode;
            while (currentNode != null)
            {
                ocb.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            T[] arrayche = ocb.ToArray();
            return arrayche;
        }
       

    }
}
