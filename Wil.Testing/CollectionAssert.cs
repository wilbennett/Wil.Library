using System.Collections;

namespace Wil.Testing
{
    public static class CollectionAssert
    {
        public static void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters)
            => _asserter.AreEqual(expected, actual, comparer, message, parameters);

        public static void AreNotEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters)
            => _asserter.AreNotEqual(expected, actual, comparer, message, parameters);

        public static void AreEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
            => _asserter.AreEquivalent(expected, actual, message, parameters);

        public static void AreNotEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
            => _asserter.AreNotEquivalent(expected, actual, message, parameters);

        public static void IsSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
            => _asserter.IsSubsetOf(subset, superset, message, parameters);

        public static void IsNotSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
            => _asserter.IsNotSubsetOf(subset, superset, message, parameters);


        public static void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message = null)
            => _asserter.AreEqual(expected, actual, comparer, message);

        public static void AreEqual(ICollection expected, ICollection actual, string message = null)
            => _asserter.AreEqual(expected, actual, null, message);

        public static void AreEqual(ICollection expected, ICollection actual, string message, params object[] parameters)
            => _asserter.AreEqual(expected, actual, null, message, parameters);

        public static void AreNotEqual(ICollection expected, ICollection actual, IComparer comparer, string message = null)
            => _asserter.AreNotEqual(expected, actual, comparer, message);

        public static void AreNotEqual(ICollection expected, ICollection actual, string message = null)
            => _asserter.AreNotEqual(expected, actual, null, message);

        public static void AreNotEqual(ICollection expected, ICollection actual, string message, params object[] parameters)
            => _asserter.AreNotEqual(expected, actual, null, message, parameters);

        public static void AreEquivalent(ICollection expected, ICollection actual, string message = null)
            => _asserter.AreEquivalent(expected, actual, message);

        public static void AreNotEquivalent(ICollection expected, ICollection actual, string message = null)
            => _asserter.AreNotEquivalent(expected, actual, message);

        public static void IsSubsetOf(ICollection subset, ICollection superset, string message = null)
            => _asserter.IsSubsetOf(subset, superset, message);

        public static void IsNotSubsetOf(ICollection subset, ICollection superset, string message = null)
            => _asserter.IsNotSubsetOf(subset, superset, message);

        internal static void Initialize(ICollectionAssert asserter) => _asserter = asserter;

        private static ICollectionAssert _asserter;
    }
}
