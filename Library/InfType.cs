namespace Library
{
    public class InfType
    {
        public string TypeName { get; set; }
        public string Type { get; set; }
        public List<InfField> Fields { get; set; }
        public List<InfProperty> Properties { get; set; }
        public List<InfMethod> Methods { get; set; }

        public InfType(string typeName, string type, List<InfField> fields, List<InfProperty> properties, List<InfMethod> methods)
        {
            TypeName = typeName;
            Type = type;
            Fields = fields;
            Properties = properties;
            Methods = methods;
        }

        public InfType()
        {
        }
    }
}
