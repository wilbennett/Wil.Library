using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Specs
{
    public class PersonProcessor : ValueProcessor<Person>
    {
        public PersonProcessor(SpecFlowContext context)
            : base(context, "Person", "Person")
        {
        }

        protected override Person ParseCore(string text) => Person.Parse(text);
    }
}

