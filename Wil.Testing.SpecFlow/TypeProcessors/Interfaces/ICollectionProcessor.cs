using System;
using System.Collections;
using System.Collections.Generic;

namespace Wil.Testing.SpecFlow
{
    public interface ICollectionProcessor : ITypeProcessor
    {
        Type ElementType { get; }
        string ElementTypeName { get; }
        ICollection CollectionValue { get; }

        void SetValue(List<string> texts);
    }
}
