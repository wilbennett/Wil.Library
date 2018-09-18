using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Bindings
{
    public partial class GeneratedThenBindings
    {
        [Then(@"(?:the )?(\w+) (?:should contain) ([^\-\+\d\.]\w+)")]
        [Scope(Tag = "defaultBindings")]
        [Scope(Tag = "defaultThenBindings")]
        public void ThenContainNameName(string resultName, string expectedName)
        {
        }

        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) ([-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:""([^""]*?)"")")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:'([^']*?)')")]
        [Scope(Tag = "defaultBindings")]
        [Scope(Tag = "defaultThenBindings")]
        public void ThenContainNameValue(string resultName, string value)
        {
        }

        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (\w+) ([-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (\w+) (?:""([^""]*?)"")")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (\w+) (?:'([^']*?)')")]
        [Scope(Tag = "defaultBindings")]
        [Scope(Tag = "defaultThenBindings")]
        public void ThenContainNameTypeValue(string resultName, string typeName, string value)
        {
        }

        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) ((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) ((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) ((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Scope(Tag = "defaultBindings")]
        [Scope(Tag = "defaultThenBindings")]
        public void ThenContainCollectionNameValue(string resultName, string value)
        {
        }

        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) (?:of )?((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) (?:of )?((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) (?:of )?((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) (?:of )?(?:""([^""]*?)"")")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) (?:of )?(?:'([^']*?)')")]
        [Scope(Tag = "defaultBindings")]
        [Scope(Tag = "defaultThenBindings")]
        public void ThenContainCollectionNameKindValue(string resultName, string collectionKind, string value)
        {
        }

        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) of (\w+) ((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) of (\w+) ((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) of (\w+) ((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) of (\w+) (?:""([^""]*?)"")")]
        [Then(@"(?!_)(?:the )?(\w+) (?:should contain) (?:an? )?(\w+) of (\w+) (?:'([^']*?)')")]
        [Scope(Tag = "defaultBindings")]
        [Scope(Tag = "defaultThenBindings")]
        public void ThenContainCollectionNameTypeValue(string resultName, string collectionKind, string typeName, string value)
        {
        }
    }
}
