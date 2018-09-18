@dynamicBindings
Feature: ObservableExSpeedLimit
    In order to effeciently process observable streams
    As a user
    I want to be able to control the number of items per time period

Scenario: Limit rate to count per period
    Given _a test scheduler
    And an observable stream1 that publishes 4 integers at a rate of 1 every 100 milliseconds starting at 0 milliseconds
    And count is 2
    And _period is 1 second
    And LimitTo is chained to observable stream1
    And _an integer subscriber is subscribed
    When time advances by 1 second
    Then results should be list of integers 1, 2
    When time advances by 1 second
    Then results should be list of integers 1, 2, 3, 4

Scenario: Limit 1 per period
    Given _a test scheduler
    And an observable stream1 that publishes 4 integers at a rate of 1 every 100 milliseconds starting at 0 milliseconds
    And _period is 200 milliseconds
    And LimitTo 1 per period is chained to observable stream1
    When _an integer subscriber is subscribed
    And time advances by 200 milliseconds
    Then results should be list of integers "1"
    When time advances by 200 milliseconds
    Then results should be list of integers 1, 2
    When time advances by 200 milliseconds
    Then results should be list of integers 1, 2, 3
    When time advances by 200 milliseconds
    Then results should be list of integers 1, 2, 3, 4

Scenario: Limit 1 per period with error
    Given _a test scheduler
    And an observable stream1 that publishes 4 integers at a rate of 1 every 100 milliseconds starting at 0 milliseconds
    And _period is 200 milliseconds
    And LimitTo 1 per period is chained to observable stream1
    And _an integer subscriber is subscribed that errors on 2
    When time advances by 200 milliseconds
    Then results should be list of integers "1"
    When time advances by 200 milliseconds
    Then results should be list of integers "1"
    When time advances by 200 milliseconds

Scenario: Limit 1 per period range
    Given _a test scheduler
    And an observable stream1 that publishes 4 integers at a rate of 1 every 100 milliseconds starting at 0 milliseconds
    And _minPeriod is 200 milliseconds
    And _maxPeriod is 400 milliseconds
    And LimitTo range is chained to observable stream1
    When an integer subscriber with interval is subscribed
    And time advances by 1600 milliseconds
    Then the integer time intervals should not all be the same
    And the integer time intervals except the first should all be between minPeriod and maxPeriod

Scenario: Limit 1 per period range start later
    Given _a test scheduler
    And an observable stream1 that publishes 4 integers at a rate of 1 every 100 milliseconds starting at 190 milliseconds
    And _minPeriod is 200 milliseconds
    And _maxPeriod is 400 milliseconds
    And LimitTo range is chained to observable stream1
    When an integer subscriber with interval is subscribed
    And time advances by 1600 milliseconds
    Then the integer time intervals should not all be the same
    And the integer time intervals except the first should all be between minPeriod and maxPeriod
