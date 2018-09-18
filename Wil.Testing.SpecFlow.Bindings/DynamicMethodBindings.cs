using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class DynamicMethodBindings : BindingsBase
    {
        public DynamicMethodBindings(ScenarioContext scenarioContext, FeatureContext featureContext)
            : base(scenarioContext, featureContext)
        {
        }

        // TODO: Revisit if the SpecFlow design time feature file highlighter is updated to
        //       use Roslyn to parse source files.
        //       Attribute values must be literal strings in order for the
        //       parser to correctly highlight the files.
        //       Tests still execute properly if constants are used instead.

        // name is the result of keyOrTypeName.methodname()
        // keyOrTypeName.methodname() is called
        // name is the result of keyOrTypeName.methodname(argsKey)
        // keyOrTypeName.methodname(argsKey) is called
        [Given(@"(?!_)(\w+) (?:i|a)s the result of (?:calling )?(\w+)\.(\w+)\(([^""']\S*|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)?\)")]
        [Given(@"(?!_)()(\w+)\.(\w+)\((\w+|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)?\) is called")]
        [When(@"(?!_)(\w+) (?:i|a)s the result of (?:calling )?(\w+)\.(\w+)\(([^""']\S*|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)?\)")]
        [When(@"(?!_)()(\w+)\.(\w+)\((\w+|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)?\) is called")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicMethodBindings")]
        public void MethodNameInstanceMethodArgsKey(string name, string keyOrTypeName, string methodName, string argsKey)
            => Method(name, methodName, keyOrTypeName, argsKey);

        // name is the result of keyOrTypeName.methodname(args)
        // keyOrTypeName.methodname(argsKey) is called
        [Given(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\((?:""([^""]*?)"")\)")]
        [Given(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\((?:'([^']*?)')\)")]
        [Given(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\(((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)\)")]
        [Given(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\(((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)\)")]
        [Given(@"(?!_)()(\w+)\.(\w+)\((?:""([^""]*?)"")\) is called")]
        [Given(@"(?!_)()(\w+)\.(\w+)\((?:'([^']*?)')\) is called")]
        [Given(@"(?!_)()(\w+)\.(\w+)\(((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)\) is called")]
        [Given(@"(?!_)()(\w+)\.(\w+)\(((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)\) is called")]
        [When(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\((?:""([^""]*?)"")\)")]
        [When(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\((?:'([^']*?)')\)")]
        [When(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\(((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)\)")]
        [When(@"(?!_)(\w+) (?:i|a)s the result of (\w+)\.(\w+)\(((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)\)")]
        [When(@"(?!_)()(\w+)\.(\w+)\((?:""([^""]*?)"")\) is called")]
        [When(@"(?!_)()(\w+)\.(\w+)\((?:'([^']*?)')\) is called")]
        [When(@"(?!_)()(\w+)\.(\w+)\(((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)\) is called")]
        [When(@"(?!_)()(\w+)\.(\w+)\(((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)\) is called")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicMethodBindings")]
        public void MethodNameInstanceMethodArgs(string name, string keyOrTypeName, string methodName, string args)
            => MethodValue(name, methodName, keyOrTypeName, args);

        private void MethodImpl(string name, string methodName, string keyOrTypeName, string keyOrValue, bool isValue)
        {
            //Console.WriteLine($"***** Method:  name: <{name}>, methodName: <{methodName}>, keyOrTypeName: <{keyOrTypeName}>, keyOrValue: <{keyOrValue}>");

            List<string> keyOrValueList = keyOrValue.ToStringsList();

            object[] args
                = isValue
                ? keyOrValueList.Select(arg => _manager.GetProcessorForValue(arg).Value).ToArray()
                : keyOrValueList.Select(argName => _scenario.GetEx<object>(argName)).ToArray();

            Type[] argTypes = args.Select(a => a.GetType()).ToArray();
            GetTypeFromContextOrAssembly(keyOrTypeName, out Type type, out object instance);
            MethodInfo method = type.GetMethod(methodName, argTypes);
            CheckMethodExists(methodName, type, method, argTypes);

            object methodResult = method.Invoke(instance, args);

            if (method.ReturnType == typeof(void)) return;

            _scenario.Set(methodResult, name.NullIfEmpty() ?? method.ReturnType.FullName);
        }

        private void MethodCore(string name, string methodName, string keyOrTypeName, string argsKey)
            => MethodImpl(name, methodName, keyOrTypeName, argsKey, false);

        private void MethodValueCore(string name, string methodName, string keyOrTypeName, string args)
            => MethodImpl(name, methodName, keyOrTypeName, args, true);

        private void MethodSafe(string name, string methodName, string keyOrTypeName, string argsKey)
        {
            try
            {
                MethodCore(name, methodName, keyOrTypeName, argsKey);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void MethodValueSafe(string name, string methodName, string keyOrTypeName, string args)
        {
            try
            {
                MethodValueCore(name, methodName, keyOrTypeName, args);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void Method(string name, string methodName, string keyOrTypeName, string argsKey)
        {
            if (CaptureBindingErrors)
                MethodSafe(name, methodName, keyOrTypeName, argsKey);
            else
                MethodCore(name, methodName, keyOrTypeName, argsKey);
        }

        private void MethodValue(string name, string methodName, string keyOrTypeName, string args)
        {
            if (CaptureBindingErrors)
                MethodValueSafe(name, methodName, keyOrTypeName, args);
            else
                MethodValueCore(name, methodName, keyOrTypeName, args);
        }

        private static void CheckMethodExists(string methodName, Type type, MethodInfo method, Type[] args)
        {
            if (method != null) return;

            string argTypeNames = string.Join(", ", args.Select(a => a.Name));
            string message = $"ERROR: Method not found: {type.FullName}.{methodName}({argTypeNames})";
            Console.WriteLine(message);

            throw new Exception(message);
        }
    }
}
