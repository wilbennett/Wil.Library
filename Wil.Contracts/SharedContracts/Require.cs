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
    /// <summary>Enables specifying contracts for public methods in source code.</summary>
    public static class Require
    {
        /// <summary>
        /// Throws an exception if the specified condition does not evaluate to <see langword="true" />.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CONTRACTS")]
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
        [Conditional("PUBLIC_CONTRACTS")]
        public static void True<TException>(bool condition)
            where TException : Exception => True<TException>(condition, string.Empty);

        /// <summary>
        /// Throws an <see cref="ArgumentException" /> exception if the specified condition does not evaluate
        /// to <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The exception message.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CONTRACTS")]
        public static void True(bool condition, string message) => True<ArgumentException>(condition, message);

        /// <summary>
        /// Throws an <see cref="ArgumentException" /> exception if the specified condition does not evaluate
        /// to <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional("PUBLIC_CONTRACTS")]
        public static void True(bool condition) => True<ArgumentException>(condition, string.Empty);

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
        public static void NotNull<T>(T parameter, string parameterName)
            => True<ArgumentNullException>(parameter != null, parameterName);
    }
}