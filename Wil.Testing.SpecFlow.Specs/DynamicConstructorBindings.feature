@dynamicConstructorBindings
@dynamicPropertyBindings
@dynamicGivenBindings
@dynamicThenBindings
Feature: Dynamic Constructor Bindings
	In order to quickly create SpecFlow unit tests
	As a user
	I want use dynamic bindings

@captureBindingError
Scenario: Invalid type
  Given instance as a new Person
  Then bindingException__ should not exist
  Given instance as a new Wil.Testing.SpecFlow.Specs.Person
  Then bindingException__ should not exist
  Given instance as a new InvalidType
  Then bindingException__ should exist

@captureBindingError
Scenario: Invalid parameter count
  Given instance as a Person created with "John", "Doe"
  Then bindingException__ should not exist
  Given instance as a Person created with "John", "Doe", "D"
  Then bindingException__ should exist

Scenario: Constructor without parameters
  Given instance as a new Person
  Then instance should not be null

Scenario: Constructor with parameters
  Given firstName is "John"
  And lastName as "Doe"
  And instance is a Person created with firstName, lastName
  And person is a Person created with "John", "Doe"
  And person2 is a Person created with 'John', 'Doe'
  And person3 is a new Person(firstName, lastName)
  And person4 is a new Person("John", "Doe")
  And person5 is a new Person('John', 'Doe')
  And person6 is a Person created with "Beast, The"
  And person7 is a Person created with 'Beast, The'
  And person8 is a new Person("Beast, The")
  And person9 is a new Person('Beast, The')
  Then instance should not be null
  And person should not be null
  And person2 should not be null
  And person3 should not be null
  And person4 should not be null
  And person5 should not be null
  And person6.Nickname should be "Beast, The"
  And person7.Nickname should be "Beast, The"
  And person8.Nickname should be "Beast, The"
  And person9.Nickname should be "Beast, The"
