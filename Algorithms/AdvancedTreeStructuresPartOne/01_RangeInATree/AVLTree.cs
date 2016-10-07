namespace _01_RangeInATree
{
    using System;
    using System.Collections.Generic;

    public class AvlTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            bool inserted = true;
            if (this.root == null)
            {
                var rootChe = new Node<T>(item);
                this.root = rootChe;
            }
            else
            {
                inserted = this.InsertInternal(this.root, item);
            }
            if (inserted)
            {
                this.Count++;
            }
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            bool shouldRetrace = false;
            while (true)
            {
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }
                    currentNode = currentNode.RightChild;

                }
                else if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return false;
                }

            }
            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }
            return true;
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor++;
                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }
                        this.RotateRight(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = 1;
                    }
                }
                if (node.IsRightChild)
                {
                    if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor--;
                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }
                        this.RotateLeft(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = -1;
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
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                child.Parent = null;
            }
            node.LeftChild = child.RightChild;
            child.RightChild = node;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 + Math.Min(node.BalanceFactor, 0);
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                child.Parent = null;
            }
            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        public bool Contains(T item)
        {
            bool contained = false;
            var node = this.root;
            Queue<Node<T>> nodeQueue = new Queue<Node<T>>();
            nodeQueue.Enqueue(node);
            while (nodeQueue.Count > 0)
            {
                node = nodeQueue.Dequeue();
                if (node.LeftChild != null)
                {
                    if (node.LeftChild.Value.CompareTo(item) == 0)
                    {
                        contained = true;
                        break;
                    }
                    else
                    {
                        nodeQueue.Enqueue(node.LeftChild);
                    }
                }
                if (node.RightChild != null)
                {
                    if (node.RightChild.Value.CompareTo(item) == 0)
                    {
                        contained = true;
                        break;
                    }
                    else
                    {
                        nodeQueue.Enqueue(node.RightChild);
                    }
                }

            }
            return contained;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }
            this.InOrderDfs(this.root, 1, action);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                this.InOrderDfs(node.LeftChild, depth + 1, action);
            }
            action(depth, node.Value);
            if (node.RightChild != null)
            {
                this.InOrderDfs(node.RightChild, depth + 1, action);
            }
        }

        public IEnumerable<T> Range(T from, T to)
        {
            List<T> elements = new List<T>();
            elements = InternalRange(this.root, from, to, elements);
            return elements;
        }

        private List<T> InternalRange(Node<T> node, T from, T to, List<T> elements)
        {
            bool isLesserThanTo = node.Value.CompareTo(to) <= 0;
            bool isGreaterThanFrom = node.Value.CompareTo(from) >= 0;
            if (isGreaterThanFrom && node.LeftChild != null)
            {
                InternalRange(node.LeftChild, from, to, elements);
            }
            if (isGreaterThanFrom && isLesserThanTo)
            {
                elements.Add(node.Value);
            }
            
            if (isLesserThanTo &&node.RightChild != null)
            {
                InternalRange(node.RightChild, from, to, elements);
            }
            return elements;
        }
    }
}
