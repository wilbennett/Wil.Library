@dynamicPropertyBindings
@dynamicConstructorBindings
@dynamicGivenBindings
@dynamicThenBindings
Feature: Dynamic Property Bindings
	In order to quickly create SpecFlow unit tests
	As a user
	I want use dynamic bindings

@captureBindingError
Scenario: Invalid property get
  Given instance as a new Person
  When the instance.Nickname is retrieved
  Then bindingException__ should not exist
  When instance.Invalid is retrieved
  Then bindingException__ should exist

@captureBindingError
Scenario: Invalid property set
  Given instance as a new Person
  And nickname as "The Beast"
  When the instance.Nickname is set to nickname
  Then bindingException__ should not exist
  When instance.Invalid is set to nickname
  Then bindingException__ should exist

@captureBindingError
Scenario: Invalid property set invalid property
  Given instance1 as a new Person
  And instance2 as a new Person
  And nickname as "The Beast"
  When the instance1.Nickname is set to nickname
  And the instance2.Nickname is set to nickname
  Then instance1.Nickname should be equal to instance2.Nickname
  And bindingException__ should not exist
  And instance1.Invalid should be equal to instance2.Invalid
  And bindingException__ should exist

@captureBindingError
Scenario: Invalid property set value
  Given instance as a new Person
  When the instance.Nickname is set to "Beast"
  Then bindingException__ should not exist
  When instance.Unregistered is set to "Beast"
  Then bindingException__ should exist

@captureBindingError
Scenario: Invalid property test
  Given instance as a new Person
  And nickname is "Beast"
  When the instance.Nickname is set to nickname
  Then the instance.Nickname should be nickname
  And bindingException__ should not exist
  When instance.Unregistered is set to "Beast"
  Then bindingException__ should exist

@captureBindingError
Scenario: Property test invalid value key
  Given instance as a new Person
  And nickname is "Beast"
  When instance.Nickname is set to nickname
  Then the instance.Nickname should be nickname
  And bindingException__ should not exist
  Then the instance.Nickname should be invalid
  Then bindingException__ should exist

@captureBindingError
Scenario: Property test invalid value
  Given instance as a new Person
  When the instance.Age is set to "10"
  Then the instance.Age should be "10"
  And bindingException__ should not exist
  Then the instance.Age should be "invalid"
  Then bindingException__ should exist

Scenario: Retrieve property
  Given firstName is "John"
  And lastName as "Doe"
  And instance is a Person created with firstName, lastName
  And person is a Person created with "John", "Doe"
  When instance.FirstName is retrieved
  Then the result should be firstName
  And instance.FullName should be person.FullName
  Given personLast is instance.LastName
  Then personLast should be lastName

Scenario: Set property
  Given firstName is "John"
  And lastName as "Doe"
  And nickname as "The Beast"
  And instance is a new Person(firstName, lastName)
  And person is a new Person("John", "Doe")
  And the instance.Nickname is set to nickname
  And the instance.Age is "10"
  And instanceNickname as instance.Nickname
  Then instanceNickname should be nickname
  And instanceNickname should be instance.Nickname
  And instance.Nickname should be nickname
  And instance.FullName should be person.FullName
  And instance.Age should be "10"
  When instance.Nickname is set to "Steel"
  And instance.Nickname is read
  Then the result should be "Steel"
  And the result should be instance.Nickname
  Given nickname as "Dragon"
  When instance.Nickname is set to nickname
  Then the instance.Nickname should not be null
  And the instance.Nickname should be "Dragon"
  Given instance.Nickname is set to "Tiger"
  Then instance.Nickname should be "Tiger"
