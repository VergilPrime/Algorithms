using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class DoubleNode : Node
    {
        public Node Prev{ get; set; }
    }

    class TreeNode
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
