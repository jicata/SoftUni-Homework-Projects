﻿namespace _03_TreeIndexingWithInnerCount
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;
        public Node(T value)
        {
            this.Value = value;
            this.Count = 1;
        }
        public T Value { get; set; }

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

        public Node<T> RightChild
        {
            get { return this.rightChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }
                this.rightChild = value;
            }
        }
        public Node<T> Parent { get; set; }
        public int BalanceFactor { get; set; }
        public int Count { get; set; }

        public int CompareTo(T other)
        {
            return this.CompareTo(other);
        }

        public void ModifyCount()
        {
            int leftCount = 0;
            int rightCount = 0;
            if (this.leftChild != null)
            {
                leftCount = this.leftChild.Count;
            }
            if (this.rightChild != null)
            {
                rightCount = this.rightChild.Count;
            }
            this.Count = leftCount + 1 + rightCount;
        }

        public bool IsLeftChild
        {
            get
            {
                if (this.Parent != null)
                {
                    return this.Value.CompareTo(this.Parent.Value) < 0;
                }
                return false;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent != null)
                {
                    return this.Value.CompareTo(this.Parent.Value) > 0;
                }
                return false;
            }
        }

        public int ChildrenCount
        {
            get
            {
                int count = 0;
                if (this.leftChild != null)
                {
                    count++;
                }
                if (this.rightChild != null)
                {
                    count++;
                }
                return count;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}

