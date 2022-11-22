using System.Reflection;

namespace Library
{
    public class GetAssembly
    {
        private readonly Assembly? _assembly;


        public GetAssembly(string filename)
        {
            try
            {
                _assembly = Assembly.LoadFrom(filename);
            }
            catch
            {
                _assembly = null;
            }

        }

        public InfAssembly? GetAssemblyInfo()
        {
            if (_assembly != null)
            {
                return new InfAssembly(_assembly.GetName().Name, GetNamespaceInfo());
            }
            else
            {
                return null;
            }
        }

        private List<InfNamespace> GetNamespaceInfo()
        {
            IEnumerable<string?> namespaces = _assembly.GetTypes().Select(type => type.Namespace).Distinct();
            List<InfNamespace> infNamespaces = new List<InfNamespace>();

            foreach (string namespaceName in namespaces)
            {
                InfNamespace infNamespace = new InfNamespace();
                infNamespace.NamespaceName = namespaceName;
                infNamespace.Types = GetTypeInfo(namespaceName);
                infNamespaces.Add(infNamespace);
            }

            return infNamespaces;
        }

        private List<InfType> GetTypeInfo(string namespaceName)
        {
            IEnumerable<Type> types = _assembly.GetTypes().Where(type => type.Namespace == namespaceName);
            List<InfType> infTypes = new List<InfType>();

            foreach (Type type in types)
            {
                InfType infType = new InfType();
                infType.TypeName = type.Name;
                if (type.IsClass)
                    infType.Type = "Class";
                else if (type.IsInterface)
                    infType.Type = "Interface";
                else if (type.IsEnum)
                    infType.Type = "Enum";
                else
                    infType.Type = "Type";
                infType.Fields = GetFieldInfo(type);
                infType.Properties = GetPropertyInfo(type);
                infType.Methods = GetMethodInfo(type);
                infTypes.Add(infType);
            }

            return infTypes;
        }

        private List<InfField> GetFieldInfo(Type classType)
        {
            var fields = classType.GetFields();
            List<InfField> infFields = new List<InfField>();

            foreach (var field in fields)
            {
                InfField infField = new InfField();
                infField.FieldName = field.Name;
                infField.FieldType = field.FieldType.Name;
                infFields.Add(infField);
            }

            return infFields;
        }

        private List<InfProperty> GetPropertyInfo(Type classType)
        {
            var properties = classType.GetProperties();
            List<InfProperty> infProperties = new List<InfProperty>();

            foreach (var property in properties)
            {
                InfProperty infProperty = new InfProperty();
                infProperty.PropertyName = property.Name;
                infProperty.PropertyType = property.PropertyType.Name;
                infProperties.Add(infProperty);
            }

            return infProperties;
        }

        private List<InfMethod> GetMethodInfo(Type classType)
        {
            var methods = classType.GetMethods();
            List<InfMethod> infMethods = new List<InfMethod>();

            foreach (var method in methods)
            {
                InfMethod infMethod = new InfMethod();
                infMethod.MethodName = method.Name;
                infMethod.ReturnType = method.ReturnType.Name;
                infMethod.Parameters = GetParametersInfo(method);
                infMethods.Add(infMethod);
            }

            return infMethods;
        }

        private List<InfField> GetParametersInfo(System.Reflection.MethodInfo method)
        {
            List<InfField> infParameters = new List<InfField>();
            var parameters = method.GetParameters();

            foreach (var parameter in parameters)
            {
                InfField infParameter = new InfField();
                infParameter.FieldName = parameter.Name;
                infParameter.FieldType = parameter.ParameterType.Name;
                infParameters.Add(infParameter);
            }

            return infParameters;
        }
    }
}
