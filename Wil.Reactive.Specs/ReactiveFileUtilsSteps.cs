using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using TechTalk.SpecFlow;
using Wil.Testing;
using Wil.Core;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ReactiveFileUtilsSteps
    {
        public ReactiveFileUtilsSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"a name of a temporary file")]
        public void GivenANameOfATemporaryFile()
        {
            string filePath = Path.GetTempFileName();
            File.Delete(filePath);
            _scenario.Set(filePath, "filePath");
        }

        [Given(@"the file contents is set to")]
        public void GivenTheFileContentsIsSetTo(string multilineText)
        {
            var filePath = _scenario.Get<string>("filePath");
            File.WriteAllText(filePath, multilineText);
        }
        
        [When(@"the ReadObservableChars method is called with the filename")]
        public void WhenTheReadObservableCharsMethodIsCalledWithTheFilename()
        {
            try
            {
                var filePath = _scenario.Get<string>("filePath");
                var stream = ReactiveFileUtils.ReadObservableChars(filePath);
                IList<char> result = stream.ToList().Wait();
                _scenario.Set(result);
            }
            catch (Exception ex)
            {
                _scenario.Set(ex);
            }
        }

        [When(@"the ReadObservableStrings method is called with the filename")]
        public void WhenTheReadObservableStringsMethodIsCalledWithTheFilename()
        {
            try
            {
                var filePath = _scenario.Get<string>("filePath");
                var stream = ReactiveFileUtils.ReadObservableStrings(filePath);
                _scenario.Set<IList<string>>(stream.ToList().Wait());
            }
            catch (Exception ex)
            {
                _scenario.Set(ex);
            }
        }

        [When(@"the ReadObservableBytes method is called with the filename")]
        public void WhenTheReadObservableBytesMethodIsCalledWithTheFilename()
        {
            var filePath = _scenario.Get<string>("filePath");
            var stream = ReactiveFileUtils.ReadObservableBytes(filePath);
            _scenario.Set<IList<byte>>(stream.ToList().Wait());
        }

        [When(@"the ReadObservableByteBuffer method is called with the filename and bufferSize")]
        public void WhenTheReadObservableByteBufferMethodIsCalledWithTheFilenameAndBufferSize()
        {
            var filePath = _scenario.Get<string>("filePath");
            var bufferSize = _scenario.Get<int>("bufferSize");
            var stream = ReactiveFileUtils.ReadObservableByteBuffer(filePath, bufferSize);
            IList<IList<byte>> lists = stream.ToList().Wait();
            _scenario.Set<byte[][]>(lists.ToJagged(), "result");
        }

        [Then(@"matrix ""(.*)"" should be byte matrix ""(.*)""")]
        public void ThenMatrixShouldBeByteMatrix(string actualName, byte[][] expected)
        {
            Console.WriteLine($"ActualName: {actualName}");
            byte[][] actual = _scenario.Get<byte[][]>(actualName);

            int expectedCount = expected.Length;
            int actualCount = actual.Length;
            Assert.AreEqual(expectedCount, actualCount);

            for (int i = 0; i < expectedCount; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i], $"Row {i}.");
            }
        }

        [Then(@"an exception should have been thrown")]
        public void AnExceptionShouldHaveBeenThrown()
        {
            _scenario.TryGetValue<Exception>(out Exception exception);
            Assert.IsNotNull(exception);
        }

        private readonly ScenarioContext _scenario;
    }
}
