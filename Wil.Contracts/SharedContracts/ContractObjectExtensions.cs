/*
 -------------------------------------------------------------------------------------------------
 | Symbol            | Meaning                                                                   |
 -------------------------------------------------------------------------------------------------
 | PUBLIC_CONTRACTS  | Performs contract checks in public methods from the compiled code         |
 | PRIVATE_CONTRACTS | Performs contract checks in non-public methods from the compiled code     |
 | PUBLIC_CHECKS     | Performs expectation checks in public methods from the compiled code      |
 | PRIVATE_CHECKS    | Performs expectation checks in non-public methods from the compiled code  |
 -------------------------------------------------------------------------------------------------
*/

//*
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace Wil.Contracts.Extensions
{
    /// <summary>Utilities for using contracts on object instances.</summary>
    public static class ContractObjectExtensions
    {
        #region Public Contracts
        /// <summary>
        /// Throws an <see cref="ArgumentException" /> exception if the specified parameter value evaluates
        /// to <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter value to evaluate.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CONTRACTS")]
        public static void RequireNotNull<T>(this T parameter, string parameterName)
            => Require.NotNull(parameter, parameterName);
        #endregion

        #region Private Contracts
        /// <summary>
        /// Throws an <see cref="ArgumentException" /> exception if the specified parameter value evaluates
        /// to <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter value to evaluate.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CONTRACTS")]
        public static void PrivateRequireNotNull<T>(this T parameter, string parameterName)
            => RequirePrivate.NotNull(parameter, parameterName);
        #endregion

        #region Public Checks
        /// <summary>Ensures the specified value is not <see langword="null" />.</summary>
        /// <typeparam name="T">Type of the value to check.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The message to include in the exception.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CHECKS")]
        public static void AssertNotNull<T>(this T value, string message) => Expect.AssertNotNull(value, message);

        /// <summary>Ensures the specified value is not <see langword="null"/>.</summary>
        /// <typeparam name="T">Type of the value to check.</typeparam>
        /// <param name="value">The value to check.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CHECKS")]
        public static void AssertNotNull<T>(this T value) => Expect.AssertNotNull(value);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CHECKS")]
        public static void ExpectNotNull<TException>(this object value, string message)
            where TException : Exception => Expect.NotNull<TException>(value, message);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CHECKS")]
        public static void ExpectNotNull<TException>(this object value)
            where TException : Exception => Expect.NotNull<TException>(value);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CHECKS")]
        public static void ExpectNotNull(this object value, string message) => Expect.NotNull(value, message);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <param name="value">The value to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CHECKS")]
        public static void ExpectNotNull(this object value) => Expect.NotNull(value);
        #endregion

        #region Private Checks
        /// <summary>Ensures the specified value is not <see langword="null" />.</summary>
        /// <typeparam name="T">Type of the value to check.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The message to include in the exception.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void PrivateAssertNotNull<T>(this T value, string message) => ExpectPrivate.AssertNotNull(value, message);

        /// <summary>Ensures the specified value is not <see langword="null"/>.</summary>
        /// <typeparam name="T">Type of the value to check.</typeparam>
        /// <param name="value">The value to check.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void PrivateAssertNotNull<T>(this T value) => ExpectPrivate.AssertNotNull(value);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void PrivateExpectNotNull<TException>(this object value, string message)
            where TException : Exception => ExpectPrivate.NotNull<TException>(value, message);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void PrivateExpectNotNull<TException>(this object value)
            where TException : Exception => ExpectPrivate.NotNull<TException>(value);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void PrivateExpectNotNull(this object value, string message) => ExpectPrivate.NotNull(value, message);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <param name="value">The value to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void PrivateExpectNotNull(this object value) => ExpectPrivate.NotNull(value);
        #endregion
    }
}
//*/