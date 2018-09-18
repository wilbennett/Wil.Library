namespace Wil.Testing.SpecFlow.Bindings
{
    // NOT USED.
    // The SpecFlow design time feature file highlighter requires attribute values to be literal strings in order for
    // the parser to correctly highlight the files.
    public static class BindConst
    {
        public const string DynamicBindingsTag = "dynamicBindings";
        public const string DynamicGivenBindingsTag = "dynamicGivenBindings";
        public const string DynamicThenBindingsTag = "dynamicThenBindings";

        public const string NotIgnore = "(?!_)";
        public const string NumberRegexText = @"([-+]?(?:\b[0-9]+(?:\.[0-9]*)?|\.[0-9]+\b)(?:[eE][-+]?[0-9]+\b)?)";
        public const string DoubleQuotedStringRegexText = @"(?:""([^""]*?)"")";
        public const string SingleQuotedStringRegexText = "(?:'([^']*?)')";
        public const string SimpleCollectionRegexText = @"((?:[^,'""\s]+)?\s*(?:,(?:\s*[^,'""\s]+))+,?)";  // 1, 2, 3
        public const string DoubleQuotedCollectionRegexText = @"((?:""(?:[^""]|"""")*"")?\s*(?:,\s*""(?:[^""]|"""")*"")+,?)"; // "one", "two", "three"
        public const string SingleQuotedCollectionRegexText = @"((?:'(?:[^']|'')*')?\s*(?:,\s*'(?:[^']|'')*')+,?)"; // 'one', 'two', 'three'

        public const string ComparisonsRegexText
            = "(?:should (?:(?:not )?(?:contain|be null|be equivalent to|be (?:less|greater)(?:(?: (?:than )?or equal(?: to)?)| than)|be equal to|equal|be)))";
    }
}
