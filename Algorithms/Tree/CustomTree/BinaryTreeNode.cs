

using System;

namespace CustomTree
{
    public class BinaryTreeNode :IComparable
    {
        private object item;
        private BinaryTreeNode parent;
        private BinaryTreeNode leftChild;
        private BinaryTreeNode rightChild;

        public BinaryTreeNode(object item, BinaryTreeNode parent, BinaryTreeNode leftChild, BinaryTreeNode rightChild)
        {
            this.Item = item;
            this.Parent = parent;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public object Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public BinaryTreeNode Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public BinaryTreeNode LeftChild
        {
            get
            {
                return leftChild;
            }

            set
            {
                leftChild = value;
            }
        }

        public BinaryTreeNode RightChild
        {
            get
            {
                return rightChild;
            }

            set
            {
                rightChild = value;
            }
        }


        public int CompareTo(object obj)
        {
            int res = item.ToString().CompareTo(obj.ToString());
            return res;
        }
    }
}
