@dynamicBindings
Feature: ObservableExSpeedThrottleTo
    In order to effeciently process observable streams
    As a user
    I want to be able to control the number of items per time period dropping items as necessary

Scenario: Throttle rate to count per period
    Given _a test scheduler
    And an observable stream1 that publishes 6 integers at a rate of 1 every 300 milliseconds starting at 0 milliseconds
    And count is 2
    And _period is 1 second
    And ThrottleTo is chained to observable stream1
    And _an integer subscriber is subscribed
    When time advances by 1 second
    Then results should be list of integers 1, 2
    When time advances by 1 second
    Then results should be list of integers 1, 2, 5, 6
