using System;
using System.Collections.Generic;

namespace lab3
{
    public class VMNode
    {
        public string Name { get; set; }
        public List<VMNode> Nodes { get; set; } = new List<VMNode>();
    }
}
