namespace Library
{
    public class InfAssembly
    {
        public string AssemblyName { get; set; }
        public List<InfNamespace> Namespaces { get; set; }

        public InfAssembly(string assemblyName, List<InfNamespace> namespaces)
        {
            AssemblyName = assemblyName;
            Namespaces = namespaces;
        }

        public InfAssembly()
        {
        }
    }
}