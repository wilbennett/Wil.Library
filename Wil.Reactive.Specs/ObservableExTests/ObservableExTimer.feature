@dynamicBindings
Feature: ObservableExTimer
    In order to effeciently work with observable streams
    As a user
    I want to be able to use timers and apply timeouts to observables

Scenario: Random timer
    Given _a test scheduler
    And _dueTime is 200 milliseconds
    And _minPeriod is 200 milliseconds
    And _maxPeriod is 400 milliseconds
    And a RandomTimer observable that publishes 3 values is created
    When an integer subscriber with interval is subscribed
    And time advances by 1200 milliseconds
    Then the integer time intervals should not all be the same
    And the integer time intervals should all be between minPeriod and maxPeriod

Scenario: Reset timer
    Given _a test scheduler
    And an observable stream1 that publishes 3 integers at a rate of 1 every 300 milliseconds starting at 0 milliseconds
    And _dueTime is 200 milliseconds
    And _period is 200 milliseconds
    And a ResetTimer observable is created that uses stream1 as the reset source
    When an integer subscriber with time is subscribed
    And time advances by 1500 milliseconds
    Then results should be list of strings "0@00:00:00.2000001, 1@00:00:00.5000000"

Scenario: Timeout
    Given _a test scheduler
    And an observable stream1 that publishes 3 integers at a rate of 1 every 300 milliseconds starting at 0 milliseconds
    And _period is 200 milliseconds
    And timeoutValue is 999
    And Timeout is chained to observable stream1
    When an integer subscriber with time is subscribed
    And time advances by 1500 milliseconds
    Then results should be list of strings "999@00:00:00.2000001, 999@00:00:00.5000000"

Scenario: Timeout start with timeout
    Given _a test scheduler
    And an observable stream1 that publishes 3 integers at a rate of 1 every 300 milliseconds starting at 300 milliseconds
    And _period is 200 milliseconds
    And timeoutValue is 999
    And Timeout is chained to observable stream1
    When an integer subscriber with time is subscribed
    And time advances by 1800 milliseconds
    Then results should be list of strings "999@00:00:00.2000000, 999@00:00:00.5000000, 999@00:00:00.8000000"

Scenario: Timeout scan
    Given _a test scheduler
    And an observable stream1 that publishes 3 integers at a rate of 1 every 300 milliseconds starting at 0 milliseconds
    And _period is 200 milliseconds
    And timeoutValue is 999
    And TimeoutScan is chained to observable stream1
    When an integer subscriber with time is subscribed
    And time advances by 1500 milliseconds
    Then results should be list of strings "1@00:00:00.0000001, 999@00:00:00.2000001, 2@00:00:00.3000000, 999@00:00:00.5000000, 3@00:00:00.6000000"

Scenario: Timeout scan start with timeout
    Given _a test scheduler
    And an observable stream1 that publishes 3 integers at a rate of 1 every 300 milliseconds starting at 300 milliseconds
    And _period is 200 milliseconds
    And timeoutValue is 999
    And TimeoutScan is chained to observable stream1
    When an integer subscriber with time is subscribed
    And time advances by 1500 milliseconds
    Then results should be list of strings "999@00:00:00.2000000, 1@00:00:00.3000000, 999@00:00:00.5000000, 2@00:00:00.6000000, 999@00:00:00.8000000, 3@00:00:00.9000000"
