using System.Collections.Generic;
using Library;

namespace lab3
{
    public class VMToTree
    {
        public static List<VMNode> Convert(InfAssembly infAssembly)
        {
            List<VMNode> tree = new List<VMNode>();
            foreach (var infNamespace in infAssembly.Namespaces)
            {
                VMNode node = new VMNode();
                node.Name = "Namespace: " + infNamespace.NamespaceName;
                node.Nodes = GetTypeNodes(infNamespace);
                tree.Add(node);
            }
            return tree;
        }

        private static List<VMNode> GetTypeNodes(InfNamespace infNamespace)
        {
            List<VMNode> nodes = new List<VMNode>();
            foreach (var infType in infNamespace.Types)
            {
                VMNode node = new VMNode();
                node.Name = "Type: " + infType.Type + " " + infType.TypeName;
                node.Nodes = GetMethodNodes(infType);
                nodes.Add(node);
            }
            return nodes;
        }

        private static List<VMNode> GetMethodNodes(InfType infClass)
        {
            List<VMNode> nodes = new List<VMNode>();

            foreach (var field in infClass.Fields)
            {
                VMNode node = new VMNode();
                node.Name = "Field: " + field.FieldType + " " + field.FieldName;
                nodes.Add(node);
            }

            foreach (var property in infClass.Properties)
            {
                VMNode node = new VMNode();
                node.Name = "Property: " + property.PropertyType + " " + property.PropertyName;
                nodes.Add(node);
            }

            foreach (var method in infClass.Methods)
            {
                VMNode node = new VMNode();
                node.Name = "Method: " + method.ReturnType + " " + method.MethodName;
                node.Nodes = GetParamsNodes(method);
                nodes.Add(node);
            }
            return nodes;
        }

        private static List<VMNode> GetParamsNodes(InfMethod infMethod)
        {
            List<VMNode> nodes = new List<VMNode>();
            foreach (var param in infMethod.Parameters)
            {
                VMNode node = new VMNode();
                node.Name = "Parameter: " + param.FieldType + " " + param.FieldName;
                nodes.Add(node);
            }

            return nodes;
        }
    }
}
