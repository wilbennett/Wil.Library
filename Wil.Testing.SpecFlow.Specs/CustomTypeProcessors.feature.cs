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
namespace Wil.Testing.SpecFlow.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CustomTypeProcessorsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CustomTypeProcessors.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Custom Type Processors", "    In order to effectively use generated bindings\r\n    As a user\r\n    I want to " +
                    "be able to use custom type processors", ProgrammingLanguage.CSharp, new string[] {
                        "dynamicGivenBindings",
                        "dynamicThenBindings",
                        "customType"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Custom Type Processors")))
            {
                global::Wil.Testing.SpecFlow.Specs.CustomTypeProcessorsFeature.FeatureSetup(null);
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Custom type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Custom Type Processors")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicGivenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicThenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("customType")]
        public virtual void CustomType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Custom type", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
    testRunner.Given("actual as person \"(John:Doe)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
    testRunner.Given("\"(John:Doe)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
    testRunner.Given("expected is: (John:Doe)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
    testRunner.Given("\"(Jane:Doe)\" as other", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
    testRunner.Then("actual should be expected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
    testRunner.Then("actual should not be other", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
    testRunner.Then("the result should be expected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
    testRunner.Then("result should not be other", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Custom collection with custom type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Custom Type Processors")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicGivenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicThenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("customType")]
        public virtual void CustomCollectionWithCustomType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Custom collection with custom type", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
    testRunner.Given("actual as CustomList of person \"(John:Doe), (Baby:Doe), (Brother:Doe)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
    testRunner.Given("a CustomList of person \"(John:Doe), (Baby:Doe), (Brother:Doe)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
    testRunner.Given("expected is CustomList of: (John:Doe), (Baby:Doe), (Brother:Doe)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.Given("an enumerable of \"(Jane:Doe), (Stepma:Doe)\" as other", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
    testRunner.Then("actual should be expected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
    testRunner.Then("actual should not be other", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
    testRunner.Then("actual should contain CustomList of \"(Brother:Doe)\", \"(Baby:Doe)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
    testRunner.Then("the result should be expected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
    testRunner.Then("the result should not be other", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
    testRunner.Then("result should contain CustomList of \"(Brother:Doe)\", \"(Baby:Doe)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion