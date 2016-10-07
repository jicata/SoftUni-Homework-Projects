namespace _02_RoundDance
{
    using System.Collections.Generic;

    public class GraphNode
    {
        public int value;
        public List<GraphNode> friends;

        public GraphNode(int value)
        {
            this.value = value;
            this.friends = new List<GraphNode>();
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
