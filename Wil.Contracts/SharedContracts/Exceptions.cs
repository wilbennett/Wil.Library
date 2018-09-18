using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace

namespace Wil.Contracts
{
    internal static class Exceptions
    {
        [SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void Throw<T>(string message = null)
            where T : Exception
        {
            T exception = string.IsNullOrEmpty(message)
                ? Activator.CreateInstance<T>()
                : (T)Activator.CreateInstance(typeof(T), message);

            throw exception;
        }
    }
}