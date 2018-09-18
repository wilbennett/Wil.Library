@dynamicBindings
Feature: Generated Duration Bindings
	In order to quickly create SpecFlow unit tests
	As a user
	I want use generated bindings

#@ignore
Scenario: Null checks
  Given null
  Given actual is null
  Given other null
  Given null as the goal
  Given expected is null
  Given instance as "0:0:1"
  Given a null array of duration
  Given a null enumerable of duration
  Given a null ICollection of duration
  Given a null IList of duration
  Given a null IReadOnlyCollection of duration
  Given a null IReadOnlyList of duration
  Given a null list of duration
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of duration
  Then the result should be a null enumerable of duration
  Then the result should be a null ICollection of duration
  Then the result should be a null IList of duration
  Then the result should be a null IReadOnlyCollection of duration
  Then the result should be a null IReadonlyList of duration
  Then the result should be a null list of duration
  Given collection is a list of 0:0:1, 0:0:2, 0:0:3
  Given an array of duration 0:0:1, 0:0:2, 0:0:3
  Given an enumerable of duration 0:0:1, 0:0:2, 0:0:3
  Given an ICollection of duration 0:0:1, 0:0:2, 0:0:3
  Given an IList of duration 0:0:1, 0:0:2, 0:0:3
  Given an IReadOnlyCollection of duration 0:0:1, 0:0:2, 0:0:3
  Given an IReadOnlyList of duration 0:0:1, 0:0:2, 0:0:3
  Given a list of duration 0:0:1, 0:0:2, 0:0:3
  Then collection should not be null
  Then the result should not be a null array of duration
  Then the result should not be a null enumerable of duration
  Then the result should not be a null ICollection of duration
  Then the result should not be a null IList of duration
  Then the result should not be a null IReadOnlyCollection of duration
  Then the result should not be a null IReadonlyList of duration
  Then the result should not be a null list of duration

#@ignore
Scenario: Name, name
  Given actual is duration "0:0:6"
  Given expected is '0:0:6'
  Given duration "0:0:6" as the target
  Given extraSmall is duration: 0:0:0.100
  Given "0:0:3" as small
  Given large "0:1:0"
  Given extraLarge: 1:0:0
  Then actual should be expected
  Then actual should be equal to expected
  Then actual should equal expected
  Then the actual should equal expected
  Then actual should be equivalent to expected
  Then actual should be greater than small
  Then actual should be less than large
  Then actual should be greater than or equal to target
  Then actual should be greater than or equal target
  Then actual should be greater or equal to small
  Then actual should be greater or equal small
  Then actual should be less than or equal to target
  Then actual should be less than or equal target
  Then actual should be less or equal to large
  Then actual should be less or equal large
  Then actual should not be extraSmall
  Then actual should not be equal to small
  Then actual should not equal small
  Then actual should match expected
  Then the actual should not equal extraSmall
  Then actual should not be equivalent to small
  Then actual should not be greater than or equal to large
  Then actual should not be greater than or equal large
  Then actual should not be greater or equal to large
  Then actual should not be greater or equal extraLarge
  Then actual should not be less than or equal to extraSmall
  Then actual should not be less than or equal extraSmall
  Then actual should not be less or equal to small
  Then actual should not be less or equal small
  Then actual should not match small
  Given actual is enumerable of duration 0:0:1, 0:0:2, 0:0:3
  Given expectedArray is array of "0:0:1, 0:0:2, 0:0:3"
  Given expectedEnumerable as enumerable of '0:0:1, 0:0:2, 0:0:3'
  Given expectedCollection is an ICollection of durations: 0:0:1, 0:0:2, 0:0:3
  Given expectedIList is an IList of: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyList is an IReadOnlyList of: 0:0:1, 0:0:2, 0:0:3
  Given the expectedList as a list of durations: 0:0:1, 0:0:2, 0:0:3
  Given "0:0:1", "0:0:3" as subset
  Given an ICollection of durations '0:0:5', '0:0:6', '0:0:7' as other
  Given the scrambled as IList of '0:0:2', '0:0:3', '0:0:1'
  Then actual should be expectedEnumerable
  Then actual should be equal to expectedArray
  Then actual should equal expectedCollection
  Then actual should equal expectedIList
  Then actual should equal expectedReadOnlyCollection
  Then actual should equal expectedReadOnlyList
  Then the actual should equal expectedList
  Then actual should be equivalent to scrambled
  Then actual should contain subset
  Then actual should not be other
  Then actual should not be equal to other
  Then actual should not equal other
  Then the actual should not equal other
  Then actual should not be equivalent to other
  Then actual should not contain other

