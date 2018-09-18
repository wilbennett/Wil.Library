@dynamicBindings
Feature: Private Contracts
	In order to reduce coding errors
	As a user
	I want to be able to specify runtime contracts on private methods

Scenario: Not null preconditions on private methods
	Given a private method with a not null precondition
	When the method is called
	Then the method should have failed if enabled

Scenario: True precondition with custom message and exception on private methods
	Given message is "Test custom message"
	And a private method with a true precondition, custom message and ArgumentException
	When the method is called
	Then the method should have failed if enabled
	And the type of the exception should be ArgumentException if enabled
	And the exceptionMessage should be "Test custom message" if enabled

Scenario: True precondition with custom exception on private methods
	Given a private method with a true precondition using ArgumentException
	When the method is called
	Then the method should have failed if enabled
	And the type of the exception should be ArgumentException if enabled

Scenario: True precondition with custom message on private methods
	Given message is "Test custom message"
	And a private method with a true precondition and custom message
	When the method is called
	Then the method should have failed if enabled
	And the exceptionMessage should be "Test custom message" if enabled

Scenario: True precondition on private methods
	Given a private method with a true precondition
	When the method is called
	Then the method should have failed if enabled
