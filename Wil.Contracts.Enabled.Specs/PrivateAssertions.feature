@debug
@dynamicBindings
Feature: Private Assertions
	In order to reduce coding errors
	As a user
	I want to be able to specify runtime assertions on private methods

Scenario: Not null assertion with custom message on private methods
	Given message is "Test custom message"
	And a private method with a not null assertion check and custom message
	When the method is called
	Then the method should have asserted
	And the assertion message should be "Test custom message"

Scenario: Not null assertion on private methods
	Given a private method with a not null assertion check
	When the method is called
	Then the method should have asserted

Scenario: Assertions with custom message on private methods
	Given message is "Test custom message"
	And a private method with an assertion check and custom message
	When the method is called
	Then the method should have asserted
	And the assertion message should be "Test custom message"

Scenario: Assertions on private methods
	Given a private method with an assertion check
	When the method is called
	Then the method should have asserted
