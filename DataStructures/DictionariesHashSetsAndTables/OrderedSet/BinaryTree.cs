namespace OrderedSet
{
    using System;

    public class BinaryTree<T> where T : IComparable<T>
    {
        T value;
        BinaryTree<T> parent;
        BinaryTree<T> leftChild;
        BinaryTree<T> rightChild;


        public BinaryTree(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public BinaryTree<T> Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                this.parent = value;
            }
        }

        public BinaryTree<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }

            set
            {
                this.leftChild = value;
            }
        }

        public BinaryTree<T> RightChild
        {
            get
            {
                return this.rightChild;
            }

            set
            {
                this.rightChild = value;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.parent == null)
                {
                    return false;
                }
                return this.Value.CompareTo(this.parent.value) > 0;

            }
        }

        public bool IsLeftChild
        {
            get
            {
                if (this.parent == null)
                {
                    return false;
                }
                return this.Value.CompareTo(this.parent.value) < 0;
            }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
