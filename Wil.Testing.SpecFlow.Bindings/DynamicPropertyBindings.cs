using System;
using System.Collections.Generic;
using System.Reflection;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class DynamicPropertyBindings : BindingsBase
    {
        public DynamicPropertyBindings(ScenarioContext scenarioContext, FeatureContext featureContext)
            : base(scenarioContext, featureContext)
        {
        }

        // TODO: Revisit if the SpecFlow design time feature file highlighter is updated to
        //       use Roslyn to parse source files.
        //       Attribute values must be literal strings in order for the
        //       parser to correctly highlight the files.
        //       Tests still execute properly if constants are used instead.

        // the name is keyOrTypeName.propertyName
        // the keyOrTypeName.propertyName is retrieved|read
        [Given(@"(?!_)(?:the )?(?:(\w+) (?:i|a)s )?([a-zA-Z]\w*)\.([a-zA-Z]\w*)")]
        [When(@"(?!_)()(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is (?:read|retrieved)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicPropertyBindings")]
        public void PropertyNameTypeArgs(string name, string keyOrTypeName, string propName)
            => Property(name, propName, keyOrTypeName);

        // keyOrTypeName.propertyName is set to valueKey
        [Given(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? (?!read|retrieved)(\w+)")]
        [When(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? (?!read|retrieved)(\w+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicPropertyBindings")]
        public void PropertySetInstancePropKey(string keyOrTypeName, string propName, string valueKey)
            => PropertySet(propName, keyOrTypeName, valueKey);

        // keyOrTypeName.propertyname is set to value 
        // keyOrTypeName.propertyname is set to valuecollection
        [Given(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? (?:""([^""]*?)"")")]
        [Given(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? (?:'([^']*?)')")]
        [Given(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? ((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Given(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? ((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Given(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? ((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [When(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? (?:""([^""]*?)"")")]
        [When(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? (?:'([^']*?)')")]
        [When(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? ((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [When(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? ((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [When(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) is(?: set to)? ((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicPropertyBindings")]
        public void PropertySetInstancePropValue(string keyOrTypeName, string propName, string value)
            => PropertySetValue(propName, keyOrTypeName, value);

        // keyOrTypeName.propertyname should compareop valueKey
        [Then(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) (\w+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicPropertyBindings")]
        public void PropertyTestInstancePropKey(string keyOrTypeName, string propName, string valueKey)
            => PropertyTest(propName, keyOrTypeName, valueKey, _scenario.StepContext.StepInfo.Text);

        // keyOrTypeName.propertyname should compareop keyOrTypeName2.propertyname2
        // the valueKey should compareop keyOrTypeName2.propertyname2
        // the result should compareop keyOrTypeName2.propertyname2
        [Then(@"(?!_)(?:the )?(?:([a-zA-Z]\w*)\.)?(?:results?|([a-zA-Z]\w*)) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) ([a-zA-Z]\w*)\.([a-zA-Z]\w*)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicPropertyBindings")]
        public void PropertyTestInstancePropKey(
            string keyOrTypeName,
            string propNameOrValueKey,
            string keyOrTypeName2,
            string propName2)
            => PropertyTest(
                propNameOrValueKey,
                keyOrTypeName,
                propName2,
                keyOrTypeName2,
                _scenario.StepContext.StepInfo.Text);

        // keyOrTypeName property propertyname should compareop value
        // keyOrTypeName property propertyname should compareop valuecollection
        // keyOrTypeName.propertyname should compareop value
        // keyOrTypeName.propertyname should compareop valuecollection
        [Then(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) (?:""([^""]*?)"")")]
        [Then(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) (?:'([^']*?)')")]
        [Then(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) ((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Then(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) ((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Then(@"(?!_)(?:the )?([a-zA-Z]\w*)\.([a-zA-Z]\w*) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) ((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicPropertyBindings")]
        public void PropertyTestInstancePropValue(string keyOrTypeName, string propName, string value)
            => PropertyTestValue(propName, keyOrTypeName, value, _scenario.StepContext.StepInfo.Text);

        private readonly Dictionary<string, PropertyInfo> _propertyCache = new Dictionary<string, PropertyInfo>();

        private static void CheckPropertyOrFieldExists(string name, Type type, PropertyInfo prop, FieldInfo field)
        {
            if (prop != null || field != null) return;

            throw new Exception($"Property or field '{name}' does not exist on type '{type.FullName}'.");
        }

        private PropertyInfo FindProperty(string propName, Type type)
        {
            string key = $"{type.FullName}.{propName}";

            if (_propertyCache.TryGetValue(key, out PropertyInfo result))
                return result;

            result = type.GetProperty(propName);
            _propertyCache[key] = result;
            return result;
        }

        private void GetPropertyOrFieldData(
            string name,
            string keyOrTypeName,
            out object instance,
            out PropertyInfo propInfo,
            out FieldInfo fieldInfo)
        {
            instance = null;
            propInfo = null;
            fieldInfo = null;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(keyOrTypeName)) return;

            GetTypeFromContextOrAssembly(keyOrTypeName, out Type type, out instance);
            propInfo = FindProperty(name, type);
            CheckPropertyOrFieldExists(name, type, propInfo, fieldInfo);
        }

        private ITypeProcessor GetProcessorFor(object instance, PropertyInfo prop, FieldInfo field)
        {
            Type propFieldType = prop?.PropertyType ?? field?.FieldType;
            ITypeProcessor processor = _manager.GetProcessorFor(propFieldType);
            CheckProcessorExists(propFieldType, processor);

            object value = prop != null ? prop.GetValue(instance) : field.GetValue(instance);
            processor.SetValue(value);
            return processor;
        }

        private ITypeProcessor GetProcessorFor(string valueKey, object instance, PropertyInfo prop, FieldInfo field)
        {
            return prop != null || field != null
                ? GetProcessorFor(instance, prop, field)
                : _manager.GetProcessorForExistingName(valueKey);
        }

        private void PropertyCore(string name, string propName, string keyOrTypeName)
        {
            //Console.WriteLine($"***** Property:  name: <{name}>, propName: <{propName}>, keyOrTypeName: <{keyOrTypeName}>");

            GetPropertyOrFieldData(propName, keyOrTypeName, out object instance, out PropertyInfo prop, out FieldInfo field);

            object value = prop != null ? prop.GetValue(instance) : field.GetValue(instance);
            string key = name.NullIfEmpty() ?? prop?.PropertyType.FullName ?? field?.FieldType.FullName;
            _scenario.Set(value, key);
        }

        private void PropertySetImpl(string propName, string keyOrTypeName, string keyOrValue, bool isValue)
        {
            //Console.WriteLine($"***** PropertySet:  propName: <{propName}>, keyOrTypeName: <{keyOrTypeName}>, keyOrValue: <{keyOrValue}>");

            GetPropertyOrFieldData(propName, keyOrTypeName, out object instance, out PropertyInfo prop, out FieldInfo field);

            var setValue = prop != null ? (Action<object, object>)prop.SetValue : field.SetValue;

            if (!isValue)
            {
                setValue(instance, _scenario.GetEx<object>(keyOrValue));
                return;
            }

            ITypeProcessor processor = _manager.GetProcessorFor(prop.PropertyType);
            CheckProcessorExists(prop.PropertyType, processor);
            processor.SetValue(keyOrValue);
            setValue(instance, processor.Value);
        }

        private void PropertySetCore(string propName, string keyOrTypeName, string valueKey)
            => PropertySetImpl(propName, keyOrTypeName, valueKey, false);

        private void PropertySetValueCore(string propName, string keyOrTypeName, string value)
            => PropertySetImpl(propName, keyOrTypeName, value, true);

        private void PropertyTestImpl(
            string propNameOrValueKey,
            string keyOrTypeName,
            string keyOrValue,
            string stepText,
            bool isValue,
            string propName2 = null,
            string keyOrTypeName2 = null)
        {
            string compareText = GetCompareText(stepText);
            CompareOp compareOp = ToCompareOp(compareText);
            //Console.WriteLine($"***** PropertyTest:  propName: <{propNameOrValueKey}>, keyOrTypeName: <{keyOrTypeName}>, keyOrValue: <{keyOrValue}>, compare: <{compareOp}>, propName2: <{propName2}>, keyOrTypeName2: <{keyOrTypeName2}>");

            GetPropertyOrFieldData(propNameOrValueKey, keyOrTypeName, out object instance, out PropertyInfo prop, out FieldInfo field);
            GetPropertyOrFieldData(propName2, keyOrTypeName2, out object instance2, out PropertyInfo prop2, out FieldInfo field2);

            ITypeProcessor actual = GetProcessorFor(propNameOrValueKey, instance, prop, field);
            ITypeProcessor expected = null;

            if (!IsSingleCompareOp(compareOp))
            {
                if (isValue)
                {
                    expected = actual.Clone();
                    expected.SetValue(keyOrValue);
                }
                else
                {
                    expected = GetProcessorFor(keyOrValue, instance2, prop2, field2);
                }
            }

            if (expected == null)
            {
                expected = new ObjectProcessor(_scenario);
                expected.PostCurrentValue();
            }

            DoCompare(actual, expected, compareOp);
        }

        private void PropertyTestCore(string propName, string keyOrTypeName, string valueKey, string stepText)
            => PropertyTestImpl(propName, keyOrTypeName, valueKey, stepText, false);

        private void PropertyTestValueCore(string propName, string keyOrTypeName, string value, string stepText)
            => PropertyTestImpl(propName, keyOrTypeName, value, stepText, true);

        private void PropertyTestCore(
            string propNameOrValueKey,
            string keyOrTypeName,
            string propName2,
            string keyOrTypeName2,
            string stepText)
            => PropertyTestImpl(propNameOrValueKey, keyOrTypeName, null, stepText, false, propName2, keyOrTypeName2);

        private void PropertySafe(string name, string propName, string keyOrTypeName)
        {
            try
            {
                PropertyCore(name, propName, keyOrTypeName);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void PropertySetSafe(string propName, string keyOrTypeName, string valueKey)
        {
            try
            {
                PropertySetCore(propName, keyOrTypeName, valueKey);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void PropertySetValueSafe(string propName, string keyOrTypeName, string value)
        {
            try
            {
                PropertySetValueCore(propName, keyOrTypeName, value);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void PropertyTestSafe(string propName, string keyOrTypeName, string valueKey, string stepText)
        {
            try
            {
                PropertyTestCore(propName, keyOrTypeName, valueKey, stepText);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void PropertyTestValueSafe(string propName, string keyOrTypeName, string value, string stepText)
        {
            try
            {
                PropertyTestValueCore(propName, keyOrTypeName, value, stepText);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void PropertyTestSafe(
            string propNameOrValueKey,
            string keyOrTypeName,
            string propName2,
            string keyOrTypeName2,
            string stepText)
        {
            try
            {
                PropertyTestCore(propNameOrValueKey, keyOrTypeName, propName2, keyOrTypeName2, stepText);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void Property(string name, string propName, string keyOrTypeName)
        {
            if (CaptureBindingErrors)
                PropertySafe(name, propName, keyOrTypeName);
            else
                PropertyCore(name, propName, keyOrTypeName);
        }

        private void PropertySet(string propName, string keyOrTypeName, string valueKey)
        {
            if (CaptureBindingErrors)
                PropertySetSafe(propName, keyOrTypeName, valueKey);
            else
                PropertySetCore(propName, keyOrTypeName, valueKey);
        }

        private void PropertySetValue(string propName, string keyOrTypeName, string value)
        {
            if (CaptureBindingErrors)
                PropertySetValueSafe(propName, keyOrTypeName, value);
            else
                PropertySetValueCore(propName, keyOrTypeName, value);
        }

        private void PropertyTest(string propName, string keyOrTypeName, string valueKey, string stepText)
        {
            if (CaptureBindingErrors)
                PropertyTestSafe(propName, keyOrTypeName, valueKey, stepText);
            else
                PropertyTestCore(propName, keyOrTypeName, valueKey, stepText);
        }

        private void PropertyTestValue(string propName, string keyOrTypeName, string value, string stepText)
        {
            if (CaptureBindingErrors)
                PropertyTestValueSafe(propName, keyOrTypeName, value, stepText);
            else
                PropertyTestValueCore(propName, keyOrTypeName, value, stepText);
        }

        private void PropertyTest(
            string propNameOrValueKey,
            string keyOrTypeName,
            string propName2,
            string keyOrTypeName2,
            string stepText)
        {
            if (CaptureBindingErrors)
                PropertyTestSafe(propNameOrValueKey, keyOrTypeName, propName2, keyOrTypeName2, stepText);
            else
                PropertyTestCore(propNameOrValueKey, keyOrTypeName, propName2, keyOrTypeName2, stepText);
        }
    }
}
