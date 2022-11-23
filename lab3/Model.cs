using System;
using Library;

namespace lab3
{
    public static class Model
    {
        public static InfAssembly GetTree(string filename)
        {
            GetAssembly getAssembly = new GetAssembly(filename);
            return getAssembly.GetAssemblyInfo();
        }
    }
}
