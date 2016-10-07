namespace _04_LongestPathInAtree
{
    using System.Collections.Generic;

    public class TreeNode
    {
        private int value;
        private TreeNode parent;
        private List<TreeNode> children;

        public TreeNode(int value, TreeNode child = null)
        {
            this.Value = value;
            this.Parent = parent;
            this.children = new List<TreeNode>();
            if (child != null)
            {
                this.Children.Add(child);
                foreach (var childBe in Children)
                {
                    childBe.Parent = this;
                }
            }
            
        }

        public int Value
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

        public TreeNode Parent
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

        public List<TreeNode> Children
        {
            get
            {
                return children;
            }

            
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
