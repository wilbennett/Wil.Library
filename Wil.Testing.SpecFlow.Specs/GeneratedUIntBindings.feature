﻿@dynamicBindings
Feature: Generated UInt Bindings
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
  Given a null array of uint
  Given a null enumerable of uint
  Given a null ICollection of uint
  Given a null IList of uint
  Given a null IReadOnlyCollection of uint
  Given a null IReadOnlyList of uint
  Given a null list of uint
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of uint
  Then the result should be a null enumerable of uint
  Then the result should be a null ICollection of uint
  Then the result should be a null IList of uint
  Then the result should be a null IReadOnlyCollection of uint
  Then the result should be a null IReadonlyList of uint
  Then the result should be a null list of uint
  Given collection is a list of 1, 2, 3
  Given an array of uint 1, 2, 3
  Given an enumerable of uint 1, 2, 3
  Given an ICollection of uint 1, 2, 3
  Given an IList of uint 1, 2, 3
  Given an IReadOnlyCollection of uint 1, 2, 3
  Given an IReadOnlyList of uint 1, 2, 3
  Given a list of uint 1, 2, 3
  Then collection should not be null
  Then the result should not be a null array of uint
  Then the result should not be a null enumerable of uint
  Then the result should not be a null ICollection of uint
  Then the result should not be a null IList of uint
  Then the result should not be a null IReadOnlyCollection of uint
  Then the result should not be a null IReadonlyList of uint
  Then the result should not be a null list of uint

#@ignore
Scenario: Name, name
  Given actual is uint 10
  Given expected as uint 10
  Given uint 10 as the target
  Given extraSmall is uint: 1
  Given uint 5 as small
  Given large 3000000000
  Given extraLarge: 4000000000
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
  Given actual is enumerable of uint 1, 2, 3
  Given expectedArray is array of uints "1, 2, 3"
  Given expectedEnumerable as enumerable of uints '1, 2, 3'
  Given expectedCollection is an ICollection of uints: 1, 2, 3
  Given expectedIList is an IList of uints: 1, 2, 3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of uints: 1, 2, 3
  Given expectedReadOnlyList is an IReadOnlyList of uints: 1, 2, 3
  Given the expectedList as a list of uints: 1, 2, 3
  Given list of uints "1", "3" as subset
  Given an ICollection of uints '5', '6', '7' as other
  Given the scrambled as IList of uints '2', '3', '1'
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
  Given actual is uint 10
  Then actual should be 10
  Then actual should be equal to 10
  Then actual should be equal to uint 10
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
  Given actual is enumerable of uint 1, 2, 3
  Given other is list of uints "1", "2", "3"
  Then actual should be enumerable of uints '1, 2, 3'
  Then other should be equal to array of uints "1, 2, 3"
  Then actual should equal ICollection of uints: 1, 2, 3
  Then actual should equal an IList of uints: 1, 2, 3
  Then actual should equal an IReadOnlyCollection of uints: 1, 2, 3
  Then actual should equal an IReadOnlyList of uints: 1, 2, 3
  Then the actual should equal list of uints: 1, 2, 3
  Then actual should be equivalent to list of uints '2', '3', '1'
  Then actual should contain list of uints "1", "3"
  Then actual should not be an ICollection of uints '5', '6', '7'
  Then actual should not be equal to an ICollection of uints: '5', '6', '7'
  Then actual should not equal an ICollection of uints: '5', '6', '7'
  Then the actual should not equal ICollection of uints: '5', '6', '7'
  Then actual should not be equivalent to an ICollection of uints '5', '6', '7'
  Then actual should not contain an ICollection of uints '5', '6', '7'

#@ignore
Scenario: Default, value
  Given uint 10
  Then result should be uint 10
  Then result should be equal to uint 10
  Then result should equal uint 10
  Then the result should equal uint 10
  Then result should be equivalent to uint 10
  Then result should match uint 10
  Then result should be greater than uint 5
  Then result should be less than uint 100
  Then result should be greater than or equal to uint 10
  Then result should be greater than or equal uint 10
  Then result should be greater or equal to uint 5
  Then result should be greater or equal uint 5
  Then result should be less than or equal to uint 10
  Then result should be less than or equal uint 10
  Then result should be less or equal to uint 100
  Then result should be less or equal uint 100
  Given 10 as a uint
  Then result should not be uint 5
  Then result should not be equal to uint 5
  Then result should not equal uint 5
  Then the result should not equal uint 5
  Then result should not be equivalent to uint 5
  Then result should not match uint 5
  Then result should not be greater than or equal to uint 100
  Then result should not be greater than or equal uint 100
  Then result should not be greater or equal to uint 100
  Then result should not be greater or equal uint 100
  Then result should not be less than or equal to uint 5
  Then result should not be less than or equal uint 5
  Then result should not be less or equal to uint 5
  Then result should not be less or equal uint 5
  Given array of uints "1, 2, 3"
  Given enumerable of uints '1, 2, 3'
  Given an ICollection of uints 1, 2, 3
  Given an IList of uints: 1, 2, 3
  Given 1, 2, 3 as an IReadOnlyCollection of uint
  Given "1", "2", "3" as an IReadOnlyList of uints
  # Defaults to List<T>
  Given uints '1', '2', '3'
  Then result should be uints "1", "2", "3"
  Then result should be enumerable of uints '1, 2, 3'
  Then result should be equal to array of uints "1, 2, 3"
  Then result should equal ICollection of uints: 1, 2, 3
  Then result should equal an IList of uints: 1, 2, 3
  Then result should equal an IReadOnlyCollection of uints: 1, 2, 3
  Then result should equal an IReadOnlyList of uints: 1, 2, 3
  Then the result should equal list of uints: 1, 2, 3
  Then result should be equivalent to list of uints '2', '3', '1'
  Then result should contain list of uints "1", "3"
  Then result should not be an ICollection of uints '5', '6', '7'
  Then result should not be equal to an ICollection of uints: '5', '6', '7'
  Then result should not equal an ICollection of uints: '5', '6', '7'
  Then the result should not equal ICollection of uints: '5', '6', '7'
  Then result should not be equivalent to an ICollection of uints '5', '6', '7'
  Then result should not contain an ICollection of uints '5', '6', '7'

#@ignore
Scenario: Default, name
  Given uint 30000000
  Given expected is uint 30000000
  Given uint 30000000 as the target
  Given extraSmall is uint: 1
  Given uint 5 as small
  Given large as uint 40000000
  Given extraLarge is uint: 50000000
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
  Given array of uints "1, 2, 3"
  Given list of uints "1", "2", "3"
  Given expectedArray is array of uints "1, 2, 3"
  Given expectedEnumerable as enumerable of uints '1, 2, 3'
  Given expectedCollection is an ICollection of uints: 1, 2, 3
  Given expectedIList is an IList of uints: 1, 2, 3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of uints: 1, 2, 3
  Given expectedReadOnlyList is an IReadOnlyList of uints: 1, 2, 3
  Given the expectedList as a list of uints: 1, 2, 3
  Given list of uints "1", "3" as subset
  Given an ICollection of uints '30000000', '6', '7' as other
  Given the scrambled as IList of uints '2', '3', '1'
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

