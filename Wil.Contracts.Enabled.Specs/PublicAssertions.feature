@debug
@dynamicBindings
Feature: Public Assertions
	In order to reduce coding errors
	As a user
	I want to be able to specify runtime assertions on public methods

Scenario: Not null assertion with custom message on public methods
	Given message is "Test custom message"
	And a public method with a not null assertion check and custom message
	When the method is called
	Then the method should have asserted
	And the assertion message should be "Test custom message"

Scenario: Not null assertion on public methods
	Given a public method with a not null assertion check
	When the method is called
	Then the method should have asserted

Scenario: Assertions with custom message on public methods
	Given message is "Test custom message"
	And a public method with an assertion check and custom message
	When the method is called
	Then the method should have asserted
	And the assertion message should be "Test custom message"

Scenario: Assertions on public methods
	Given a public method with an assertion check
	When the method is called
	Then the method should have asserted
