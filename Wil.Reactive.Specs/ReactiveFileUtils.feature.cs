﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Wil.Reactive.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ReactiveFileUtilsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ReactiveFileUtils.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ReactiveFileUtils", "    In order to easily work with files\r\n    As a user\r\n    I want to be able to e" +
                    "xpose file contents as an observable stream", ProgrammingLanguage.CSharp, new string[] {
                        "dynamicBindings"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ReactiveFileUtils")))
            {
                global::Wil.Reactive.Specs.ReactiveFileUtilsFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line 8
    testRunner.Given("a name of a temporary file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
      testRunner.And("the file contents is set to", "line 1\r\nline 2", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read a file as an stream of chars")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReactiveFileUtils")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReadAFileAsAnStreamOfChars()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read a file as an stream of chars", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 16
    testRunner.When("the ReadObservableChars method is called with the filename", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
    testRunner.Then("the result should be ilist of chars \"l\", \"i\", \"n\", \"e\", \" \", \"1\", \"\\r\", \"\\n\", \"l\"" +
                    ", \"i\", \"n\", \"e\", \" \", \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read a file as an stream of strings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReactiveFileUtils")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReadAFileAsAnStreamOfStrings()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read a file as an stream of strings", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 20
    testRunner.When("the ReadObservableStrings method is called with the filename", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
    testRunner.Then("the result should be ilist of strings \"line 1\", \"line 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read a file as an stream of bytes")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReactiveFileUtils")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReadAFileAsAnStreamOfBytes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read a file as an stream of bytes", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 24
    testRunner.When("the ReadObservableBytes method is called with the filename", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
    testRunner.Then("the result should be ilist of bytes 108, 105, 110, 101, 32, 49, 13, 10, 108, 105," +
                    " 110, 101, 32, 50", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read a file as an stream of byte lists")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReactiveFileUtils")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReadAFileAsAnStreamOfByteLists()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read a file as an stream of byte lists", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 28
   testRunner.Given("bufferSize is 8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
    testRunner.When("the ReadObservableByteBuffer method is called with the filename and bufferSize", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
    testRunner.Then("matrix \"result\" should be byte matrix \"[[108, 105, 110, 101, 32, 49, 13, 10] [108" +
                    ", 105, 110, 101, 32, 50]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read a non-existent file as an stream of chars")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReactiveFileUtils")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReadANon_ExistentFileAsAnStreamOfChars()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read a non-existent file as an stream of chars", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 33
   testRunner.Given("a name of a temporary file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
    testRunner.When("the ReadObservableChars method is called with the filename", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
    testRunner.Then("an exception should have been thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Read a non-existent file as an stream of strings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReactiveFileUtils")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReadANon_ExistentFileAsAnStreamOfStrings()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read a non-existent file as an stream of strings", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 38
   testRunner.Given("a name of a temporary file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
    testRunner.When("the ReadObservableStrings method is called with the filename", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
    testRunner.Then("an exception should have been thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
