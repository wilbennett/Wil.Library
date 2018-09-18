namespace Wil.Testing
{
    public static class Assert
    {
        public static void IsTrue(bool condition, string message, params object[] parameters)
            => _asserter.IsTrue(condition, message, parameters);

        public static void IsFalse(bool condition, string message, params object[] parameters)
            => _asserter.IsFalse(condition, message, parameters);

        public static void IsNull(object value, string message, params object[] parameters)
            => _asserter.IsNull(value, message, parameters);

        public static void IsNotNull(object value, string message, params object[] parameters)
            => _asserter.IsNotNull(value, message, parameters);

        public static void Fail(string message, params object[] parameters)
            => _asserter.Fail(message, parameters);

        public static void AreEqual(object expected, object actual, string message, params object[] parameters)
            => _asserter.AreEqual(expected, actual, message, parameters);

        public static void AreEqual(double expected, double actual, double delta, string message, params object[] parameters)
            => _asserter.AreEqual(expected, actual, delta, message, parameters);

        public static void AreEqual(float expected, float actual, float delta, string message, params object[] parameters)
            => _asserter.AreEqual(expected, actual, delta, message, parameters);

        public static void AreNotEqual(object expected, object actual, string message, params object[] parameters)
            => _asserter.AreNotEqual(expected, actual, message, parameters);

        public static void AreNotEqual(double expected, double actual, double delta, string message, params object[] parameters)
            => _asserter.AreNotEqual(expected, actual, delta, message, parameters);

        public static void AreNotEqual(float expected, float actual, float delta, string message, params object[] parameters)
            => _asserter.AreNotEqual(expected, actual, delta, message, parameters);


        public static void IsTrue(bool condition, string message = null)
            => _asserter.IsTrue(condition, message);

        public static void IsFalse(bool condition, string message = null)
            => _asserter.IsFalse(condition, message);

        public static void IsNull(object value, string message = null)
            => _asserter.IsNull(value, message);

        public static void IsNotNull(object value, string message = null)
            => _asserter.IsNotNull(value, message);

        public static void Fail(string message = null) => _asserter.Fail(message);

        public static void AreEqual(object expected, object actual, string message = null)
            => _asserter.AreEqual(expected, actual, message);

        public static void AreEqual(double expected, double actual, double delta, string message = null)
            => _asserter.AreEqual(expected, actual, delta, message);

        public static void AreEqual(float expected, float actual, float delta, string message = null)
            => _asserter.AreEqual(expected, actual, delta, message);

        public static void AreNotEqual(object expected, object actual, string message = null)
            => _asserter.AreNotEqual(expected, actual, message);

        public static void AreNotEqual(double expected, double actual, double delta, string message = null)
            => _asserter.AreNotEqual(expected, actual, delta, message);

        public static void AreNotEqual(float expected, float actual, float delta, string message = null)
            => _asserter.AreNotEqual(expected, actual, delta, message);

        internal static void Initialize(IAssert asserter) => _asserter = asserter;

        private static IAssert _asserter;
    }
}
