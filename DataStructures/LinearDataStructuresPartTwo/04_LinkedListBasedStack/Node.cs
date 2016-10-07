namespace _04_LinkedListBasedStack
{
    public class Node<T>
    {
        private T value;
        private Node<T> nextNode;

        public Node(T value, Node<T> nextNode = null)
        {
            this.value = value;
            this.nextNode = nextNode;
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
