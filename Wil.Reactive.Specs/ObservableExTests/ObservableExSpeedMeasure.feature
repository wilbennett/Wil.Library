@dynamicBindings
Feature: ObservableExSpeedMeasure
    In order to effeciently work with observable streams
    As a user
    I want to be able to determine and control the speed at which data is published

Scenario: Measure stream speed
    Given _a test scheduler
    And an observable stream1 that publishes 6 integers at a rate of 1 every 200 milliseconds starting at 2000 milliseconds
    And an observable stream2 that publishes 3 integers at a rate of 1 every 3000 milliseconds starting at 2000 milliseconds
    And _stream2 is concatenated to stream1
    And _measurePeriod is 1 second
    And Measure is chained to the observable
    When a rate subscriber is subscribed
    And time advances to 11 seconds
    Then results should be list of strings "0 per sec, 1 per sec, 5 per sec, 0 per sec, 1 per sec, 0 per sec, 1 per sec, 0 per sec, 1 per sec"

Scenario: Measure stream speed while getting data
    Given _a test scheduler
    And an observable stream1 that publishes 6 integers at a rate of 1 every 200 milliseconds starting at 2000 milliseconds
    And an observable stream2 that publishes 3 integers at a rate of 1 every 3000 milliseconds starting at 2000 milliseconds
    And _stream2 is concatenated to stream1
    And _measurePeriod is 1 second
    And MeasureScan is chained to the observable
    When an integer rate event subscriber is subscribed
    And time advances to 11 seconds
    Then results should be list of strings "0@0, 1@1, 2@1, 3@1, 4@1, 5@1, 6@5, 0@0, 1@1, 0@0, 2@1, 0@0, 3@1"

Scenario: Measure stream speed while getting data starting at 0
    Given _a test scheduler
    And an observable stream1 that publishes 6 integers at a rate of 1 every 200 milliseconds starting at 0 milliseconds
    And an observable stream2 that publishes 3 integers at a rate of 1 every 3000 milliseconds starting at 2000 milliseconds
    And _stream2 is concatenated to stream1
    And _measurePeriod is 1 second
    And MeasureScan is chained to the observable
    When an integer rate event subscriber is subscribed
    And time advances to 11 seconds
    Then results should be list of strings "1@10000000, 2@10, 3@8, 4@7, 5@6, 6@6, 0@0, 1@1, 0@0, 2@1, 0@0, 3@1"
