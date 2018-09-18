using System;
using System.Collections;

namespace Wil.Testing.SpecFlow
{
    public struct ComparerMapping
    {
        public ComparerMapping(string typeName, Type type, IComparer comparer)
        {
            TypeName = typeName;
            Type = type;
            Comparer = comparer;
        }

        public string TypeName { get; }
        public Type Type { get; }
        public IComparer Comparer { get; }
    }
}