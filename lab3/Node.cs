using System;
using System.Collections.Generic;

namespace lab3
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Nodes { get; set; } = new List<Node>();
    }
}
