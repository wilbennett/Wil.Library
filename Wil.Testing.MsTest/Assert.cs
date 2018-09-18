using msassert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Wil.Testing.MsTest.Assertions
{
    public class Assert : IAssert
    {
        void IAssert.IsTrue(bool condition, string message, params object[] parameters)
        {
            if (message == null)
                msassert.IsTrue(condition);
            else
                msassert.IsTrue(condition, message, parameters);
        }

        void IAssert.IsFalse(bool condition, string message, params object[] parameters)
        {
            if (message == null)
                msassert.IsFalse(condition);
            else
                msassert.IsFalse(condition, message, parameters);
        }

        void IAssert.IsNull(object value, string message, params object[] parameters)
        {
            if (message == null)
                msassert.IsNull(value);
            else
                msassert.IsNull(value, message, parameters);
        }

        void IAssert.IsNotNull(object value, string message, params object[] parameters)
        {
            if (message == null)
                msassert.IsNotNull(value);
            else
                msassert.IsNotNull(value, message, parameters);
        }

        void IAssert.Fail(string message, params object[] parameters)
        {
            if (message == null)
                msassert.Fail();
            else
                msassert.Fail(message, parameters);
        }

        void IAssert.AreEqual(object expected, object actual, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreEqual(expected, actual);
            else
                msassert.AreEqual(expected, actual, message, parameters);
        }

        void IAssert.AreEqual(double expected, double actual, double delta, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreEqual(expected, actual, delta);
            else
                msassert.AreEqual(expected, actual, delta, message, parameters);
        }

        void IAssert.AreEqual(float expected, float actual, float delta, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreEqual(expected, actual, delta);
            else
                msassert.AreEqual(expected, actual, delta, message, parameters);
        }

        void IAssert.AreNotEqual(object expected, object actual, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreNotEqual(expected, actual);
            else
                msassert.AreNotEqual(expected, actual, message, parameters);
        }

        void IAssert.AreNotEqual(double expected, double actual, double delta, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreNotEqual(expected, actual, delta);
            else
                msassert.AreNotEqual(expected, actual, delta, message, parameters);
        }

        void IAssert.AreNotEqual(float expected, float actual, float delta, string message, params object[] parameters)
        {
            if (message == null)
                msassert.AreNotEqual(expected, actual, delta);
            else
                msassert.AreNotEqual(expected, actual, delta, message, parameters);
        }
    }
}
