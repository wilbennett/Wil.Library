using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Wil.Core
{
    public static class TypeUtils
    {
        /*
        public static string GetGenericInnerTypeName(string genericTypeName)
        {
            Type type = Type.GetType(genericTypeName);

            if (!type.IsConstructedGenericType) return type.FullName;

            Type innerType = type.GenericTypeArguments[0];
            return innerType.FullName;
        }

        public static string GetRootTypeName(string typeName) => Type.GetType(typeName).Name;
        //*/

        public static string GetGenericInnerRootTypeName(string genericTypeName)
        {
            Type type = Type.GetType(genericTypeName);

            if (!type.IsConstructedGenericType) return type.Name;

            Type innerType = type.GenericTypeArguments[0];
            return innerType.Name;
        }

        public static bool TryConvert(object value, Type toType, out object result)
        {
            try
            {
                result = Convert.ChangeType(value, toType);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public static Type CreateGenericType(Type openType, params Type[] typeArguments)
            => openType.MakeGenericType(typeArguments);

        public static IList CreateList(Type elementType)
            => (IList)Activator.CreateInstance(CreateGenericType(typeof(List<>), elementType));

    }
}