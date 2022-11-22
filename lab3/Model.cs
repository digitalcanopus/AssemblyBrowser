using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