#@ignore
Scenario: Name, value
  Given actual is duration "0:0:6"
  Then actual should be "0:0:6"
  Then actual should be equal to "0:0:6"
  Then actual should be equal to duration "0:0:6"
  Then actual should equal "0:0:6"
  Then the actual should equal "0:0:6"
  Then actual should be equivalent to "0:0:6"
  Then actual should match "\D+"
  Then actual should be greater than "0:0:5"
  Then actual should be less than "1:0:0"
  Then actual should be greater than or equal to "0:0:6"
  Then actual should be greater than or equal "0:0:6"
  Then actual should be greater or equal to "0:0:5"
  Then actual should be greater or equal "0:0:5"
  Then actual should be less than or equal to "0:0:6"
  Then actual should be less than or equal "0:0:6"
  Then actual should be less or equal to "1:0:0"
  Then actual should be less or equal "1:0:0"
  Then actual should not be "0:0:5"
  Then actual should not be equal to "0:0:5"
  Then actual should not equal "0:0:5"
  Then the actual should not equal "0:0:5"
  Then actual should not be equivalent to "0:0:5"
  Then actual should not match "e.*"
  Then actual should not be greater than or equal to "1:0:0"
  Then actual should not be greater than or equal "1:0:0"
  Then actual should not be greater or equal to "1:0:0"
  Then actual should not be greater or equal "1:0:0"
  Then actual should not be less than or equal to "0:0:5"
  Then actual should not be less than or equal "0:0:5"
  Then actual should not be less or equal to "0:0:5"
  Then actual should not be less or equal "0:0:5"
  Given actual is enumerable of duration 0:0:1, 0:0:2, 0:0:3
  Given other is "0:0:1", "0:0:2", "0:0:3"
  Then actual should be enumerable of '0:0:1, 0:0:2, 0:0:3'
  Then other should be equal to array of "0:0:1, 0:0:2, 0:0:3"
  Then actual should equal ICollection of: 0:0:1, 0:0:2, 0:0:3
  Then actual should equal an IList of: 0:0:1, 0:0:2, 0:0:3
  Then actual should equal an IReadOnlyCollection of: 0:0:1, 0:0:2, 0:0:3
  Then actual should equal an IReadOnlyList of: 0:0:1, 0:0:2, 0:0:3
  Then the actual should equal list of durations: 0:0:1, 0:0:2, 0:0:3
  Then actual should be equivalent to '0:0:2', '0:0:3', '0:0:1'
  Then actual should contain "0:0:1", "0:0:3"
  Then actual should not be an ICollection of durations '0:0:5', '0:0:6', '0:0:7'
  Then actual should not be equal to an ICollection of durations: '0:0:5', '0:0:6', '0:0:7'
  Then actual should not equal an ICollection of: '0:0:5', '0:0:6', '0:0:7'
  Then the actual should not equal ICollection of: '0:0:5', '0:0:6', '0:0:7'
  Then actual should not be equivalent to an ICollection of durations '0:0:5', '0:0:6', '0:0:7'
  Then actual should not contain an ICollection of durations '0:0:5', '0:0:6', '0:0:7'

#@ignore
Scenario: Default, value
  Given duration "0:0:6"
  Then result should be "0:0:6"
  Then result should be equal to "0:0:6"
  Then result should equal "0:0:6"
  Then the result should equal "0:0:6"
  Then result should be equivalent to "0:0:6"
  Then result should match "0:0:6"
  Given "0:0:6"
  Then result should be greater than "0:0:5"
  Then result should be less than "1:0:0"
  Then result should be greater than or equal to "0:0:6"
  Then result should be greater than or equal "0:0:6"
  Then result should be greater or equal to "0:0:5"
  Then result should be greater or equal "0:0:5"
  Then result should be less than or equal to "0:0:6"
  Then result should be less than or equal "0:0:6"
  Then result should be less or equal to "1:0:0"
  Then result should be less or equal "1:0:0"
  Given "0:0:6" as a duration
  Then result should not be "0:0:5"
  Then result should not be equal to "0:0:5"
  Then result should not equal "0:0:5"
  Then the result should not equal "0:0:5"
  Then result should not be equivalent to "0:0:5"
  Then result should not match "0:0:5"
  Then result should not be greater than or equal to "1:0:0"
  Then result should not be greater than or equal "1:0:0"
  Then result should not be greater or equal to "1:0:0"
  Then result should not be greater or equal "1:0:0"
  Then result should not be less than or equal to "0:0:5"
  Then result should not be less than or equal "0:0:5"
  Then result should not be less or equal to "0:0:5"
  Then result should not be less or equal "0:0:5"
  Given array of "0:0:1, 0:0:2, 0:0:3"
  Given enumerable of '0:0:1, 0:0:2, 0:0:3'
  Given an ICollection of durations 0:0:1, 0:0:2, 0:0:3
  Given an IList of: 0:0:1, 0:0:2, 0:0:3
  Given 0:0:1, 0:0:2, 0:0:3 as an IReadOnlyCollection of duration
  Given "0:0:1", "0:0:2", "0:0:3" as an IReadOnlyList
  # Defaults to List<T>
  Given '0:0:1', '0:0:2', '0:0:3'
  Then result should be "0:0:1", "0:0:2", "0:0:3"
  Then result should be enumerable of '0:0:1, 0:0:2, 0:0:3'
  Then result should be equal to array of "0:0:1, 0:0:2, 0:0:3"
  Then result should equal ICollection of: 0:0:1, 0:0:2, 0:0:3
  Then result should equal an IList of: 0:0:1, 0:0:2, 0:0:3
  Then result should equal an IReadOnlyCollection of: 0:0:1, 0:0:2, 0:0:3
  Then result should equal an IReadOnlyList of: 0:0:1, 0:0:2, 0:0:3
  Then the result should equal list of durations: 0:0:1, 0:0:2, 0:0:3
  Then result should be equivalent to '0:0:2', '0:0:3', '0:0:1'
  Then result should contain durations "0:0:1", "0:0:3"
  Then result should not be an ICollection of durations '0:0:5', '0:0:6', '0:0:7'
  Then result should not be equal to an ICollection of durations: '0:0:5', '0:0:6', '0:0:7'
  Then result should not equal an ICollection of: '0:0:5', '0:0:6', '0:0:7'
  Then the result should not equal ICollection of: '0:0:5', '0:0:6', '0:0:7'
  Then result should not be equivalent to an ICollection of durations '0:0:5', '0:0:6', '0:0:7'
  Then result should not contain an ICollection of durations '0:0:5', '0:0:6', '0:0:7'

#@ignore
Scenario: Default, name
  Given duration "0:0:6"
  Given expected is "0:0:6"
  Given duration "0:0:6" as the target
  Given extraSmall is duration: 0:0:1
  Given "0:0:3" as small
  Given large "0:1:0"
  Given extraLarge: 1:0:0
  Then result should be expected
  Then result should be equal to expected
  Then result should equal expected
  Then the result should equal expected
  Then result should be equivalent to expected
  Then result should match expected
  Then result should be greater than small
  Then result should be less than large
  Then result should be greater than or equal to target
  Then result should be greater than or equal target
  Then result should be greater or equal to small
  Then result should be greater or equal small
  Then result should be less than or equal to target
  Then result should be less than or equal target
  Then result should be less or equal to large
  Then result should be less or equal large
  Then result should not be extraSmall
  Then result should not be equal to small
  Then result should not equal small
  Then the result should not equal extraSmall
  Then result should not be equivalent to small
  Then result should not match small
  Then result should not be greater than or equal to large
  Then result should not be greater than or equal large
  Then result should not be greater or equal to large
  Then result should not be greater or equal extraLarge
  Then result should not be less than or equal to extraSmall
  Then result should not be less than or equal extraSmall
  Then result should not be less or equal to small
  Then result should not be less or equal small
  Given array of "0:0:1, 0:0:2, 0:0:3"
  # Defaults to List<T>
  Given "0:0:1", "0:0:2", "0:0:3"
  Given expectedArray is array of "0:0:1, 0:0:2, 0:0:3"
  Given expectedEnumerable as enumerable of '0:0:1, 0:0:2, 0:0:3'
  Given expectedCollection is an ICollection of durations: 0:0:1, 0:0:2, 0:0:3
  Given expectedIList is an IList of: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyList is an IReadOnlyList of: 0:0:1, 0:0:2, 0:0:3
  Given the expectedList as a list of durations: 0:0:1, 0:0:2, 0:0:3
  Given "0:0:1", "0:0:3" as subset
  Given an ICollection of durations '0:0:5', '0:0:6', '0:0:7' as other
  Given the scrambled as IList of '0:0:2', '0:0:3', '0:0:1'
  Then result should be expectedEnumerable
  Then result should be equal to expectedArray
  Then result should equal expectedCollection
  Then result should equal expectedIList
  Then result should equal expectedReadOnlyCollection
  Then result should equal expectedReadOnlyList
  Then the result should equal expectedList
  Then result should be equivalent to scrambled
  Then result should contain subset
  Then result should not be other
  Then result should not be equal to other
  Then result should not equal other
  Then the result should not equal other
  Then result should not be equivalent to other
  Then result should not contain other

