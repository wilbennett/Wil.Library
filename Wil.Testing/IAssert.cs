namespace Wil.Testing
{
    public interface IAssert
    {
        void IsTrue(bool condition, string message, params object[] parameters);
        void IsFalse(bool condition, string message, params object[] parameters);
        void IsNull(object value, string message, params object[] parameters);
        void IsNotNull(object value, string message, params object[] parameters);
        void Fail(string message, params object[] parameters);
        void AreEqual(object expected, object actual, string message, params object[] parameters);
        void AreEqual(double expected, double actual, double delta, string message, params object[] parameters);
        void AreEqual(float expected, float actual, float delta, string message, params object[] parameters);
        void AreNotEqual(object expected, object actual, string message, params object[] parameters);
        void AreNotEqual(double expected, double actual, double delta, string message, params object[] parameters);
        void AreNotEqual(float expected, float actual, float delta, string message, params object[] parameters);
    }
}
