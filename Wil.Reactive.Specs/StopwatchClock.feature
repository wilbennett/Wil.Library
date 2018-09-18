Feature: StopwatchClock
	In order to work with date and time values efficiently
	As a user
	I want to be able to delay the overhead of DateTime structure until absolutely necessary

Background:
	Given an instance of the StopwatchClock class

Scenario: Get the current date and time
	When the property values are retrieved
	Then the Now value should be within one second of DateTime.Now

Scenario: Validate the CalculateElapsed method
	When the property values are retrieved
	Then the Elapsed value should be within one second of the result of the CalculateElapsed method

Scenario: Validate the ToDateTime method
	When the property values are retrieved
	Then the Now value should be within one second of the result of the ToDateTime method
