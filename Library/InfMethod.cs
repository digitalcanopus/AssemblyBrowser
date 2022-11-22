namespace Library
{
    internal class InfMethod
    {
        public string MethodName { get; set; }
        public string ReturnType { get; set; }
        public List<InfField> Parameters { get; set; }

        public InfMethod(string methodName, string returnType, List<InfField> parameters)
        {
            MethodName = methodName;
            ReturnType = returnType;
            Parameters = parameters;
        }

        public InfMethod()
        {
        }
    }
}
