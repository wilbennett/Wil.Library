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
    public partial class DynamicConstructorBindingsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DynamicConstructorBindings.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Dynamic Constructor Bindings", "\tIn order to quickly create SpecFlow unit tests\r\n\tAs a user\r\n\tI want use dynamic " +
                    "bindings", ProgrammingLanguage.CSharp, new string[] {
                        "dynamicConstructorBindings",
                        "dynamicPropertyBindings",
                        "dynamicGivenBindings",
                        "dynamicThenBindings"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Dynamic Constructor Bindings")))
            {
                global::Wil.Testing.SpecFlow.Specs.DynamicConstructorBindingsFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Invalid type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dynamic Constructor Bindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicConstructorBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicPropertyBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicGivenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicThenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("captureBindingError")]
        public virtual void InvalidType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid type", new string[] {
                        "captureBindingError"});
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
  testRunner.Given("instance as a new Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
  testRunner.Then("bindingException__ should not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
  testRunner.Given("instance as a new Wil.Testing.SpecFlow.Specs.Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
  testRunner.Then("bindingException__ should not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
  testRunner.Given("instance as a new InvalidType", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
  testRunner.Then("bindingException__ should exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Invalid parameter count")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dynamic Constructor Bindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicConstructorBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicPropertyBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicGivenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicThenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("captureBindingError")]
        public virtual void InvalidParameterCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid parameter count", new string[] {
                        "captureBindingError"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
  testRunner.Given("instance as a Person created with \"John\", \"Doe\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
  testRunner.Then("bindingException__ should not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
  testRunner.Given("instance as a Person created with \"John\", \"Doe\", \"D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
  testRunner.Then("bindingException__ should exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Constructor without parameters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dynamic Constructor Bindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicConstructorBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicPropertyBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicGivenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicThenBindings")]
        public virtual void ConstructorWithoutParameters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Constructor without parameters", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
  testRunner.Given("instance as a new Person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
  testRunner.Then("instance should not be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Constructor with parameters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dynamic Constructor Bindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicConstructorBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicPropertyBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicGivenBindings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicThenBindings")]
        public virtual void ConstructorWithParameters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Constructor with parameters", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
  testRunner.Given("firstName is \"John\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
  testRunner.And("lastName as \"Doe\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
  testRunner.And("instance is a Person created with firstName, lastName", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
  testRunner.And("person is a Person created with \"John\", \"Doe\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.And("person2 is a Person created with \'John\', \'Doe\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And("person3 is a new Person(firstName, lastName)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
  testRunner.And("person4 is a new Person(\"John\", \"Doe\")", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
  testRunner.And("person5 is a new Person(\'John\', \'Doe\')", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
  testRunner.And("person6 is a Person created with \"Beast, The\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("person7 is a Person created with \'Beast, The\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
  testRunner.And("person8 is a new Person(\"Beast, The\")", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
  testRunner.And("person9 is a new Person(\'Beast, The\')", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
  testRunner.Then("instance should not be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
  testRunner.And("person should not be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
  testRunner.And("person2 should not be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
  testRunner.And("person3 should not be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
  testRunner.And("person4 should not be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
  testRunner.And("person5 should not be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
  testRunner.And("person6.Nickname should be \"Beast, The\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
  testRunner.And("person7.Nickname should be \"Beast, The\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
  testRunner.And("person8.Nickname should be \"Beast, The\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And("person9.Nickname should be \"Beast, The\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
