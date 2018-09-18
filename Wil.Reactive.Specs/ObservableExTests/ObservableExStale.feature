@dynamicBindings
Feature: ObservableExStale
	In order to effectively work with observable boolean streams
	As a user
	I want to be able to tell when streams haven't produced data for a period

Scenario: Stale stream with non-stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3" at 100 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And DetectStale is chained to the observable
	And _a stale integer subscriber
	When time advances by 300 milliseconds
	Then staleCount should be 0

Scenario: Stale stream with stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3" at 200 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And DetectStale is chained to the observable
	And _a stale integer subscriber
	When time advances by 150 milliseconds
	Then staleCount should be 1
	When time advances by 150 milliseconds
	Then staleCount should be 1
	When time advances by 150 milliseconds
	Then staleCount should be 2
	When time advances by 150 milliseconds
	Then staleCount should be 3

Scenario: Stale stream scan with non-stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3" at 100 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And DetectStaleScan is chained to the observable
	And _a stale integer subscriber
	When time advances by 300 milliseconds
	Then staleCount should be 0
	And the result should be list of integers 1, 2, 3

Scenario: Stale stream scan with stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3" at 200 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And DetectStaleScan is chained to the observable
	And _a stale integer subscriber
	When time advances by 155 milliseconds
	Then staleCount should be 1
	And the result should be list of integers ""
	When time advances by 145 milliseconds
	Then staleCount should be 1
	And the result should be list of integers "1"
	When time advances by 150 milliseconds
	Then staleCount should be 2
	And the result should be list of integers 1, 2
	When time advances by 150 milliseconds
	Then staleCount should be 3
	And the result should be list of integers 1, 2, 3

Scenario: Stale group stream with non-stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3, 4, 5, 6" at 50 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And a function that groups integers into evens and odds
	And DetectStaleGroup is chained to the observable
	And _a stale group integer subscriber
	When time advances by 300 milliseconds
	Then evenStaleCount should not exist
	And oddStaleCount should not exist

Scenario: Stale group stream with stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3, 4, 5, 6" at 100 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And a function that groups integers into evens and odds
	And DetectStaleGroup is chained to the observable
	And _a stale group integer subscriber
	When time advances by 100 milliseconds
	Then evenStaleCount should not exist
	And oddStaleCount should not exist
	When time advances by 100 milliseconds
	Then evenStaleCount should not exist
	And oddStaleCount should not exist
	When time advances by 100 milliseconds
	Then evenStaleCount should not exist
	And oddStaleCount should be 1
	When time advances by 100 milliseconds
	Then evenStaleCount should be 1
	And oddStaleCount should be 1
	When time advances by 100 milliseconds
	Then evenStaleCount should be 1
	And oddStaleCount should be 2
	When time advances by 100 milliseconds
	Then evenStaleCount should be 2
	And oddStaleCount should be 2

Scenario: Stale group scan stream with non-stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3, 4, 5, 6" at 50 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And a function that groups integers into evens and odds
	And DetectStaleGroupScan is chained to the observable
	And _a stale group integer subscriber
	When time advances by 300 milliseconds
	Then evenResults should be list of integers 2, 4, 6
	And oddResults should be list of integers 1, 3, 5
	And evenStaleCount should not exist
	And oddStaleCount should not exist

Scenario: Stale group scan stream with stale data
	Given _a test scheduler
	And an observable that publishes integers "1, 2, 3, 4, 5, 6" at 100 millisecond intervals
	And _stalePeriod is 150 milliseconds
	And a function that groups integers into evens and odds
	And DetectStaleGroupScan is chained to the observable
	And _a stale group integer subscriber
	When time advances by 100 milliseconds
	Then evenStaleCount should not exist
	And oddStaleCount should not exist
	And oddResults should be list of integers "1"
	When time advances by 100 milliseconds
	Then evenStaleCount should not exist
	And oddStaleCount should not exist
	And evenResults should be list of integers "2"
	And oddResults should be list of integers "1"
	When time advances by 100 milliseconds
	Then evenStaleCount should not exist
	And oddStaleCount should be 1
	And evenResults should be list of integers "2"
	And oddResults should be list of integers 1, 3
	When time advances by 100 milliseconds
	Then evenStaleCount should be 1
	And oddStaleCount should be 1
	And evenResults should be list of integers 2, 4
	And oddResults should be list of integers 1, 3
	When time advances by 100 milliseconds
	Then evenStaleCount should be 1
	And oddStaleCount should be 2
	And evenResults should be list of integers 2, 4
	And oddResults should be list of integers 1, 3, 5
	When time advances by 100 milliseconds
	Then evenStaleCount should be 2
	And oddStaleCount should be 2
	And evenResults should be list of integers 2, 4, 6
	And oddResults should be list of integers 1, 3, 5
