
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CustomTree
{
    public class JicaTree
    {
        private static BinaryTreeNode rootNode = new BinaryTreeNode(null,null,null,null);
        private int count;

        public BinaryTreeNode RootNode
        {
            get
            {
                return rootNode;
            }

            set
            {
                rootNode = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public void Add(object item)
        {
            if (Count == 0)
            {
                RootNode = new BinaryTreeNode(item, null, null, null);
                Count++;
                return;
            }
            PlaceNode(item);


        }

        private void PlaceNode(object item)
        {
            BinaryTreeNode node = rootNode;

            while (node != null)
            {
                int comp = node.CompareTo(item);
                if (comp < 0)
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = new BinaryTreeNode(item, node, null, null);
                        Count++;
                        break;
                    }
                    node = node.LeftChild;
                }
                else if (comp > 0)
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild =new BinaryTreeNode(item, node, null, null);
                        Count++;
                        break;
                    }
                    node = node.RightChild;
                }
                else
                {
                    node = node.LeftChild;

                }
            }
            
        }
    }
}
