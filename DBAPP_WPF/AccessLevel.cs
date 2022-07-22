using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAPP_WPF
{
    public class AccessLevel
    {
        public readonly int Id;
        public List<string> PermittedFunctions { get; private set; }

        public AccessLevel(int id, List<string> permittedFunc)
        {
            Id = id;
            PermittedFunctions = permittedFunc;
        }

        public void FuncSet(List<string> permittedFunc)
        {
            this.PermittedFunctions = permittedFunc;
        }
        public override string ToString()
        {
            string func = "";
            foreach (var str in PermittedFunctions)
            {
                func += str + ";";
            }
            return $"AccessLevel: {Id} {func}";
        }
    }
}
