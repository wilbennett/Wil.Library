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
namespace Wil.Reactive.Specs.ObservableExTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ObservableExBooleanFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ObservableExBoolean.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ObservableExBoolean", "\tIn order to effectively work with observable boolean streams\r\n\tAs a user\r\n\tI wan" +
                    "t to be able to apply logic operations on one or more streams", ProgrammingLanguage.CSharp, new string[] {
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ObservableExBoolean")))
            {
                global::Wil.Reactive.Specs.ObservableExTests.ObservableExBooleanFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Inverse a stream")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void InverseAStream()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Inverse a stream", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
  testRunner.Given("1 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
  testRunner.And("Inverse is chained to the observable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
  testRunner.Then("the result should be list of bools \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
  testRunner.Then("the result should be list of bools \"false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reference counted boolean observable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReferenceCountedBooleanObservable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reference counted boolean observable", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
  testRunner.And("ReferenceCounted is chained to the observable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.Then("the result should be list of bools \"true, false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
  testRunner.Then("the result should be list of bools \"true, false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
  testRunner.Then("the result should be list of bools \"true, false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
  testRunner.Then("the result should be list of bools \"true, false, true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reference counted boolean observable unbalanced")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReferenceCountedBooleanObservableUnbalanced()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reference counted boolean observable unbalanced", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
  testRunner.And("ReferenceCounted is chained to the observable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
  testRunner.And("subscriberException should exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Reference counted boolean observable completed unbalanced")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void ReferenceCountedBooleanObservableCompletedUnbalanced()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reference counted boolean observable completed unbalanced", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
  testRunner.And("ReferenceCounted is chained to the observable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
  testRunner.When("observable 0 is completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
  testRunner.Then("subscriberException should exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean And with two observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanAndWithTwoObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean And with two observables", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
  testRunner.And("the two observables are combined with \"And\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean Or with two observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanOrWithTwoObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean Or with two observables", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
  testRunner.And("the two observables are combined with \"Or\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean Xor with two observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanXorWithTwoObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean Xor with two observables", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
  testRunner.And("the two observables are combined with \"Xor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
  testRunner.Then("the result should be list of bools \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
  testRunner.Then("the result should be list of bools \"false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
  testRunner.Then("the result should be list of bools \"false, true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean AndNot with two observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanAndNotWithTwoObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean AndNot with two observables", ((string[])(null)));
#line 93
this.ScenarioSetup(scenarioInfo);
#line 94
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
  testRunner.And("the two observables are combined with \"AndNot\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
  testRunner.Then("the result should be list of bools \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
  testRunner.Then("the result should be list of bools \"false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
  testRunner.Then("the result should be list of bools \"false, true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean OrNot with two observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanOrNotWithTwoObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean OrNot with two observables", ((string[])(null)));
#line 106
this.ScenarioSetup(scenarioInfo);
#line 107
  testRunner.Given("2 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 108
  testRunner.And("the two observables are combined with \"OrNot\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
  testRunner.Then("the result should be list of bools \"true, false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean And with three observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanAndWithThreeObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean And with three observables", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
  testRunner.Given("3 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
  testRunner.And("the observables are combined with \"And\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
  testRunner.When("observable 2 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean Or with three observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanOrWithThreeObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean Or with three observables", ((string[])(null)));
#line 132
this.ScenarioSetup(scenarioInfo);
#line 133
  testRunner.Given("3 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 134
  testRunner.And("the observables are combined with \"Or\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 137
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
  testRunner.When("observable 2 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
  testRunner.When("observable 2 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 146
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 147
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean Xor with three observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanXorWithThreeObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean Xor with three observables", ((string[])(null)));
#line 149
this.ScenarioSetup(scenarioInfo);
#line 150
  testRunner.Given("3 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 151
  testRunner.And("the observables are combined with \"Xor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
  testRunner.When("observable 2 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 159
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 160
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
  testRunner.When("observable 2 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 162
  testRunner.Then("the result should be list of bools \"true, false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 164
  testRunner.Then("the result should be list of bools \"true, false, true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean AndNot with three observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanAndNotWithThreeObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean AndNot with three observables", ((string[])(null)));
#line 166
this.ScenarioSetup(scenarioInfo);
#line 167
  testRunner.Given("3 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 168
  testRunner.And("the observables are combined with \"AndNot\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 171
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 172
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 173
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 174
  testRunner.When("observable 2 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
  testRunner.Then("the result should be list of bools \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
  testRunner.When("observable 1 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
  testRunner.Then("the result should be list of bools \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 178
  testRunner.When("observable 2 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 179
  testRunner.Then("the result should be list of bools \"false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Boolean OrNot with three observables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ObservableExBoolean")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("dynamicBindings")]
        public virtual void BooleanOrNotWithThreeObservables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Boolean OrNot with three observables", ((string[])(null)));
#line 181
this.ScenarioSetup(scenarioInfo);
#line 182
  testRunner.Given("3 observables that publish boolean values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 183
  testRunner.And("the observables are combined with \"OrNot\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 184
  testRunner.And("_a boolean subscriber", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 185
  testRunner.When("observable 0 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 186
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 187
  testRunner.When("observable 1 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 188
  testRunner.Then("the result should be list of bools \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 189
  testRunner.When("observable 2 publishes true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 190
  testRunner.Then("the result should be list of bools \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 191
  testRunner.When("observable 0 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 192
  testRunner.Then("the result should be list of bools \"true, false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 193
  testRunner.When("observable 2 publishes false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 194
  testRunner.Then("the result should be list of bools \"true, false, true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion