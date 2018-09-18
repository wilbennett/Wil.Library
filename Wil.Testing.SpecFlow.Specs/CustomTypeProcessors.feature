@dynamicGivenBindings
@dynamicThenBindings
@customType
Feature: Custom Type Processors
    In order to effectively use generated bindings
    As a user
    I want to be able to use custom type processors

Scenario: Custom type
    Given actual as person "(John:Doe)"
    Given "(John:Doe)"
    Given expected is: (John:Doe)
    Given "(Jane:Doe)" as other
    Then actual should be expected
    Then actual should not be other
    Then the result should be expected
    Then result should not be other

Scenario: Custom collection with custom type
    Given actual as CustomList of person "(John:Doe), (Baby:Doe), (Brother:Doe)"
    Given a CustomList of person "(John:Doe), (Baby:Doe), (Brother:Doe)"
    Given expected is CustomList of: (John:Doe), (Baby:Doe), (Brother:Doe)
    Given an enumerable of "(Jane:Doe), (Stepma:Doe)" as other
    Then actual should be expected
    Then actual should not be other
    Then actual should contain CustomList of "(Brother:Doe)", "(Baby:Doe)"
    Then the result should be expected
    Then the result should not be other
    Then result should contain CustomList of "(Brother:Doe)", "(Baby:Doe)"
