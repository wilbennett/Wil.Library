@dynamicBindings
Feature: ObservableExExecute
	In order to work with results from function calls on each data element of an observable
	As a user
	I want to be able to get only the latest results

Scenario: Normal function call with error
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 0 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using a normal function that errors when called with 1
  When a subscriber is subscribed
  #TODO: Investigate. This is failing on the build server.
  #Then results should be list of integers 0
  #And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"
  #And subscribeException should exist
  Then subscribeException should exist

Scenario: Normal function call
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 0 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using a normal function
  When a subscriber is subscribed
  Then results should be list of integers 0, 1
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"

Scenario: Normal function with overlapping calls
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 100 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using a normal function
  When a subscriber is subscribed
  Then results should be list of integers "1"
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"

Scenario: Normal cancellable function call
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 0 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using a normal cancellable function
  When a subscriber is subscribed
  Then results should be list of integers 0, 1
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"

Scenario: Normal cancellable function with overlapping calls
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 100 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using a normal cancellable function
  When a subscriber is subscribed
  Then results should be list of integers "1"
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"

Scenario: Async function call
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 0 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using an async function
  When a subscriber is subscribed
  Then results should be list of integers 0, 1
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"

Scenario: Async function with overlapping calls
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 100 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using an async function
  When a subscriber is subscribed
  Then results should be list of integers "1"
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"

Scenario: Async cancellable function call
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 0 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using an async cancellable function
  When a subscriber is subscribed
  Then results should be list of integers 0, 1
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"

Scenario: Async cancellable function with overlapping calls
  Given an observable that publishes 2 integers at 50 millisecond intervals
  And _functionTimeout is 100 milliseconds
  And a method that records notifications
  And ExecuteRestartOnNew is chained to the observable using an async cancellable function
  When a subscriber is subscribed
  Then results should be list of integers "1"
  And notifications should be list of strings "Initialize, Starting 0, Stopping 0, Starting 1, Stopping 1, Finalize"
