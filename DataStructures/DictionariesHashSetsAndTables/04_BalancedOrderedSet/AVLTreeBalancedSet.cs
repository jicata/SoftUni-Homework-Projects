namespace _04_BalancedOrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // missing a Remove(T item) method
    public class AVLTreeBalancedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            bool added = false;
            if (this.root == null)
            {
                var newNode = new Node<T>(item);
                this.root = newNode;
                added = true;
            }
            else
            {
                added = InternalAdd(this.root, item);
            }

            if (added)
            {
                this.Count++;
            }
        }

        private bool InternalAdd(Node<T> node, T item)
        {
            bool added = false;
            bool shouldRetrace = false;
            var currentNode = node;
            if (!this.Contains(item))
            {
                while (true)
                {
                    if (currentNode.Value.CompareTo(item) > 0)
                    {
                        if (currentNode.LeftChild != null)
                        {
                            currentNode = currentNode.LeftChild;
                        }
                        else
                        {
                            currentNode.LeftChild = new Node<T>(item);
                            currentNode.BalanceFactor++;
                            shouldRetrace = currentNode.BalanceFactor != 0;
                            added = true;
                            break;
                        }
                    }
                    else if (currentNode.Value.CompareTo(item) < 0)
                    {
                        if (currentNode.RigthChild != null)
                        {
                            currentNode = currentNode.RigthChild;
                        }
                        else
                        {
                            currentNode.RigthChild = new Node<T>(item);
                            currentNode.BalanceFactor--;
                            shouldRetrace = currentNode.BalanceFactor != 0;
                            added = true;
                            break;
                        }
                    }
                }

            }
            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }
            return added;
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.BalanceFactor++;
                    if (parent.BalanceFactor >= 2)
                    {
                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }
                        this.RotateRight(parent);
                        break;
                    }
                    if (parent.BalanceFactor == 0)
                    {
                        break;
                    }
                    
                }
                else if (node.IsRightChild)
                {
                    parent.BalanceFactor--;
                    if (parent.BalanceFactor <= -2)
                    {
                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }
                        this.RotateLeft(parent);
                        break;
                    }
                    if (parent.BalanceFactor == 0)
                    {
                        break;
                    }
                }
                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RigthChild = child;
                }
            }
            else
            {
                this.root = child;
                child.Parent = null;
            }
            node.LeftChild = child.RigthChild;
            child.RigthChild = node;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Min(node.BalanceFactor, 0);
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RigthChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RigthChild = child;
                }

            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }
            node.RigthChild = child.LeftChild;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        public bool Contains(T item)
        {
            bool exists = false;
            var currentNode = this.root;
            while (true)
            {
                if (currentNode.Value.Equals(item))
                {
                    exists = true;
                    break;
                }

                if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        break;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RigthChild == null)
                    {
                        break;
                    }
                    currentNode = currentNode.RigthChild;
                }
            }
            return exists;
        }


        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;;
            }
            this.InOrderDfs(this.root, 1, action);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                InOrderDfs(node.LeftChild, depth+1, action);
            }
            action(depth, node.Value);
            if (node.RigthChild != null)
            {
                InOrderDfs(node.RigthChild, depth+1, action);
            }
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

        private List<T> InOrderDFS(Node<T> node, List<T> values)
        {
            if (node.LeftChild != null)
            {
                InOrderDFS(node.LeftChild, values);
            }
            values.Add(node.Value);
            if (node.RigthChild != null)
            {
                InOrderDFS(node.RigthChild, values);
            }
            return values;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
