namespace Library
{
    public class GetAssembly
    {
        private readonly System.Reflection.Assembly? _assembly;


        public GetAssembly(string filename)
        {
            try
            {
                _assembly = System.Reflection.Assembly.LoadFrom(filename);
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
            List<InfNamespace> namespaceInfos = new List<InfNamespace>();

            foreach (string namespaceName in namespaces)
            {
                InfNamespace namespaceInfo = new InfNamespace();
                namespaceInfo.NamespaceName = namespaceName;
                namespaceInfo.Types = GetTypeInfo(namespaceName);
                namespaceInfos.Add(namespaceInfo);
            }

            return namespaceInfos;
        }

        private List<InfType> GetTypeInfo(string namespaceName)
        {
            IEnumerable<Type> types = _assembly.GetTypes().Where(type => type.Namespace == namespaceName);
            List<InfType> typeInfos = new List<InfType>();

            foreach (Type type in types)
            {
                InfType typeInfo = new InfType();
                typeInfo.TypeName = type.Name;
                if (type.IsClass)
                    typeInfo.Type = "Class";
                else if (type.IsInterface)
                    typeInfo.Type = "Interface";
                else if (type.IsEnum)
                    typeInfo.Type = "Enam";
                else
                    typeInfo.Type = "Type";
                typeInfo.Fields = GetFieldInfo(type);
                typeInfo.Properties = GetPropertyInfo(type);
                typeInfo.Methods = GetMethodInfo(type);
                typeInfos.Add(typeInfo);
            }

            return typeInfos;
        }

        private List<InfField> GetFieldInfo(Type classType)
        {
            var fields = classType.GetFields();
            List<InfField> fieldInfos = new List<InfField>();

            foreach (var field in fields)
            {
                InfField fieldInfo = new InfField();
                fieldInfo.FieldName = field.Name;
                fieldInfo.FieldType = field.FieldType.Name;
                fieldInfos.Add(fieldInfo);
            }

            return fieldInfos;
        }

        private List<InfProperty> GetPropertyInfo(Type classType)
        {
            var properties = classType.GetProperties();
            List<InfProperty> propertyInfos = new List<InfProperty>();

            foreach (var property in properties)
            {
                InfProperty propertyInfo = new InfProperty();
                propertyInfo.PropertyName = property.Name;
                propertyInfo.PropertyType = property.PropertyType.Name;
                propertyInfos.Add(propertyInfo);
            }

            return propertyInfos;
        }

        private List<InfMethod> GetMethodInfo(Type classType)
        {
            var methods = classType.GetMethods();
            List<InfMethod> methodInfos = new List<InfMethod>();

            foreach (var method in methods)
            {
                InfMethod methodInfo = new InfMethod();
                methodInfo.MethodName = method.Name;
                methodInfo.ReturnType = method.ReturnType.Name;
                methodInfo.Parameters = GetParametersInfo(method);
                methodInfos.Add(methodInfo);
            }

            return methodInfos;
        }

        private List<InfField> GetParametersInfo(System.Reflection.MethodInfo method)
        {
            List<InfField> parameterInfos = new List<InfField>();
            var parametrs = method.GetParameters();

            foreach (var param in parametrs)
            {
                InfField parametrInfo = new InfField();
                parametrInfo.FieldName = param.Name;
                parametrInfo.FieldType = param.ParameterType.Name;
                parameterInfos.Add(parametrInfo);
            }

            return parameterInfos;
        }
    }
}
