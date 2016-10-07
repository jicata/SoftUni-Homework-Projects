using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    class TreeMain
    {
        static void Main(string[] args)
        {
            var jicatTree = new JicaTree();
            jicatTree.Add(5);
            jicatTree.Add(4);
            jicatTree.Add(18);
            jicatTree.Add(1);
            Console.WriteLine(jicatTree.RootNode.Item);
            Console.WriteLine(jicatTree.RootNode.LeftChild.Item);

            
        }

       
    }
}
