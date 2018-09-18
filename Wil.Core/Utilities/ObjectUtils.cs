using System;
using System.Collections.Generic;
using System.Text;

namespace Wil.Core
{
    public static class ObjectUtils
    {
        public static T Dump<T>(this T instance)
        {
            Console.WriteLine(instance);
            return instance;
        }
    }
}
