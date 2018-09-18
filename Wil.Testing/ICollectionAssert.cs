using System.Collections;

namespace Wil.Testing
{
    public interface ICollectionAssert
    {
        void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters);
        void AreNotEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters);
        void AreEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters);
        void AreNotEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters);
        void IsSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters);
        void IsNotSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters);
    }
}
