using System.Collections;
using msassert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace Wil.Testing.MsTest.Assertions
{
    public class CollectionAssert : ICollectionAssert
    {
        void ICollectionAssert.AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters)
        {
            if (comparer == null)
            {
                if (message == null)
                    msassert.AreEqual(expected, actual);
                else
                    msassert.AreEqual(expected, actual, message, parameters);
            }
            else
            {
                if (message == null)
                    msassert.AreEqual(expected, actual, comparer);
                else
                    msassert.AreEqual(expected, actual, comparer, message, parameters);
            }
        }

        void ICollectionAssert.AreNotEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters)
        {
            if (comparer == null)
            {
                if (message == null)
                    msassert.AreNotEqual(expected, actual);
                else
                    msassert.AreNotEqual(expected, actual, message, parameters);
            }
            else
            {
                if (message == null)
                    msassert.AreNotEqual(expected, actual, comparer);
                else
                    msassert.AreNotEqual(expected, actual, comparer, message, parameters);
            }
        }

        void ICollectionAssert.AreEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreEquivalent(expected, actual);
            else
                msassert.AreEquivalent(expected, actual, message, parameters);
        }

        void ICollectionAssert.AreNotEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreNotEquivalent(expected, actual);
            else
                msassert.AreNotEquivalent(expected, actual, message, parameters);
        }

        void ICollectionAssert.IsSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
        {
            if (message == null)
                msassert.IsSubsetOf(subset, superset);
            else
                msassert.IsSubsetOf(subset, superset, message, parameters);
        }

        void ICollectionAssert.IsNotSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
        {
            if (message == null)
                msassert.IsNotSubsetOf(subset, superset);
            else
                msassert.IsNotSubsetOf(subset, superset, message, parameters);
        }
    }
}
