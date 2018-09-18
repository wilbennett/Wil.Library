@dynamicBindings
Feature: Generated Ssbyte Bindings
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
  Given instance as 1
  Given a null array of sbyte
  Given a null enumerable of sbyte
  Given a null ICollection of sbyte
  Given a null IList of sbyte
  Given a null IReadOnlyCollection of sbyte
  Given a null IReadOnlyList of sbyte
  Given a null list of sbyte
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of sbyte
  Then the result should be a null enumerable of sbyte
  Then the result should be a null ICollection of sbyte
  Then the result should be a null IList of sbyte
  Then the result should be a null IReadOnlyCollection of sbyte
  Then the result should be a null IReadonlyList of sbyte
  Then the result should be a null list of sbyte
  Given collection is a list of 1, 2, 3
  Given an array of sbyte 1, 2, 3
  Given an enumerable of sbyte 1, 2, 3
  Given an ICollection of sbyte 1, 2, 3
  Given an IList of sbyte 1, 2, 3
  Given an IReadOnlyCollection of sbyte 1, 2, 3
  Given an IReadOnlyList of sbyte 1, 2, 3
  Given a list of sbyte 1, 2, 3
  Then collection should not be null
  Then the result should not be a null array of sbyte
  Then the result should not be a null enumerable of sbyte
  Then the result should not be a null ICollection of sbyte
  Then the result should not be a null IList of sbyte
  Then the result should not be a null IReadOnlyCollection of sbyte
  Then the result should not be a null IReadonlyList of sbyte
  Then the result should not be a null list of sbyte

#@ignore
Scenario: Name, name
  Given actual is sbyte 10
  Given expected as sbyte 10
  Given sbyte 10 as the target
  Given extraSmall is sbyte: -127
  Given sbyte -100 as small
  Given large 100
  Given extraLarge: 127
  Given the temp is 4
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
  Given actual is enumerable of sbyte 1, 2, 3
  Given expectedArray is array of sbytes "1, 2, 3"
  Given expectedEnumerable as enumerable of sbytes '1, 2, 3'
  Given expectedCollection is an ICollection of sbytes: 1, 2, 3
  Given expectedIList is an IList of sbytes: 1, 2, 3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of sbytes: 1, 2, 3
  Given expectedReadOnlyList is an IReadOnlyList of sbytes: 1, 2, 3
  Given the expectedList as a list of sbytes: 1, 2, 3
  Given list of sbytes "1", "3" as subset
  Given an ICollection of sbytes '5', '6', '7' as other
  Given the scrambled as IList of sbytes '2', '3', '1'
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
  Given actual is sbyte 10
  Then actual should be 10
  Then actual should be equal to 10
  Then actual should be equal to sbyte 10
  Then actual should equal 10
  Then the actual should equal 10
  Then actual should be equivalent to 10
  Then actual should match "\d\d"
  Then actual should be greater than 5
  Then actual should be less than 100
  Then actual should be greater than or equal to 10
  Then actual should be greater than or equal 10
  Then actual should be greater or equal to 5
  Then actual should be greater or equal 5
  Then actual should be less than or equal to 10
  Then actual should be less than or equal 10
  Then actual should be less or equal to 100
  Then actual should be less or equal 100
  Then actual should not be 5
  Then actual should not be equal to 5
  Then actual should not equal 5
  Then the actual should not equal 5
  Then actual should not be equivalent to 5
  Then actual should not match "\d\d\d"
  Then actual should not be greater than or equal to 100
  Then actual should not be greater than or equal 100
  Then actual should not be greater or equal to 100
  Then actual should not be greater or equal 100
  Then actual should not be less than or equal to 5
  Then actual should not be less than or equal 5
  Then actual should not be less or equal to 5
  Then actual should not be less or equal 5
  Given actual is enumerable of sbyte 1, 2, 3
  Given other is list of sbytes "1", "2", "3"
  Then actual should be enumerable of sbytes '1, 2, 3'
  Then other should be equal to array of sbytes "1, 2, 3"
  Then actual should equal ICollection of sbytes: 1, 2, 3
  Then actual should equal an IList of sbytes: 1, 2, 3
  Then actual should equal an IReadOnlyCollection of sbytes: 1, 2, 3
  Then actual should equal an IReadOnlyList of sbytes: 1, 2, 3
  Then the actual should equal list of sbytes: 1, 2, 3
  Then actual should be equivalent to list of sbytes '2', '3', '1'
  Then actual should contain list of sbytes "1", "3"
  Then actual should not be an ICollection of sbytes '5', '6', '7'
  Then actual should not be equal to an ICollection of sbytes: '5', '6', '7'
  Then actual should not equal an ICollection of sbytes: '5', '6', '7'
  Then the actual should not equal ICollection of sbytes: '5', '6', '7'
  Then actual should not be equivalent to an ICollection of sbytes '5', '6', '7'
  Then actual should not contain an ICollection of sbytes '5', '6', '7'

