using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class DynamicConstructorBindings : BindingsBase
    {
        public DynamicConstructorBindings(ScenarioContext scenarioContext, FeatureContext featureContext)
            : base(scenarioContext, featureContext)
        {
        }

        // TODO: Revisit if the SpecFlow design time feature file highlighter is updated to
        //       use Roslyn to parse source files.
        //       Attribute values must be literal strings in order for the
        //       parser to correctly highlight the files.
        //       Tests still execute properly if constants are used instead.

        // name is a typeName created with arguments
        // name is a new typeName
        // name is a new typeName(arguments)
        [Given(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with ([^""']\S*|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Given(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\(([^""']\S*|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)\)")]
        [Given(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)()")]
        [When(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with ([^""']\S*|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [When(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\(([^""']\S*|(?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)\)")]
        [When(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)()")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicConstructorBindings")]
        public void ConstructNameTypeArgs(string name, string typeName, string args) => Construct(name, typeName, args);

        // name is a typeName created with argumentValue
        // name is a new typeName(argumentValue)
        [Given(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with (?:""([^""]*?)"")")]
        [Given(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with (?:'([^']*?)')")]
        [Given(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\((?:""([^""]*?)"")\)")]
        [Given(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\((?:'([^']*?)')\)")]
        [When(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with (?:""([^""]*?)"")")]
        [When(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with (?:'([^']*?)')")]
        [When(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\((?:""([^""]*?)"")\)")]
        [When(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\((?:'([^']*?)')\)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicConstructorBindings")]
        public void ConstructNameTypeArgValue(
            string name, string typeName, string args) => Construct(name, typeName, new List<string>(new[] { args }));

        // name is a typeName created with argumentValues
        // name is a new typeName(argumentValues)
        [Given(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with ((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Given(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with ((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Given(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\(((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)\)")]
        [Given(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\(((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)\)")]
        [When(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with ((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [When(@"(?!_)(\w+) (?:i|a)s an? (\w[\w\.]+) created with ((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [When(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\(((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)\)")]
        [When(@"(?!_)(\w+) (?:i|a)s a new (\w[\w\.]+)\(((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)\)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicConstructorBindings")]
        public void ConstructNameTypeArgValues(
            string name, string typeName, string args) => Construct(name, typeName, args.ToStringsList());

        private void ConstructImpl(string name, string typeName, List<string> argNamesOrValues, bool isValue)
        {
            //Console.WriteLine($"***** Construct:  name: <{name}>, type name: <{typeName}>, args: <{string.Join(", ", argNamesOrValues)}>");

            object[] args
                = isValue
                ? argNamesOrValues.Select(v => _manager.GetProcessorForValue(v).Value).ToArray()
                : argNamesOrValues.Select(argName => _scenario.GetEx<object>(argName)).ToArray();

            Type type = FindType(typeName);

            if (type == null)
                ThrowTypeNotFound(typeName);

            object instance = Activator.CreateInstance(type, args);
            _scenario.Set(instance, name.NullIfEmpty() ?? type.FullName);
        }

        private void ConstructCore(string name, string typeName, string argNames)
            => ConstructImpl(name, typeName, argNames.ToStringsList(), false);

        private void ConstructCore(string name, string typeName, List<string> argValues)
            => ConstructImpl(name, typeName, argValues, true);

        private void ConstructSafe(string name, string typeName, string argNames)
        {
            try
            {
                ConstructCore(name, typeName, argNames);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void ConstructSafe(string name, string typeName, List<string> argValues)
        {
            try
            {
                ConstructCore(name, typeName, argValues);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void Construct(string name, string typeName, string argNames)
        {
            if (CaptureBindingErrors)
                ConstructSafe(name, typeName, argNames);
            else
                ConstructCore(name, typeName, argNames);
        }

        private void Construct(string name, string typeName, List<string> argValues)
        {
            if (CaptureBindingErrors)
                ConstructSafe(name, typeName, argValues);
            else
                ConstructCore(name, typeName, argValues);
        }
    }
}
