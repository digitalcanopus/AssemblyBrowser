using System;
using System.Collections.Generic;
using System.Linq;
namespace Library
{
    public class InfNamespace
    {
        public string NamespaceName { get; set; }
        public List<InfType> Types { get; set; }

        public InfNamespace(string namespaceName, List<InfType> types)
        {
            NamespaceName = namespaceName;
            Types = types;
        }

        public InfNamespace()
        {
        }
    }
}
