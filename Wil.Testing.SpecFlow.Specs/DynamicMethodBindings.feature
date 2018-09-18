@dynamicMethodBindings
@dynamicConstructorBindings
@dynamicPropertyBindings
@dynamicGivenBindings
@dynamicThenBindings
Feature: Dynamic method Bindings
	In order to quickly create SpecFlow unit tests
	As a user
	I want use dynamic bindings

@captureBindingError
Scenario: Invalid type
  When Person.CreateNew("John", "Doe") is called
  Then bindingException__ should not exist
  When Invalid.CreateNew("John", "Doe") is called
  Then bindingException__ should exist

@captureBindingError
Scenario: Invalid method
  Given instance as a new Person
  And instance as a new Person
  And instance.ToString() is called
  Then bindingException__ should not exist
  Given instance.Invalid() is called
  Then bindingException__ should exist

@captureBindingError
Scenario: Invalid method values
  Given instance as a new Person
  When instance.FormatWithId("7") is called
  Then bindingException__ should not exist
  When instance.FormatWithId("7", "invalid") is called
  Then bindingException__ should exist

Scenario: Method without parameters
  Given firstName is "John"
  And lastName as "Doe"
  And instance is a Person created with firstName, lastName
  When name is the result of calling instance.ToString()
  And instance.ToString() is called
  Then the instance.FullName should be name
  And the result should be name
  Given firstName is "Mary"
  And instance is a Person created with firstName, lastName
  When instance.ToString() is called
  Then the result should be "Mary Doe"

Scenario: Method with parameters
  Given firstName is "John"
  And lastName as "Doe"
  And nickname is "Beast"
  And instance is a Person created with firstName, lastName
  And id as 5
  When name is the result of instance.FormatWithId(id)
  And withNickname is the result of instance.FormatWithIdAndNickname(id, nickname)
  And instance.FormatWithId(id) is called
  Then name should be "John Doe (5)"
  And withNickname should be "5: John Doe (Beast)"
  And the result should be "John Doe (5)"

Scenario: Method with parameters values
  Given firstName is "John"
  And lastName as "Doe"
  And instance is a Person created with firstName, lastName
  When name is the result of instance.FormatWithId("5")
  And withNickname is the result of instance.FormatWithIdAndNickname("5", "Beast")
  And instance.FormatWithId("5") is called
  Then name should be "John Doe (5)"
  And withNickname should be "5: John Doe (Beast)"
  And the result should be "John Doe (5)"

Scenario: Static method
  Given instance as a new Person
  Given firstName is "John"
  And lastName as "Doe"
  When person is the result of instance.CreateNew(firstName, lastName)
  Then person.FullName should be "John Doe"
  Given firstName is "Jane"
  When person is the result of Person.CreateNew(firstName, lastName)
  Then the person.FullName should be "Jane Doe"
