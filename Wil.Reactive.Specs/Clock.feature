@dynamicBindings
Feature: Clock
    In order to allow testing and other scenarios
    As a user
    I want to be able to control the way time is obtained and advanced

Background:
    Given _a test scheduler
    And schedulerStartTime is date time offset 2000, 1, 1
    # Need to make sure to local time conversions work.
    And time advances to date time offset schedulerStartTime

Scenario: Get current date and time offset
    Given _a Clock instance
    When the NowOffset property is accessed
    And the scheduler Now property is retrieved as schedulerNow
    Then NowOffset should be equal to schedulerNow
    When time advances by 20 seconds
    And the NowOffset property is accessed
    And the scheduler Now property is retrieved as schedulerNow
    Then NowOffset should be equal to schedulerNow

Scenario: Get current UTC date and time
    Given _a Clock instance
    When the UtcNow property is accessed
    And the scheduler Now property is retrieved as UTC date time schedulerNow
    Then UtcNow should be equal to schedulerNow
    When time advances by 20 seconds
    And the UtcNow property is accessed
    And the scheduler Now property is retrieved as UTC date time schedulerNow
    Then UtcNow should be equal to schedulerNow

Scenario: Get current date and time
    Given _a Clock instance
    When the Now property is accessed
    And the scheduler Now property is retrieved as date time schedulerNow
    Then Now should be equal to schedulerNow
    When time advances by 20 seconds
    And the Now property is accessed
    And the scheduler Now property is retrieved as date time schedulerNow
    Then Now should be equal to schedulerNow

Scenario: Get elapsed time
    Given _a Clock instance
    When the Elapsed property is accessed
    And the elapsed time of the scheduler from schedulerStartTime is retrieved as schedulerElapsed
    Then Elapsed should be equal to schedulerElapsed
    When time advances by 20 seconds
    And the Elapsed property is accessed
    And the elapsed time of the scheduler from schedulerStartTime is retrieved as schedulerElapsed
    Then Elapsed should be equal to schedulerElapsed

Scenario: Get elapsed date time ticks
    Given _a Clock instance
    When the DateTimeTicks property is accessed
    And the elapsed ticks of the scheduler from schedulerStartTime is retrieved as schedulerTicks
    Then DateTimeTicks should be equal to schedulerTicks
    When time advances by 20 seconds
    And the DateTimeTicks property is accessed
    And the elapsed ticks of the scheduler from schedulerStartTime is retrieved as schedulerTicks
    Then DateTimeTicks should be equal to schedulerTicks

Scenario: Convert elapsed ticks to date time offset
    Given _a Clock instance
    When the Ticks property is accessed
    And the ToDateTimeOffset method is called
    And the scheduler Now property is retrieved as schedulerNow
    Then result should be equal to schedulerNow
    When time advances by 20 seconds
    And the Ticks property is accessed
    And the ToDateTimeOffset method is called
    And the scheduler Now property is retrieved as schedulerNow
    Then result should be equal to schedulerNow
