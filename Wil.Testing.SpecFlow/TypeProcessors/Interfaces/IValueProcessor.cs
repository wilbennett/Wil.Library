using System.Collections.Generic;

namespace Wil.Testing.SpecFlow
{
    public interface IValueProcessor : ITypeProcessor
    {
        IList<string> DataTypeNames { get; }

        new IValueProcessor Clone();
    }
}
