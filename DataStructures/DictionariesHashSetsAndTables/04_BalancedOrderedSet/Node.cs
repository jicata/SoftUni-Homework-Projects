namespace _04_BalancedOrderedSet
{
    using System;

    public class Node<T> where T: IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rigthChild;
          
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public Node<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }
                this.leftChild = value;
            }
        }

        public Node<T> RigthChild
        {
            get { return this.rigthChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }
                this.rigthChild = value;
            }
        } 
        
        public int BalanceFactor { get; set; }

        public bool IsLeftChild
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }
                return this.Value.CompareTo(Parent.Value) < 0;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }
                return this.Value.CompareTo(Parent.Value) > 0;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}


