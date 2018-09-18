using System.Collections.ObjectModel;

namespace Wil.Core
{
    public class KeyedStringCollection : KeyedCollection<string, string>
    {
        protected override string GetKeyForItem(string item) => item;
    }
}