namespace _05_DoublyLinkedListBasedStack
{

    public class Node<T>
    {
        private T value;
        private Node<T> prevNode;
        private Node<T> nextNode;

        public Node(T value, Node<T> prevNode=null, Node<T> nextNode=null)
        {
            this.Value = value;
            this.PrevNode = prevNode;
            this.NextNode = nextNode;
        }
        public T Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public Node<T> PrevNode
        {
            get
            {
                return prevNode;
            }

            set
            {
                prevNode = value;
            }
        }

        public Node<T> NextNode
        {
            get
            {
                return nextNode;
            }

            set
            {
                nextNode = value;
            }
        }
    }
}
