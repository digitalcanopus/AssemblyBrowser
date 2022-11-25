using Library;
using System;

namespace Tests3
{
    [TestClass]
    public class UnitTest1
    {
        public GetAssembly getAssembly = new GetAssembly("C:\\Users\\Lenovo\\OneDrive\\Рабочий стол\\сэпэпэ\\lab1\\lab1\\lab1\\bin\\Debug\\net5.0\\lab1.dll");
        public InfAssembly assemblyInfo;

        [TestMethod]
        public void TGetAssembly()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            Assert.IsNotNull(assemblyInfo);
        }

        [TestMethod]
        public void TAssemblyName()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            string assmblName = assemblyInfo.AssemblyName;
            Assert.AreEqual("lab1", assmblName);
        }

        [TestMethod]
        public void TNamespaceName()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            string nmspName = assemblyInfo.Namespaces[0].NamespaceName;
            Assert.AreEqual("lab1", nmspName);
        }

        [TestMethod]
        public void TTypesQuantity()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            var nmsp = assemblyInfo.Namespaces.Where(nmsp => nmsp.NamespaceName == "lab1");
            Assert.AreEqual(2, nmsp.First().Types.Count);
        }

        [TestMethod]
        public void TTypesName()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            string type1 = assemblyInfo.Namespaces[0].Types[0].TypeName;
            string type2 = assemblyInfo.Namespaces[0].Types[1].TypeName;
            Assert.AreEqual("Program", type1);
            Assert.AreEqual("TracedMethods", type2);
        }

        [TestMethod]
        public void TTypesType()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            string type1 = assemblyInfo.Namespaces[0].Types[0].Type;
            string type2 = assemblyInfo.Namespaces[0].Types[1].Type;
            Assert.AreEqual("Class", type1);
            Assert.AreEqual("Class", type2);
        }

        [TestMethod]
        public void TFieldsQuantity()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            int fields = assemblyInfo.Namespaces[0].Types[0].Fields.Count;
            Assert.AreEqual(2, fields);
        }

        [TestMethod]
        public void TFieldsName()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            string field1 = assemblyInfo.Namespaces[0].Types[0].Fields[0].FieldName;
            string field2 = assemblyInfo.Namespaces[0].Types[0].Fields[1].FieldName;
            Assert.AreEqual("ThrInfList", field1);
            Assert.AreEqual("tm", field2);
        }

        [TestMethod]
        public void TMethodsQuantity()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            int methods = assemblyInfo.Namespaces[0].Types[1].Methods.Count;
            Assert.AreEqual(11, methods);
        }

        [TestMethod]
        public void TMethodsType()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            string method1 = assemblyInfo.Namespaces[0].Types[1].Methods[0].ReturnType;
            string method2 = assemblyInfo.Namespaces[0].Types[1].Methods[4].ReturnType;
            Assert.AreEqual("Void", method1);
            Assert.AreEqual("MInfo", method2);
        }

        [TestMethod]
        public void TMethodsParameters()
        {
            assemblyInfo = getAssembly.GetAssemblyInfo();
            string parameter1 = assemblyInfo.Namespaces[0].Types[0].Methods[4].Parameters[0].FieldName;
            string parameter2 = assemblyInfo.Namespaces[0].Types[0].Methods[4].Parameters[1].FieldName;
            Assert.AreEqual("fName", parameter1);
            Assert.AreEqual("sym", parameter2);
        }
    }
}