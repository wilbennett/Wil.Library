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

// ReSharper disable once RedundantUsingDirective
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace

namespace Wil.Contracts
{
    /// <summary>Enables checking assertions of non public methods in source code.</summary>
    public static class ExpectPrivate
    {
        /// <summary>Asserts the specified condition evaluates to <see langword="true"/> in debug builds.</summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void Assert(bool condition, string message) => Debug.Assert(condition, message);

        /// <summary>Asserts the specified condition evaluates to <see langword="true"/> in debug builds.</summary>
        /// <param name="condition">The condition to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void Assert(bool condition) => Debug.Assert(condition);

        /// <summary>Asserts the specified value does not evaluate to <see langword="null"/> in debug builds.</summary>
        /// <typeparam name="T">Type of the value being evaluated.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void AssertNotNull<T>(T value, string message) => Debug.Assert(value != null, message);

        /// <summary>Asserts the specified value does not evaluate to <see langword="null"/> in debug builds.</summary>
        /// <typeparam name="T">Type of the value being evaluated.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void AssertNotNull<T>(T value) => Debug.Assert(value != null);

        /// <summary>
        /// Throws an exception if the specified condition does not evaluate to <see langword="true" />.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void True<TException>(bool condition, string message)
            where TException : Exception
        {
            if (!condition)
                Exceptions.Throw<TException>(message);
        }

        /// <summary>
        /// Throws an exception if the specified condition does not evaluate to <see langword="true" />.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void True<TException>(bool condition)
            where TException : Exception => True<TException>(condition, string.Empty);

        /// <summary>
        /// Throws an exception if the specified condition does not evaluate to <see langword="true" />.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void True(bool condition, string message) => True<InvalidOperationException>(condition, message);

        /// <summary>
        /// Throws an exception if the specified condition does not evaluate to <see langword="true" />.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void True(bool condition) => True<InvalidOperationException>(condition, string.Empty);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void NotNull<TException>(object value, string message)
            where TException : Exception => True<TException>(value != null, message);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void NotNull<TException>(object value)
            where TException : Exception => True<TException>(value != null, ExceptionFormat.UnexpectedNullValue);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void NotNull(object value, string message) => True<Exception>(value != null, message);

        /// <summary>Throws an exception if the specified value evaluates to <see langword="null"/>.</summary>
        /// <param name="value">The value to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PRIVATE_CHECKS")]
        public static void NotNull(object value)
            => True<Exception>(value != null, ExceptionFormat.UnexpectedNullValue);
    }
}