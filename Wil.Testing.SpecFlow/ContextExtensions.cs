using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public static partial class ContextExtensions
    {
        /// <summary>Returns the given key or the name of the specified type if the key is <c>null</c>.</summary>
        /// <typeparam name="T">Type of the data associated with the key.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key to process.</param>
        /// <returns>The given key or the name of the specified type if the key is <c>null</c>.</returns>
        public static string NormalizeKey<T>(this SpecFlowContext context, string key)
        {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).FullName;

            return key;
        }

        /// <summary>Gets a value from the context using a specified key.  Asserts if the key is not found.</summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <returns>The value associated with the specified key.</returns>
        public static T GetEx<T>(this SpecFlowContext context, string key)
        {
            if (!context.TryGetValue(key, out T value)) throw new Exception($"'{key}' was not found.");

            return value;
        }

        /// <summary>Gets a value from the context using a default key.  Asserts if the value is not found.</summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="context">The context.</param>
        /// <returns>The value associated with the specified key.</returns>
        public static T GetEx<T>(this SpecFlowContext context) => GetEx<T>(context, typeof(T).FullName);

        /// <summary>
        /// Gets a value from the context or parent context(s) using a specified key.  Asserts if the key is not
        /// found.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <returns>The value associated with the default key.</returns>
        public static T GetInherited<T>(this SpecFlowContext context, string key)
        {

            if (context.TryGetValue(key, out T value)) return value;

            //if (context is ScenarioStepContext)
            //{
            //    if (context.GetScenarioContext()?.TryGetValue(key, out value) ?? false) return value;
            //    if (context.GetFeatureContext()?.TryGetValue(key, out value) ?? false) return value;
            //}

            if (context is ScenarioContext)
            {
                if (context.GetFeatureContext()?.TryGetValue(key, out value) ?? false) return value;
            }

            throw new Exception($"'{key}' was not found.");
        }

        ///// <summary>
        ///// Gets a value from the context or parent context(s) using a default key.  Asserts if the key is not found
        ///// </summary>
        ///// <typeparam name="T">The type of the value to return.</typeparam>
        ///// <param name="context">The context.</param>
        ///// <returns>The value associated with the default key.</returns>
        //public static T GetInherited<T>(this SpecFlowContext context) => GetInherited<T>(context, typeof(T).FullName);

        /// <summary>
        /// Gets a value from the context or parent context(s) using a specified key.  Returns a boolean indicating
        /// whether or not the value was found.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <param name="result">The value if found.</param>
        /// <returns>A boolean indicating if the value was found.</returns>
        public static bool TryGetInherited<T>(this SpecFlowContext context, string key, out T result)
        {
            try
            {
                result = GetInherited<T>(context, key);
                return true;
            }
            catch (Exception)
            {
                result = default(T);
                return false;
            }
        }

        ///// <summary>
        ///// Gets a value from the context or parent context(s) using a default key.  Returns a boolean indicating
        ///// whether or not the value was found.
        ///// </summary>
        ///// <typeparam name="T">The type of the value to return.</typeparam>
        ///// <param name="context">The context.</param>
        ///// <param name="result">The value if found.</param>
        ///// <returns>A boolean indicating if the value was found.</returns>
        //public static bool TryGetInherited<T>(this SpecFlowContext context, out T result)
        //    => TryGetInherited<T>(context, typeof(T).FullName, out result);

        /// <summary>
        /// Gets a value from the context or parent context(s) using a specified key.  Adds and returns a specified
        /// default value if the key was not found.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The value to return if the key was not found.</param>
        /// <returns>The value associated with the specified key or the default value if not found.</returns>
        public static T GetInheritedOrDefault<T>(this SpecFlowContext context, string key, T defaultValue)
        {
            try
            {
                return context.GetInherited<T>(key);
            }
            catch
            {
                context.Set(defaultValue, key);
                return defaultValue;
            }
        }

        ///// <summary>
        ///// Gets a value from the context or parent context(s) using a specified key.  Adds and returns a specified
        ///// default value if the key was not found.
        ///// </summary>
        ///// <typeparam name="T">The type of the value to return.</typeparam>
        ///// <param name="context">The context.</param>
        ///// <param name="defaultValue">The value to return if the value was not found.</param>
        ///// <returns>The value associated with the default key or the default value if not found.</returns>
        //public static T GetInheritedOrDefault<T>(this SpecFlowContext context, T defaultValue)
        //    => GetInheritedOrDefault(context, typeof(T).FullName, defaultValue);

        /// <summary>
        /// Gets a value from the context using a specified key.  Adds and returns a specified default value if the
        /// key was not found.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The value to return if the key was not found.</param>
        /// <returns>The value associated with the specified key or the default value if not found.</returns>
        public static T GetOrDefault<T>(this SpecFlowContext context, string key, T defaultValue)
        {
            T value;

            if (context.TryGetValue(key, out value)) return value;

            value = defaultValue;
            context.Set(value, key);
            return value;
        }

        ///// <summary>
        ///// Gets a value from the context using a specified key.  Adds and returns a specified default value if the
        ///// key was not found.
        ///// </summary>
        ///// <typeparam name="T">The type of the value to return.</typeparam>
        ///// <param name="context">The context.</param>
        ///// <param name="defaultValue">The value to return if the value was not found.</param>
        ///// <returns>The value associated with the default key or the default value if not found.</returns>
        //public static T GetOrDefault<T>(this SpecFlowContext context, T defaultValue)
        //    => GetOrDefault(context, typeof(T).FullName, defaultValue);

        /// <summary>Updates the context value associated with a specified key.</summary>
        /// <typeparam name="T">The type of the value to update.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="updater">The function to use to update the value.</param>
        /// <returns>The updated value.</returns>
        public static T Update<T>(this SpecFlowContext context, string key, Func<T, T> updater)
        {
            key = NormalizeKey<T>(context, key);
            T currentValue = GetEx<T>(context, key);
            T newValue = updater(currentValue);
            context.Set(newValue, key);
            return newValue;
        }

        /// <summary>Updates the context value associated with a specified key.</summary>
        /// <typeparam name="T">The type of the value to update.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="updater">The action to use to update the value.</param>
        public static void Update<T>(this SpecFlowContext context, string key, Action<T> updater)
        {
            key = NormalizeKey<T>(context, key);
            T currentValue = GetEx<T>(context, key);
            updater(currentValue);
        }

        /// <summary>Updates the context value associated with a specified key.</summary>
        /// <typeparam name="T">The type of the value to update.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key.</param>
        /// <param name="updater">The function to use to update the value.</param>
        /// <param name="defaultValue">The value to use if the specified key is not found.</param>
        /// <returns>The updated value.</returns>
        public static T Update<T>(this SpecFlowContext context, string key, Func<T, T> updater, T defaultValue)
        {
            key = NormalizeKey<T>(context, key);

            if (!context.ContainsKey(key))
                context.Set(defaultValue, key);

            return Update(context, key, updater);
        }

        ///// <summary>Updates the context value associated with a specified key.</summary>
        ///// <typeparam name="T">The type of the value to update.</typeparam>
        ///// <param name="context">The context.</param>
        ///// <param name="key">The key.</param>
        ///// <param name="updater">The action to use to update the value.</param>
        ///// <param name="defaultValue">The value to use if the specified key is not found.</param>
        ///// <returns>The updated value.</returns>
        //public static void Update<T>(this SpecFlowContext context, string key, Action<T> updater, T defaultValue)
        //{
        //    key = NormalizeKey<T>(context, key);

        //    if (!context.ContainsKey(key))
        //        context.Set(defaultValue, key);

        //    Update(context, key, updater);
        //}

        ///// <summary>Updates the context value associated with a specified key.</summary>
        ///// <typeparam name="T">The type of the value to update.</typeparam>
        ///// <param name="context">The context.</param>
        ///// <param name="key">The key.</param>
        ///// <param name="updater">The function to use to update the value.</param>
        ///// <param name="defaultValueFactory">Factory to use to get a default value if the specified key is not found.</param>
        ///// <returns>The updated value.</returns>
        //public static T Update<T>(this SpecFlowContext context, string key, Func<T, T> updater, Func<T> defaultValueFactory)
        //{
        //    key = NormalizeKey<T>(context, key);

        //    if (!context.ContainsKey(key))
        //        context.Set(defaultValueFactory(), key);

        //    return Update(context, key, updater);
        //}

        /// <summary>Updates the context value associated with a specified key.</summary>
        /// <typeparam name="T">The type of the value to update.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="key">The key.</param>
        /// <param name="updater">The action to use to update the value.</param>
        /// <param name="defaultValueFactory">Factory to use to get a default value if the specified key is not found.</param>
        /// <returns>The updated value.</returns>
        public static void Update<T>(this SpecFlowContext context, string key, Action<T> updater, Func<T> defaultValueFactory)
        {
            key = NormalizeKey<T>(context, key);

            if (!context.ContainsKey(key))
                context.Set(defaultValueFactory(), key);

            Update(context, key, updater);
        }

        //public static ScenarioStepContext GetStepContext(this SpecFlowContext context)
        //{
        //    var result = context.GetOrDefault<ScenarioStepContext>("__stepContext__", null);

        //    if (result != null) return result;

        //    // If this method was called with a step context then use it otherwise set to null.
        //    SetStepContext(context, context as ScenarioStepContext);
        //    return context.Get<ScenarioStepContext>("__stepContext__");
        //}

        //public static void SetStepContext(this SpecFlowContext context, ScenarioStepContext value)
        //    => context.Set(value, "__stepContext__");

        //public static ScenarioContext GetScenarioContext(this SpecFlowContext context)
        //{
        //    var result = context.GetOrDefault<ScenarioContext>("__scenarioContext__", null);

        //    if (result != null) return result;

        //    // If this method was called with a scenario context then use it otherwise set to null.
        //    SetScenarioContext(context, context as ScenarioContext);
        //    return context.Get<ScenarioContext>("__scenarioContext__");
        //}

        //public static void SetScenarioContext(this SpecFlowContext context, ScenarioContext value)
        //    => context.Set(value, "__scenarioContext__");

        public static FeatureContext GetFeatureContext(this SpecFlowContext context)
        {
            var result = context.GetOrDefault<FeatureContext>("__featureContext__", null);

            if (result != null) return result;

            // If this method was called with a feature context then use it otherwise set to null.
            SetFeatureContext(context, context as FeatureContext);
            return context.Get<FeatureContext>("__featureContext__");
        }

        public static void SetFeatureContext(this SpecFlowContext context, FeatureContext value)
            => context.Set(value, "__featureContext__");

        public static void SetDoubleEpsilon(this SpecFlowContext context, double value)
            => context.Set(value, "doubleEpsilon");

        public static double GetDoubleEpsilon(this SpecFlowContext context)
        {
            if (!context.TryGetInherited("doubleEpsilon", out double result))
            {
                result = DefaultDoubleEpsilon;
                SetDoubleEpsilon(context, result);
            }

            return result;
        }

        public static void SetFloatEpsilon(this SpecFlowContext context, float value)
            => context.Set(value, "floatEpsilon");

        public static float GetFloatEpsilon(this SpecFlowContext context)
        {
            if (!context.TryGetInherited("floatEpsilon", out float result))
            {
                result = DefaultFloatEpsilon;
                SetFloatEpsilon(context, result);
            }

            return result;
        }

        public static void SetClipLength(this SpecFlowContext context, int value)
            => context.Set(value, "__clipLength__");

        public static int GetClipLength(this SpecFlowContext context)
        {
            if (!context.TryGetInherited("__clipLength__", out int result))
            {
                result = DefaultClipLength;
                SetClipLength(context, result);
            }

            return result;
        }

        private const double DefaultDoubleEpsilon = 0.0001;
        private const float DefaultFloatEpsilon = 0.0001f;
        private const int DefaultClipLength = 70;
    }
}