#@ignore
Scenario: Default, value
  Given sbyte 10
  Then result should be sbyte 10
  Then result should be equal to sbyte 10
  Then result should equal sbyte 10
  Then the result should equal sbyte 10
  Then result should be equivalent to sbyte 10
  Then result should match sbyte 10
  Then result should be greater than sbyte 5
  Then result should be less than sbyte 100
  Then result should be greater than or equal to sbyte 10
  Then result should be greater than or equal sbyte 10
  Then result should be greater or equal to sbyte 5
  Then result should be greater or equal sbyte 5
  Then result should be less than or equal to sbyte 10
  Then result should be less than or equal sbyte 10
  Then result should be less or equal to sbyte 100
  Then result should be less or equal sbyte 100
  Given 10 as a sbyte
  Then result should not be sbyte 5
  Then result should not be equal to sbyte 5
  Then result should not equal sbyte 5
  Then the result should not equal sbyte 5
  Then result should not be equivalent to sbyte 5
  Then result should not match sbyte 5
  Then result should not be greater than or equal to sbyte 100
  Then result should not be greater than or equal sbyte 100
  Then result should not be greater or equal to sbyte 100
  Then result should not be greater or equal sbyte 100
  Then result should not be less than or equal to sbyte 5
  Then result should not be less than or equal sbyte 5
  Then result should not be less or equal to sbyte 5
  Then result should not be less or equal sbyte 5
  Given array of sbytes "1, 2, 3"
  Given enumerable of sbytes '1, 2, 3'
  Given an ICollection of sbytes 1, 2, 3
  Given an IList of sbytes: 1, 2, 3
  Given 1, 2, 3 as an IReadOnlyCollection of sbyte
  Given "1", "2", "3" as an IReadOnlyList of sbytes
  # Defaults to List<T>
  Given sbytes '1', '2', '3'
  Then result should be sbytes "1", "2", "3"
  Then result should be enumerable of sbytes '1, 2, 3'
  Then result should be equal to array of sbytes "1, 2, 3"
  Then result should equal ICollection of sbytes: 1, 2, 3
  Then result should equal an IList of sbytes: 1, 2, 3
  Then result should equal an IReadOnlyCollection of sbytes: 1, 2, 3
  Then result should equal an IReadOnlyList of sbytes: 1, 2, 3
  Then the result should equal list of sbytes: 1, 2, 3
  Then result should be equivalent to list of sbytes '2', '3', '1'
  Then result should contain list of sbytes "1", "3"
  Then result should not be an ICollection of sbytes '5', '6', '7'
  Then result should not be equal to an ICollection of sbytes: '5', '6', '7'
  Then result should not equal an ICollection of sbytes: '5', '6', '7'
  Then the result should not equal ICollection of sbytes: '5', '6', '7'
  Then result should not be equivalent to an ICollection of sbytes '5', '6', '7'
  Then result should not contain an ICollection of sbytes '5', '6', '7'

#@ignore
Scenario: Default, name
  Given sbyte 10
  Given expected is sbyte 10
  Given sbyte 10 as the target
  Given extraSmall is sbyte: -127
  Given sbyte -100 as small
  Given large as sbyte 100
  Given extraLarge is sbyte: 127
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
  Given array of sbytes "1, 2, 3"
  Given list of sbytes "1", "2", "3"
  Given expectedArray is array of sbytes "1, 2, 3"
  Given expectedEnumerable as enumerable of sbytes '1, 2, 3'
  Given expectedCollection is an ICollection of sbytes: 1, 2, 3
  Given expectedIList is an IList of sbytes: 1, 2, 3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of sbytes: 1, 2, 3
  Given expectedReadOnlyList is an IReadOnlyList of sbytes: 1, 2, 3
  Given the expectedList as a list of sbytes: 1, 2, 3
  Given list of sbytes "1", "3" as subset
  Given an ICollection of sbytes '5', '6', '7' as other
  Given the scrambled as IList of sbytes '2', '3', '1'
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

