@dynamicBindings
Feature: ObservableExErrors
	In order to work effectively with observable streams
	As a user
	I want to be able to suppress stream errors

Scenario: Unhandled subscriber errors
	Given an observable that publishes integers
	And _a normal subscriber
	And a subscriber that throws an exception when 2 is received
	When the observable publishes values 1 to 3
	Then the normalResult should be list of ints 1, 2
	And the errorResult should be list of ints "1"
	And subscriberException should exist

Scenario: Suppressed subscriber errors
	Given an observable that publishes integers
	And _a subscriber error handler
	And SuppressSubscriberErrors is chained to the observable
	And _a normal subscriber
	And a subscriber that throws an exception when 2 is received
	When the observable publishes values 1 to 3
	Then the normalResult should be list of ints 1, 2, 3
	And the errorResult should be list of ints "1"
	And subscriberException should not exist
	And subscriberHandledException should exist

Scenario: Handle publisher errors
	Given an observable that publishes integers
	And _a subscriber error handler
	And _a publisher error handler
	And SuppressErrors is chained to the observable
	And _a normal subscriber
	And a subscriber that throws an exception when 2 is received
	When the observable publishes values 1, 2, 3, error
	Then the normalResult should be list of ints 1, 2, 3
	And publisherHandledException should exist
	And subscriberHandledException should exist

