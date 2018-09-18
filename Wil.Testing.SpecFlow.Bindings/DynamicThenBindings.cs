using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class DynamicThenBindings : BindingsBase
    {
        public DynamicThenBindings(ScenarioContext scenarioContext, FeatureContext featureContext)
            : base(scenarioContext, featureContext)
        {
        }

        // TODO: Revisit if the SpecFlow design time feature file highlighter is updated to
        //       use Roslyn to parse source files.
        //       Attribute values must be literal strings in order for the
        //       parser to correctly highlight the files.
        //       Tests still execute properly if constants are used instead.

        // NOTE: Not capturing comparison text.  Allows for better design time highlighting.
        //       Downside is the text has to be reparsed to get the comparison :(.

        // name/result should be name
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) (?!true\b|false\b)([^\-\+\d\.]\w+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicThenBindings")]
        public void ThenNameName(string resultName, string expectedName)
            => Test(resultName, expectedName, null, null, _scenario.StepContext.StepInfo.Text);

        // name/result should be type value
        // name/result should be the type: value
        // name/result should be: value
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))(?: ((?!true\b|false\b)[^\-\+\d\.]\w+))? (true|false|[-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?)")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))(?: ([^\-\+\d\.]\w+))? (?:""([^""]*?)"")")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))(?: ([^\-\+\d\.]\w+))? (?:'([^']*?)')")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:match|contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))(?: (?:an? |the )?(\w+))?: (.+)")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicThenBindings")]
        public void ThenNameTypeValue(string resultName, string typeName, string value)
            => Test(resultName, null, typeName, value, _scenario.StepContext.StepInfo.Text);

        // name/result should be a collection of type value
        // name/result should be a collection of value
        // name/result should be value (collection)
        // name/result should be a collection of type: value
        // name/result should be a collection of: value
        // the result should be a null collection of type
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))(?: (?:(?:an? )?(\w+) of )?(?:(\w+) )?)?((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))(?: (?:(?:an? )?(\w+) of )?(?:(\w+) )?)?((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))(?: (?:(?:an? )?(\w+) of )?(?:(\w+) )?)?((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) (?:an? )?(\w+) of(?: (\w+))? (?:""([^""]*?)"")")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) (?:an? )?(\w+) of(?: (\w+))? (?:'([^']*?)')")]
        [Then(@"(?!_)(?:the )?(?:results?|(\w+)) (?:should (?:(?:not )?(?:contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be))) (?:an? )?(\w+) of(?: (\w+))?: (.+)")]
        [Then(@"(?!_)(?:the )?()results? should(?: not)? be a null (\w+) of (\w+)()")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicThenBindings")]
        public void ThenCollectionNameTypeValue(string resultName, string collectionKind, string typeName, string value)
            => TestCollection(collectionKind, resultName, typeName, value, _scenario.StepContext.StepInfo.Text);

        [Then("the result should invalidop .*")]
        [Scope(Tag = "dynamicBindings")]
        [Scope(Tag = "dynamicThenBindings")]
        public void ThenInvalidCompareOp() => Test(null, null, null, null, _scenario.StepContext.StepInfo.Text);

        private void TestCore(string resultName, string expectedName, string typeName, string value, string stepText)
        {
            string compareText = GetCompareText(stepText);
            CompareOp compareOp = ToCompareOp(compareText);
            //Console.WriteLine($"***** Testing:  result name: <{resultName}>, expected name: <{expectedName}>, type name: <{typeName}>, compare: <{compareOp}>, value: <{value}>");
            ITypeProcessor expected = null;

            if (!IsSingleCompareOp(compareOp))
            {
                if (!_manager.GetProcessorForExistingName(expectedName, out expected))
                    expected = _manager.GetProcessorFor(typeName, value);
            }

            if (expected == null)// && string.IsNullOrWhiteSpace(resultName))
            {
                expected = new ObjectProcessor(_scenario);
                expected.PostCurrentValue();
            }

            ITypeProcessor actual = _manager.GetProcessorForExistingName(resultName);
            DoCompare(actual, expected, compareOp);
        }

        private void TestCollectionCore(string collectionKind, string resultName, string typeName, string value, string stepText)
        {
            string compareText = GetCompareText(stepText);
            CompareOp compareOp = ToCompareOp(compareText);
            //Console.WriteLine($"***** Testing Collection:  collection kind: <{collectionKind}>, result name: <{resultName}>, type name: <{typeName}>, compare: <{compareOp}>, value: <{value}>");

            ITypeProcessor actual = _manager.GetCollectionProcessorForExistingName(resultName);
            ITypeProcessor expected = null;

            if (!IsSingleCompareOp(compareOp))
            {
                expected = _manager.GetCollectionProcessorFor(collectionKind, typeName, value);
            }
            else if (compareOp == CompareOp.Null || compareOp == CompareOp.NotNull)
            {
                if (actual == null)
                {
                    actual = _manager.GetCollectionProcessorFor(collectionKind, typeName, null);
                    actual?.ReadFromContext();
                }
            }

            DoCompare(actual, expected, compareOp);
        }

        private void TestSafe(string resultName, string expectedName, string typeName, string value, string stepText)
        {
            try
            {
                TestCore(resultName, expectedName, typeName, value, stepText);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void TestCollectionSafe(string collectionKind, string resultName, string typeName, string value, string stepText)
        {
            try
            {
                TestCollectionCore(collectionKind, resultName, typeName, value, stepText);
            }
            catch (Exception ex)
            {
                ProcessBindingException(ex);
            }
        }

        private void Test(string resultName, string expectedName, string typeName, string value, string stepText)
        {
            if (CaptureBindingErrors)
                TestSafe(resultName, expectedName, typeName, value, stepText);
            else
                TestCore(resultName, expectedName, typeName, value, stepText);
        }

        private void TestCollection(string collectionKind, string resultName, string typeName, string value, string stepText)
        {
            if (CaptureBindingErrors)
                TestCollectionSafe(collectionKind, resultName, typeName, value, stepText);
            else
                TestCollectionCore(collectionKind, resultName, typeName, value, stepText);
        }
    }
}
