namespace _05_DoublyLinkedListBasedStack
{
    using System;
    using System.Collections.Generic;

    public class DoublyLinkedQueue<T>
    {
        private Node<T> Head { get; set; }

        private Node<T> Tail { get; set; }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newElement = new Node<T>(element);
            if (this.Count == 0)
            {
                this.Head = this.Tail = newElement;
            }
            else
            {
                this.Tail.NextNode = newElement;
                newElement.PrevNode = this.Tail;
                this.Tail = newElement;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot dequeue from empty queue");
            }
            var element = this.Head.Value;
            this.Head.Value = default(T);
            this.Head = this.Head.NextNode;
            if (this.Head != null)
            {
                this.Head.PrevNode = null;
            }
            else
            {
                this.Tail = null;
            }
            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
            List<T> ocb = new List<T>();
            var currentNode = this.Head;
            while (currentNode != null)
            {
                ocb.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            T[] ariec = ocb.ToArray();
            return ariec;
        }

    }
}
