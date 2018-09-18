# Wil.Library

Sample for DevChatter Twitch stream demonstrating dynamic SpecFlow tests.

## Goal

SpecFlow allows writing readable tests that allow easy reuse of test steps.  This is accomplished by writing a feature file
that describes the tests and a "code behind" C# file that implements each step.  While this setup is easy to work with, it is
a little annoying that you have to write C# code for simple steps.  The goal of the library is to minimize the amount of C#
code that is needed.  The idea, at a high level, is to write the test steps in the feature file and have the C# code
"dynamically generated".  The actual implementation doesn't actually generate code - it parses the steps and carries out the
appropriate actions.

## Usage

Given a class such as:
```csharp
public static class MyMath
{
    public static int Add(int x, int y) => x + y;
}
```

You may create a feature file such as the following:

```
Feature: Math
    In order to create great applications
    As a developer
    I want to be able to perform mathematical operations in code

Scenario: Add two positive integers
  Given firstNumber is 1
    And secondNumber is 2
   When Add is called
   Then the add result should be 3

```
You would also have the following code behind file:

```csharp
[Binding]
public class MathSteps
{
    public MathSteps(ScenarioContext scenarioContext) => _scenario = scenarioContext;

    [Given(@"firstNumber is (.*)")]
    public void GivenFirstNumberIs(int number) => _scenario.Set(number, "firstNumber");

    [Given(@"secondNumber is (.*)")]
    public void GivenSecondNumberIs(int number) => _scenario.Set(number, "secondNumber");

    [When(@"Add is called")]
    public void WhenAddIsCalled()
    {
        int firstNumber = _scenario.Get<int>("firstNumber");
        int secondNumber = _scenario.Get<int>("secondNumber");
        int result = MyMath.Add(firstNumber, secondNumber);
        _scenario.Set(result, "addResult");
    }
        
    [Then(@"the add result should be (.*)")]
    public void ThenTheAddResultShouldBe(int expected)
    {
        int addResult = _scenario.Get<int>("addResult");
        Assert.AreEqual(expected, addResult);
    }

    private readonly ScenarioContext _scenario;
}

```

As you can see, there is a lot of mundane C# code to implement each test step.  Refactoring to use dynamic bindings, results in
only the following feature file!:

```
@dynamicBindings
Feature: Math
    In order to create great applications
    As a developer
    I want to be able to perform mathematical operations in code

Scenario: Add two positive integers
  Given firstNumber is 1
    And secondNumber is 2
   When MyMath.Add(firstNumber, secondNumber) is called
   Then the result should be 3
```

Note the ```@dynamicBindings``` tag on the feature.  This is how you specify that the engine should generate bindings for test steps
that match a predetermined convention.  As you can see from the above, the convention is natural and intuitive.  ```firstNumber is 1```
matches the convention ```[the ]variableName [is |as ]value```.  ```MyMath.Add(firstNumber, secondNumber) is called``` matches the
convention ```(instance|className).MethodName(arguments) is called```.  You can see the different supported conventions by examining
the unit tests in the [Wil.Test.SpecFlow.Specs](https://github.com/wilbennett/Wil.Library/tree/master/Wil.Testing.SpecFlow.Specs "Wil.Test.SpecFlow.Specs") test project.

#### Conflict Resolution

There may be times where you don't want generated bindings for certain steps or you want to override the binding for specific steps.
There are two ways to accomplish this.  In the above example, the ```@dynamicBindings``` tag was placed at the feature level.  You may
instead, place it at the scenario level.  This allows having some scenarios with dynamic steps and others with manual steps.  You
may, however, want to go even more granual.  The ```@dynamicBindings``` tag allows generating all types of steps.  There are alternate
tags you can use to limit generation.  The tags are ```@dynamicConstructorBindings```, ```@dynamicPropertyBindings```,
```@dynamicMethodBindings```, ```@dynamicGivenBindings``` and ```@dynamicThenBindings```.  You can use these tags to generate only the
respective bindings.

You may also need to only override a specific step and use dynamic bindings for others.  You can achieve this by prefixing the step
with ```_```.  For example, if you wanted to override the step ```Given firstNumber is 1```, you would write it as
```Given _firstNumber is 1```.  You would then write the C# binding as ```[Given(@"_firstNumber is (.*)")]```

## Understanding The Code

This is a work in progress so there are undoubtably some gaps in the implementation. The Wil.Testing.* projects contain the most up to date code and the Wil.Testing.SpecFlow.Specs project contains the latest supported constructs.

#### Project Structure

- **Wil.Testing** - Basic testing support (IAssert, ICollectionAssert)
- **Wil.Testing.MsTest** - Support for MsTest (Adapt to IAssert, ICollectionAssert)
- **Wil.Testing.MsTest.SpecFlowPlugin** - Configures a SpecFlow project to use MsTest and dynamic bindings
- **Wil.Testing.Specflow** - Extensions to SpecFlow to support type processors
- **Wil.Testing.SpecFlow.Bindings** - Support for dynamic SpecFlow bindings

#### Build Configuration

The solution is designed to auto update the version number on build and to publish local
nuget packages.  Visual Studio no longer has support for auto incrementing version numbers (at least for nuget packages) so the version number updating is accomplished in .props and .target files.  The implementation is to create the version number with the minor version based on the build date and time.  When building in Visual Studio, the same minor version will be applied to projects built within 30 seconds (configurable) of each other.  The CI build (not included here - this is a scaled down version of a VSTS solution) assigns the same version to all projects during a build.

The publishing of local nuget packages is also controlled through .props and .targets files.  There is a config folder that contains setup files based on whether the branch is the master or a dev branch.  The goMaster and goDev powershell scripts changes the branch locally and copies the appropriate configs, allowing configuration of where the packages are published to.  This facilitates switching between branches while allowing other applications to use the packages without side effects.

#### Implementation

The overall goal is to take a test step and process it as either reading a value, setting a value or comparing values.  In order to perform the appropriate operations, the step needs to be parsed to determine variable names, types, values and compare operations.

At the most basic, the algorithm is to set values in the scenario context, retrieve values from the scenario context and compare values retrieved from the scenario context.  This is achieved by using the interfaces ITypeProcessor, ICollectionProcessor and IValueProcessor.  Type processors are responsible for converting a string to a specific type and storing/retrieving that type from the scenario context.  This allows the system to be extended since you can add your own implementation to support your custom types.  An example of this can be seen with the Person class, PersonProcessor class and the associated tests.  Base classes have been created to make the creation of processors as painless as possible.  You can see this by examining the provided processors.  Most are implemented by providing constructor arguments and overriding one or two methods.

#### Notes

SpecFlow uses regular expressions to match steps to bindings.  Unfortunately, due to the implementation of the feature file highlighter, the regular expressions cannot be assigned to constants and therefore must be repeated.  As you will see in the code, this means a lot of the binding regular expressions are repeated - which means maintenance is more difficult than need be.  Attempts have been made to reduce the number of regular expressions used but as stated above, this is a work in progress and this code has not been optimized.  One good thing is the matching of steps to bindings is done at design time so it won't affect the test execution runtime.

The Generated[type]Bindings feature files all basically contain the same tests with the difference being the type being used so you only really need to understand one of these files.

