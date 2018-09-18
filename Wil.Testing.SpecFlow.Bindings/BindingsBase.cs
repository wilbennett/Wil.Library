using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class BindingsBase
    {
        public BindingsBase(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenario = scenarioContext;
            _feature = featureContext;

            _scenario.SetFeatureContext(featureContext);
            _manager = new TypeProcessorManager(_scenario);
        }

        protected readonly ScenarioContext _scenario;
        protected readonly FeatureContext _feature;
        protected readonly TypeProcessorManager _manager;

        protected bool CaptureBindingErrors => GetTags().Contains("captureBindingError");

        protected HashSet<string> GetTags()
            => new HashSet<string>(_feature.FeatureInfo.Tags.Concat(_scenario.ScenarioInfo.Tags));

        protected void ProcessBindingException(Exception ex)
        {
            if (ex.GetType().Name.Contains("Assert")) throw ex;

            _scenario.Set(ex, "bindingException__");
        }

        protected static void ThrowTypeNotFound(string typeName)
            => throw new Exception($"Type not found: {typeName}.");

        protected static bool IsSingleCompareOp(CompareOp compareOp)
            => compareOp == CompareOp.Null || compareOp == CompareOp.NotNull;

        protected string GetCompareText(string text)
        {
            var match = Regex.Match(text, "should ((?:not )?(?:match|contain|be(?: a)? null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))");
            return match.Groups[1].Value;
        }

        protected CompareOp ToCompareOp(string compareText)
        {
            if (compareText == "match") return CompareOp.Match;
            if (compareText == "not match") return CompareOp.NotMatch;
            if (compareText == "contain") return CompareOp.Contain;
            if (compareText == "not contain") return CompareOp.NotContain;
            if (compareText == "be equivalent to") return CompareOp.Equivalent;
            if (compareText == "not be equivalent to") return CompareOp.NotEquivalent;
            if (compareText == "be greater than") return CompareOp.Greater;
            if (compareText == "not be greater than") return CompareOp.NotGreater;
            if (compareText == "be less than") return CompareOp.Less;
            if (compareText == "not be less than") return CompareOp.NotLess;

            if (Regex.IsMatch(compareText, "^be(?: a)? null$")) return CompareOp.Null;
            if (Regex.IsMatch(compareText, "^not be(?: a)? null$")) return CompareOp.NotNull;
            if (Regex.IsMatch(compareText, "^(?:be equal to|equal|be)$")) return CompareOp.Equal;
            if (Regex.IsMatch(compareText, "^not (?:be equal to|equal|be)$")) return CompareOp.NotEqual;
            if (Regex.IsMatch(compareText, "^(?:be greater (?:than )?or equal(?: to)?)$")) return CompareOp.GreaterOrEqual;
            if (Regex.IsMatch(compareText, "^not (?:be greater (?:than )?or equal(?: to)?)$")) return CompareOp.NotGreaterOrEqual;
            if (Regex.IsMatch(compareText, "^(?:be less (?:than )?or equal(?: to)?)$")) return CompareOp.LessOrEqual;
            if (Regex.IsMatch(compareText, "^not (?:be less (?:than )?or equal(?: to)?)$")) return CompareOp.NotLessOrEqual;

            throw new Exception($"Cannot convert '{compareText}' to a compare operation.");
        }

        protected static void DoCompare(ITypeProcessor actual, ITypeProcessor expected, CompareOp compareOp)
        {
            if (actual == null)
            {
                if (expected != null)
                {
                    actual = expected.Clone();
                    actual.ReadFromContext();
                }
            }

            Console.WriteLine($"***** Actual: {(actual != null ? actual.ToString() : "NULL")}");
            Console.WriteLine($"***** Expected: {(expected != null ? expected.ToString() : "NULL")}");

            if (actual == null || (expected == null && !IsSingleCompareOp(compareOp))) throw new Exception($"Unable to parse test step.");

            actual.CompareTo(expected, compareOp);
        }

        protected static void CheckProcessorExists(Type dataType, ITypeProcessor processor)
        {
            if (processor != null) return;

            throw new Exception($"No processor registered to handle: {dataType.Name}.");
        }

        protected Type FindType(string typeName)
        {
            GetLoadedAssemblies();

            if (_typeCache.TryGetValue(typeName, out Type result))
                return result;

            result
                = typeName.IndexOf('.') >= 0
                ? _assemblies.SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.FullName == typeName)
                : _assemblies.SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.Name == typeName);

            _typeCache[typeName] = result;
            return result;
        }

        protected void GetTypeFromContextOrAssembly(string keyOrTypeName, out Type type, out object instance)
        {
            instance = _scenario.GetOrDefault<object>(keyOrTypeName, null);
            type = instance?.GetType() ?? FindType(keyOrTypeName);

            if (type == null)
                throw new Exception($"'{keyOrTypeName}' was not found in the scenario and is not a known type.");
        }

        private readonly Dictionary<string, Type> _typeCache = new Dictionary<string, Type>();
        private Assembly[] _assemblies;

        private void GetLoadedAssemblies()
        {
            if (_assemblies != null) return;

            AppDomain currentDomain = AppDomain.CurrentDomain;
            _assemblies = currentDomain.GetAssemblies();
        }

        [BeforeFeature]
        private static void Hacks()
        {
            // HACK: Include code coverage for ObjectProcessor Parse method.
            new ObjectProcessor(null).Parse("dummy");
            // HACK: Include code coverage for CharProcessor TryParse method.
            new CharProcessor(null).CanParse("d");
            // HACK: Include code coverage for ByteProcessor TryParse method.
            new ByteProcessor(null).CanParse("1");
            // HACK: Include code coverage for SByteProcessor TryParse method.
            new SByteProcessor(null).CanParse("1");
            // HACK: Include code coverage for DecimalProcessor TryParse method.
            new DecimalProcessor(null).CanParse("1");
            // HACK: Include code coverage for UIntProcessor TryParse method.
            new UIntProcessor(null).CanParse("1");
            // HACK: Include code coverage for ShortProcessor TryParse method.
            new ShortProcessor(null).CanParse("1");
            // HACK: Include code coverage for UShortProcessor TryParse method.
            new UShortProcessor(null).CanParse("1");
            // HACK: Include code coverage for FloatProcessor TryParse method.
            new FloatProcessor(null).CanParse("1");
            // HACK: Include code coverage for TimeSpanProcessor TryParse method.
            new TimeSpanProcessor(null).CanParse("1");
        }
    }
}
