using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExStreamsSteps
    {
        public ObservableExStreamsSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"a stream with contents")]
        public void GivenAStreamWithContents(string multilineText)
        {
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(multilineText));
            _scenario.Set(stream, "stream");
        }

        [Given(@"_a null stream")]
        public void GivenANullStream()
        {
            _scenario.Set<Stream>(null, "stream");
        }
        
        [When(@"the ToObservableByteBuffer method is called")]
        public void WhenTheToObservableByteBufferMethodIsCalled()
        {
            var stream = _scenario.Get<Stream>("stream");

            try
            {
                IObservable<IList<byte>> obs = stream.ToObservableByteBuffer();
                IList<byte> list = obs.Wait();
                _scenario.Set(list);
            }
            catch (Exception ex)
            {
                _scenario.Set(ex);
            }
        }

        private readonly ScenarioContext _scenario;
    }
}

