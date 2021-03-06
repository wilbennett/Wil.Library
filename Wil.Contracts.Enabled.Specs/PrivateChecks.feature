﻿@dynamicBindings
Feature: Private Checks
	In order to reduce coding errors
	As a user
	I want to be able to specify runtime code checks on private methods

Scenario: True check with custom message and exception on private methods
	Given message is "Test custom message"
	And a private method with a true check, custom message and ArgumentException
	When the method is called
	Then the method should have failed if enabled
	And the type of the exception should be ArgumentException if enabled
	And the exceptionMessage should be "Test custom message" if enabled

Scenario: True check with custom exception on private methods
	Given a private method with a true check using ArgumentException
	When the method is called
	Then the method should have failed if enabled
	And the type of the exception should be ArgumentException if enabled

Scenario: True check with custom message on private methods
	Given message is "Test custom message"
	And a private method with a true check and custom message
	When the method is called
	Then the method should have failed if enabled
	And the exceptionMessage should be "Test custom message" if enabled

Scenario: True check on private methods
	Given a private method with a true check
	When the method is called
	Then the method should have failed if enabled

Scenario: Not null check with custom message and exception on private methods
	Given message is "Test custom message"
	And a private method with a not null check, custom message and ArgumentException
	When the method is called
	Then the method should have failed if enabled
	And the type of the exception should be ArgumentException if enabled
	And the exceptionMessage should be "Test custom message" if enabled

Scenario: Not null check with custom exception on private methods
	Given a private method with a not null check using ArgumentException
	When the method is called
	Then the method should have failed if enabled
	And the type of the exception should be ArgumentException if enabled

Scenario: Not null check with custom message on private methods
	Given message is "Test custom message"
	And a private method with a not null check and custom message
	When the method is called
	Then the method should have failed if enabled
	And the exceptionMessage should be "Test custom message" if enabled

Scenario: Not null check on private methods
	Given a private method with a not null check
	When the method is called
	Then the method should have failed if enabled
