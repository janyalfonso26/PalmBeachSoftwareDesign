using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DAL.Infrastructure.EF
{
    public static class GetTypes
    {
        public static IEnumerable<Type> _Gettypes(string namespaceName)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == namespaceName).ToList();
        }

    }
}
