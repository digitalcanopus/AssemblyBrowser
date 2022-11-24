using Library;

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
    }
}