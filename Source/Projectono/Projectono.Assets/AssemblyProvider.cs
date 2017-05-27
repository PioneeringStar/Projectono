using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projectono.Assets
{
    public static class AssemblyProvider
    {
        private static readonly Assembly Reference = typeof(AssemblyProvider).GetTypeInfo().Assembly;
        public static Assembly Get() { return Reference; }
    }
}
