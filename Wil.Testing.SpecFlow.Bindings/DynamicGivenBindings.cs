using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class DynamicGivenBindings : BindingsBase
    {
        public DynamicGivenBindings(ScenarioContext scenarioContext, FeatureContext featureContext)
            : base(scenarioContext, featureContext)
        {
        }

        // TODO: Revisit if the SpecFlow design time feature file highlighter is updated to
        //       use Roslyn to parse source files.
        //       Attribute values must be literal strings in order for the
        //       parser to correctly highlight the files.
        //       Tests still execute properly if constants are used instead.

        // value/null
        // value/null as a type
        // value/null as the name
        [Given(@"(?!_)(null|true|false|[-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?)(?:(?: as an? (\w+))| (?:is |as )?(?:the )?(\w+))?")]
        [Given(@"(?!_)(?:""([^""]*?)"")(?:(?: as an? (\w+))| (?:is |as )?(?:the )?(\w+))?")]
        [Given(@"(?!_)(?:'([^']*?)')(?:(?: as an? (\w+))| (?:is |as )?(?:the )?(\w+))?")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenValueType(string value, string typeName, string name) => Given(name, typeName, value);

        // type value/null as the name
        [Given(@"(?!_)(\w+) (null|true|false|[-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?) (?:is|as) (?:the )?(\w+)")]
        [Given(@"(?!_)(\w+) (?:""([^""]*?)"") (?:is|as) (?:the )?(\w+)")]
        [Given(@"(?!_)(\w+) (?:'([^']*?)') (?:is|as) (?:the )?(\w+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenTypeValueName(string typeName, string value, string name) => Given(name, typeName, value);

        // the name value/null
        // the type value/null
        // the name: value/null
        // the type: value/null
        [Given(@"(?!_)(?:the )?(\w+) (null|true|false|[-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?)")]
        [Given(@"(?!_)(?:the )?(\w+) (?:""([^""]*?)"")")]
        [Given(@"(?!_)(?:the )?(\w+) (?:'([^']*?)')")]
        [Given(@"(?!_)(?:the )?(\w+)(?: is| as)?: (.+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenTypeOrKeyValue(string typeNameOrKey, string value) => GivenTypeOrKey(typeNameOrKey, value);

        // the name is value/null
        // the name is type value/null
        // the name is type: value/null
        [Given(@"(?!_)(?:the )?(\w+) (?:is|as)(?: ([^\-\+\d\.]\w+))? (null|true|false|[-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?)")]
        [Given(@"(?!_)(?:the )?(\w+) (?:is|as)(?: ([^\-\+\d\.]\w+))? (?:""([^""]*?)"")")]
        [Given(@"(?!_)(?:the )?(\w+) (?:is|as)(?: ([^\-\+\d\.]\w+))? (?:'([^']*?)')")]
        [Given(@"(?!_)(?:the )?(\w+) (?:is|as) (\w+): (.+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenNameValue(string name, string typeName, string value) => Given(name, typeName, value);

        ////*****************************************************************************************************
        //// Collections
        ////*****************************************************************************************************

        // value
        // value is the name
        // value is a collection
        // value is a collection of type
        [Given(@"(?!_)(?!\w+\.\w+)((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)(?: (?:is |as )?(?:(?:the )?(\w+)|(?:(?:an? )?(\w+)(?: of (\w+))?)))?")]
        [Given(@"(?!_)((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)(?: (?:is |as )?(?:(?:the )?(\w+)|(?:(?:an? )?(\w+)(?: of (\w+))?)))?")]
        [Given(@"(?!_)((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)(?: (?:is |as )?(?:(?:the )?(\w+)|(?:(?:an? )?(\w+)(?: of (\w+))?)))?")]
        [Given(@"(?!_)(?:""([^""]*?)"")() (?:is|as )?(?:an? )?(\w+) of (\w+)")]
        [Given(@"(?!_)(?:'([^']*?)')() (?:is|as )?(?:an? )?(\w+) of (\w+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenCollectionValueNameType(string value, string name, string collectionKind, string typeName)
            => Given(name, typeName, value, collectionKind);

        // a null collection of type
        [Given(@"(?!_)a null (\w+) of (\w+)(?: (?:is|as) (?:the )?(\w+))?")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenCollectionNullTypeName(string collectionKind, string typeName, string name)
            => Given(name, typeName, null, collectionKind);

        // a collection of type value as the name
        // a collection of value as the name
        // the collection of type value
        // the collection of type: value
        // the collection of: value
        [Given(@"(?!_)(?:the |an? )?(?:(\w+) of )?(?:(\w+) )?(?<=\w )((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)(?: (?:is|as) (?:the )?(\w+))?")]
        [Given(@"(?!_)(?:the |an? )?(?:(\w+) of )?(?:(\w+) )?(?<=\w )((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)(?: (?:is|as) (?:the )?(\w+))?")]
        [Given(@"(?!_)(?:the |an? )?(?:(\w+) of )?(?:(\w+) )?(?<=\w )((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)(?: (?:is|as) (?:the )?(\w+))?")]
        [Given(@"(?!_)(?:the |an? )?(\w+) of(?: (\w+))? (?:""([^""]*?)"")(?: (?:is|as) (?:the )?(\w+))?")]
        [Given(@"(?!_)(?:the |an? )?(\w+) of(?: (\w+))? (?:'([^']*?)')(?: (?:is|as) (?:the )?(\w+))?")]
        [Given(@"(?!_)(?:the )?(?:an? )?(\w+) of(?: (\w+))?: (.+)()")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenCollectionTypeValue(string collectionKind, string typeName, string value, string name)
            => Given(name, typeName, value, collectionKind);

        // the name as a collection of type value
        // the name as a collection of value
        // the name as value
        // name value
        // the name as a collection of type: value
        // the name as a collection of: value
        [Given(@"(?!_)(?:the )?(\w+)(?: is| as)(?: (?:(?:an? )?(\w+) of )?(?:(\w+) )?)?((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Given(@"(?!_)(?:the )?(\w+)(?: is| as)(?: (?:(?:an? )?(\w+) of )?(?:(\w+) )?)?((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Given(@"(?!_)(?:the )?(\w+)(?: is| as)(?: (?:(?:an? )?(\w+) of )?(?:(\w+) )?)?((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Given(@"(?!_)(?:the )?(\w+) (?:is|as) (?:an? )?(\w+) of(?: (\w+))? (?:""([^""]*?)"")")]
        [Given(@"(?!_)(?:the )?(\w+) (?:is|as) (?:an? )?(\w+) of(?: (\w+))? (?:'([^']*?)')")]
        [Given(@"(?!_)(?:the )?(\w+) (?:is|as) (?:an? )?(\w+) of(?: (\w+))?: (.+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicGivenBindings")]
        public void GivenCollectionNameTypeValue(string name, string collectionKind, string typeName, string value)
            => Given(name, typeName, value, collectionKind);

        private void GivenCore(string name, string typeName, string value)
        {
            //Console.WriteLine($"***** Given:  name: {name}, type name: {typeName}, value: {value}");
            bool isNullValue = value == "null";

            ITypeProcessor processor = isNullValue
                ? _manager.GetProcessorForDataType(typeName) ?? new ObjectProcessor(_scenario)
                : _manager.GetProcessorFor(typeName, value);

            processor.PostCurrentValue(name);
            //Console.WriteLine($"***** Processor: {(processor != null ? processor.ToString() : "NULL")}");
        }

        private void GivenTypeOrKeyCore(string typeNameOrKey, string value)
        {
            //Console.WriteLine($"***** Given:  type or key: {typeNameOrKey}, value: {value}");
            bool isNullValue = value == "null";
            ITypeProcessor processor = null;

            if (isNullValue)
            {
                processor = _manager.GetProcessorForDataType(typeNameOrKey) ?? new ObjectProcessor(_scenario);
            }
            else
            {
                if (_manager.GetProcessorForDataType(typeNameOrKey, out processor))
                {
                    processor.PostValue(value);
                    return;
                }

                _manager.GetProcessorForValue(value, out processor);
            }

            processor.PostCurrentValue(typeNameOrKey);
            //Console.WriteLine($"***** Processor: {(processor != null ? processor.ToString() : "NULL")}");
        }

        private void GivenCore(string name, string typeName, string value, string collectionKind)
        {
            //Console.WriteLine($"***** Given:  name: <{name}>, type name: <{typeName}>, value: <{value}>, collection: <{collectionKind}>");

            bool isNullValue = value == null || value == "null";

            if (isNullValue)
                value = null;

            ITypeProcessor processor = _manager.GetCollectionProcessorFor(collectionKind, typeName, value);
            processor.PostCurrentValue(name);

            //Console.WriteLine($"***** Processor: {(processor != null ? processor.ToString() : "NULL")}");
        }

        private void GivenSafe(string name, string typeName, string value)
        {
            try
            {
                GivenCore(name, typeName, value);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void GivenSafe(string name, string typeName, string value, string collectionKind)
        {
            try
            {
                GivenCore(name, typeName, value, collectionKind);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void Given(string name, string typeName, string value)
        {
            if (CaptureBindingErrors)
                GivenSafe(name, typeName, value);
            else
                GivenCore(name, typeName, value);
        }

        private void GivenTypeOrKey(string typeNameOrKey, string value)
        {
            GivenTypeOrKeyCore(typeNameOrKey, value);
        }

        private void Given(string name, string typeName, string value, string collectionKind)
        {
            if (CaptureBindingErrors)
                GivenSafe(name, typeName, value, collectionKind);
            else
                GivenCore(name, typeName, value, collectionKind);
        }
    }
}
