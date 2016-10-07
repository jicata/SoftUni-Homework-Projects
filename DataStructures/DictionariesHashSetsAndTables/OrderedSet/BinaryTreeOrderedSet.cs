namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTreeOrderedSet<T>:IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTree<T> root;

        private int count;

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }  
        }

        public void Add (T element)
        {
            bool isAdded = false;
            if (this.root == null)
            {
                this.root = new BinaryTree<T>(element);
                isAdded = true;
            }
            else
            {
                isAdded = this.InternalAdd(element);
            }
            if (isAdded)
            {
                this.Count++;
            }
        }

        private bool InternalAdd(T element)
        {
            bool successfullyAdded = true;
            if (!this.Contains(element))
            {
                var currentElement = this.root;
                var newElement = new BinaryTree<T>(element);
                while (true)
                {
                    if (currentElement.Value.CompareTo(element) > 0)
                    {
                        if (currentElement.LeftChild != null)
                        {
                            currentElement = currentElement.LeftChild;

                        }
                        else
                        {
                            currentElement.LeftChild = newElement;
                            newElement.Parent = currentElement;
                            break;
                        }
                    }
                    else if (currentElement.Value.CompareTo(element) < 0)
                    {
                        if (currentElement.RightChild!= null)
                        {
                            currentElement = currentElement.RightChild;

                        }
                        else
                        {
                            currentElement.RightChild= newElement;
                            newElement.Parent = currentElement;
                            break;
                        }
                    }
                }
            }
            else
            {
                successfullyAdded = false;
            }
            return successfullyAdded;

        }

        public bool Contains (T element)
        {
            bool exists = false;
            var currentNode = this.root;
            while (true)
            {
                if (currentNode.Value.Equals(element))
                {
                    exists = true;
                    break;
                }
                if (currentNode.LeftChild == null && currentNode.RightChild == null)
                {
                    exists = false;
                    break;
                }
                if (currentNode.Value.CompareTo(element) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        exists = false;
                        break;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(element) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        exists = false;
                        break;
                    }
                    currentNode = currentNode.RightChild;
                }

            }
            return exists;
        }

        public bool Remove(T element)
        {
            bool removed = true;
            if (this.Contains(element))
            {
                var item = FindElement(element);
                BinaryTree<T> newItem = null;
                if (item.RightChild != null)
                {
                    newItem = item.RightChild;
                    if (newItem.LeftChild != null)
                    {
                        if (item.LeftChild != null)
                        {
                            item.LeftChild.Parent = newItem.LeftChild;
                            newItem.LeftChild.LeftChild = item.LeftChild;
                        }
                    }
                    else
                    {
                        if (item.LeftChild != null)
                        {
                            item.LeftChild.Parent = newItem;
                            newItem.LeftChild = item.LeftChild;
                        }
                    }
                    if (item.Parent != null)
                    {
                        if (item.IsLeftChild)
                        {
                            item.Parent.LeftChild = newItem;
                        }
                        else
                        {
                            item.Parent.RightChild = newItem;
                        }
                        newItem.Parent = item.Parent;
                    }
                    else 
                    {
                        this.root = newItem;
                        newItem.Parent = null;
                    }
                }
                else
                {
                    if (item.IsLeftChild)
                    {
                        item.Parent.LeftChild = item.LeftChild;
                    }
                    else if (item.IsRightChild)
                    {
                        item.Parent.RightChild = item.LeftChild;
                    }
                    if (item.LeftChild != null)
                    {
                        item.LeftChild.Parent = item.Parent;
                    }
                }
                

            }
            else
            {
                removed = false;
            }
            if (removed)
            {
               
                this.Count --;
            }
            return removed;
        }

        private BinaryTree<T> FindElement(T element)
        {
            var currentElement = this.root;
            while (!currentElement.Value.Equals(element))
            {
                if (currentElement.Value.CompareTo(element) > 0)
                {
                    currentElement = currentElement.LeftChild;
                }
                else if (currentElement.Value.CompareTo(element) < 0)
                {
                    currentElement = currentElement.RightChild;
                }
            }
            return currentElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
           List<T> values = new List<T>();
            values = InOrderDFS(this.root, values);
            foreach (var value in values)
            {
                yield return value;
            }
            
        }

        private List<T> InOrderDFS(BinaryTree<T> node, List<T> values)
        {
            if (node.LeftChild != null)
            {
                InOrderDFS(node.LeftChild, values);
            }
            values.Add(node.Value);
            if (node.RightChild != null)
            {
                InOrderDFS(node.RightChild, values);
            }
            return values;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
