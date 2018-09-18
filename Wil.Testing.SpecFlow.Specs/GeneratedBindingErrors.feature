@dynamicBindings
@captureBindingError
Feature: Generated Binding Errors
    In order to avoid silly mistakes
    As a user
    I want to get errors for incorrect generated bindings

#@ignore
Scenario: Parse empty string
    Given int "" as value
    Then bindingException__ should exist

#@ignore
Scenario: Invalid type
    Given invalid as UnknownType 10
    Then bindingException__ should exist

#@ignore
Scenario: Invalid collection element type
    Given invalid as enumerable of UnknownType 1, 2, 3
    Then bindingException__ should exist

#@ignore
Scenario: Invalid collection kind
    Given invalid as UnknownCollection of 1, 2, 3
    Then bindingException__ should exist

#@ignore
Scenario: Invalid compare type
    Given actual as 1
    Then actual should be int 1
    Then bindingException__ should not exist
    Then actual should be UnknownType 1
    Then bindingException__ should exist

#@ignore
Scenario: Invalid compare collection element type
    Given actual as 1
    Then actual should be enumerable of UnknownType 1, 2, 3
    Then bindingException__ should exist

#@ignore
Scenario: Invalid type compare operation
    Given actual as 10
    Then actual should contain 1
    Then bindingException__ should exist

#@ignore
Scenario: Invalid collection compare operation
    Given actual as 1, 2, 3
    Then actual should be 1, 2, 3
    Then bindingException__ should not exist
    Then actual should be greater than 1, 2, 3
    Then bindingException__ should exist

#@ignore
Scenario: Mismatched collection element
    Given elementProcessor is an IntProcessor
    When an integer ListProcessor is created with processor elementProcessor
    Then exception should not exist
    Given elementProcessor is a null IntProcessor
    When an integer ListProcessor is created with processor elementProcessor
    Then exception should exist

#@ignore
Scenario: Compare collection to type
    Given elementProcessor is an IntProcessor
    And first is a CustomListProcessor with elementProcessor
    And second is a CustomListProcessor with elementProcessor
    When first.CompareTo is called with second
    Then exception should not exist
    When first.CompareTo is called with elementProcessor
    Then exception should exist

#@ignore
Scenario: Compare operation not implemented
    Given 1
    Then the result should invalidop 10
