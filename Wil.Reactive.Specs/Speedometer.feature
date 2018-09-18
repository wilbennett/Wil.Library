@dynamicBindings
Feature: Speedometer
    In order to optimize code
    As a user
    I want to be able to measure the speed of various operations

Scenario: Get PeriodString property
  Given period is "0:0:1"
  And scheduler is a TestScheduler
  And speedometer is a Speedometer created with period, scheduler
  And periodString is speedometer.PeriodString
  Then periodString should be "sec"
  Given period is "0:1:0"
  And speedometer is a Speedometer created with period, scheduler
  And periodString is speedometer.PeriodString
  Then periodString should be "min"
  Given period is "1:0:0"
  And speedometer is a Speedometer created with period, scheduler
  And periodString is speedometer.PeriodString
  Then periodString should be "hour"
  Given period is "1.0:0:0"
  And speedometer is a Speedometer created with period, scheduler
  When the speedometer.PeriodString is read
  Then the result should be "day"
  Given period is "0:0:2"
  And speedometer is a Speedometer created with period, scheduler
  When speedometer.PeriodString is read
  Then the result should be string "00:00:02"

Scenario: Set PeriodString property
  Given period is "0:0:1"
  And scheduler is a TestScheduler
  And speedometer is a Speedometer created with period, scheduler
  And period is "1:0:0"
  And periodString is speedometer.PeriodString
  Then periodString should be "sec"
