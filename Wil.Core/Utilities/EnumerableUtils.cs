using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Wil.Core
{
    public static class EnumerableUtils
    {
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
                action(item);

            return source;
        }

        public static IEnumerable<object> ToObjects<T>(this IEnumerable<T> values) => values.Cast<object>();
        public static List<object> ToObjectsList<T>(this IEnumerable<T> values) => ToObjects(values).ToList();

        public static ICollection ToCollection(object source)
        {
            return source is ICollection
                ? (ICollection)source
                : (source as IEnumerable)?.Cast<object>().ToList();
        }
    }
}