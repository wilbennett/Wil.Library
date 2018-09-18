@dynamicBindings
Feature: ObservableExBoolean
	In order to effectively work with observable boolean streams
	As a user
	I want to be able to apply logic operations on one or more streams

Scenario: Inverse a stream
  Given 1 observables that publish boolean values
  And Inverse is chained to the observable
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools "false"
  When observable 0 publishes false
  Then the result should be list of bools "false, true"

Scenario: Reference counted boolean observable
  Given 2 observables that publish boolean values
  And ReferenceCounted is chained to the observable
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools "true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false"
  When observable 0 publishes true
  Then the result should be list of bools "true, false, true"
  When observable 0 publishes true
  Then the result should be list of bools "true, false, true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false, true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false, true, false"

Scenario: Reference counted boolean observable unbalanced
  Given 2 observables that publish boolean values
  And ReferenceCounted is chained to the observable
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools "true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false"
  When observable 0 publishes false
  Then the result should be list of bools "true, false"
  And subscriberException should exist

Scenario: Reference counted boolean observable completed unbalanced
  Given 2 observables that publish boolean values
  And ReferenceCounted is chained to the observable
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools "true"
  When observable 0 is completed
  Then subscriberException should exist

Scenario: Boolean And with two observables
  Given 2 observables that publish boolean values
  And the two observables are combined with "And"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools "true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false"
  When observable 1 publishes false
  Then the result should be list of bools "true, false"

Scenario: Boolean Or with two observables
  Given 2 observables that publish boolean values
  And the two observables are combined with "Or"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools "true"
  When observable 0 publishes false
  Then the result should be list of bools "true"
  When observable 1 publishes false
  Then the result should be list of bools "true, false"

Scenario: Boolean Xor with two observables
  Given 2 observables that publish boolean values
  And the two observables are combined with "Xor"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools "false"
  When observable 0 publishes false
  Then the result should be list of bools "false, true"
  When observable 1 publishes false
  Then the result should be list of bools "false, true, false"

Scenario: Boolean AndNot with two observables
  Given 2 observables that publish boolean values
  And the two observables are combined with "AndNot"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools "false"
  When observable 1 publishes false
  Then the result should be list of bools "false, true"
  When observable 0 publishes false
  Then the result should be list of bools "false, true, false"

Scenario: Boolean OrNot with two observables
  Given 2 observables that publish boolean values
  And the two observables are combined with "OrNot"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools "true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false"
  When observable 1 publishes false
  Then the result should be list of bools "true, false, true"

Scenario: Boolean And with three observables
  Given 3 observables that publish boolean values
  And the observables are combined with "And"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools ""
  When observable 2 publishes true
  Then the result should be list of bools "true"
  When observable 1 publishes false
  Then the result should be list of bools "true, false"

Scenario: Boolean Or with three observables
  Given 3 observables that publish boolean values
  And the observables are combined with "Or"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools ""
  When observable 2 publishes true
  Then the result should be list of bools "true"
  When observable 1 publishes false
  Then the result should be list of bools "true"
  When observable 2 publishes false
  Then the result should be list of bools "true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false"

Scenario: Boolean Xor with three observables
  Given 3 observables that publish boolean values
  And the observables are combined with "Xor"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools ""
  When observable 2 publishes true
  Then the result should be list of bools "true"
  When observable 1 publishes false
  Then the result should be list of bools "true, false"
  When observable 2 publishes false
  Then the result should be list of bools "true, false, true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false, true, false"

Scenario: Boolean AndNot with three observables
  Given 3 observables that publish boolean values
  And the observables are combined with "AndNot"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools ""
  When observable 2 publishes true
  Then the result should be list of bools "false"
  When observable 1 publishes false
  Then the result should be list of bools "false"
  When observable 2 publishes false
  Then the result should be list of bools "false, true"

Scenario: Boolean OrNot with three observables
  Given 3 observables that publish boolean values
  And the observables are combined with "OrNot"
  And _a boolean subscriber
  When observable 0 publishes true
  Then the result should be list of bools ""
  When observable 1 publishes true
  Then the result should be list of bools ""
  When observable 2 publishes true
  Then the result should be list of bools "true"
  When observable 0 publishes false
  Then the result should be list of bools "true, false"
  When observable 2 publishes false
  Then the result should be list of bools "true, false, true"
