@dynamicBindings
Feature: Generated Decimal Bindings
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
  Given a null array of decimal
  Given a null enumerable of decimal
  Given a null ICollection of decimal
  Given a null IList of decimal
  Given a null IReadOnlyCollection of decimal
  Given a null IReadOnlyList of decimal
  Given a null list of decimal
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of decimal
  Then the result should be a null enumerable of decimal
  Then the result should be a null ICollection of decimal
  Then the result should be a null IList of decimal
  Then the result should be a null IReadOnlyCollection of decimal
  Then the result should be a null IReadonlyList of decimal
  Then the result should be a null list of decimal
  Given collection is a list of 1, 2.5, 3.5
  Given an array of decimal 1, 2.5, 3.5
  Given an enumerable of decimal 1, 2.5, 3.5
  Given an ICollection of decimal 1, 2.5, 3.5
  Given an IList of decimal 1, 2.5, 3.5
  Given an IReadOnlyCollection of decimal 1, 2.5, 3.5
  Given an IReadOnlyList of decimal 1, 2.5, 3.5
  Given a list of decimal 1, 2.5, 3.5
  Then collection should not be null
  Then the result should not be a null array of decimal
  Then the result should not be a null enumerable of decimal
  Then the result should not be a null ICollection of decimal
  Then the result should not be a null IList of decimal
  Then the result should not be a null IReadOnlyCollection of decimal
  Then the result should not be a null IReadonlyList of decimal
  Then the result should not be a null list of decimal

#@ignore
Scenario: Name, name
  Given actual is decimal 10.2
  Given expected as decimal 10.2
  Given decimal 10.2 as the target
  Given extraSmall is decimal: 1.0
  Given decimal 5.0 as small
  Given large as decimal 100.0
  Given extraLarge as decimal: 1000.0
  Given the temp is decimal 4.0
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
  Given actual is enumerable of decimal 1, 2.5, 3.5
  Given expectedArray is array of decimals "1, 2.5, 3.5"
  Given expectedEnumerable as enumerable of decimals '1, 2.5, 3.5'
  Given expectedCollection is an ICollection of decimals: 1, 2.5, 3.5
  Given expectedIList is an IList of decimals: 1, 2.5, 3.5
  Given expectedReadOnlyCollection is an IReadOnlyCollection of decimals: 1, 2.5, 3.5
  Given expectedReadOnlyList is an IReadOnlyList of decimals: 1, 2.5, 3.5
  Given the expectedList as a list of decimals: 1, 2.5, 3.5
  Given list of decimals "1", "3.5" as subset
  Given an ICollection of decimals '5', '6', '7' as other
  Given the scrambled as IList of decimals '2.5', '3.5', '1'
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
  Given actual is decimal 10.2
  Then actual should be 10.2
  Then actual should be equal to 10.2
  Then actual should be equal to decimal 10.2
  Then actual should equal 10.2
  Then the actual should equal 10.2
  Then actual should be equivalent to 10.2
  Then actual should match "\d\d"
  Then actual should be greater than 5.0
  Then actual should be less than 100.0
  Then actual should be greater than or equal to 10.2
  Then actual should be greater than or equal 10.2
  Then actual should be greater or equal to 5.0
  Then actual should be greater or equal 5.0
  Then actual should be less than or equal to 10.2
  Then actual should be less than or equal 10.2
  Then actual should be less or equal to 100.0
  Then actual should be less or equal 100.0
  Then actual should not be 5.0
  Then actual should not be equal to 5.0
  Then actual should not equal 5.0
  Then the actual should not equal 5.0
  Then actual should not be equivalent to 5.0
  Then actual should not match "\d\d\d"
  Then actual should not be greater than or equal to 100.0
  Then actual should not be greater than or equal 100.0
  Then actual should not be greater or equal to 100.0
  Then actual should not be greater or equal 100.0
  Then actual should not be less than or equal to 5.0
  Then actual should not be less than or equal 5.0
  Then actual should not be less or equal to 5.0
  Then actual should not be less or equal 5.0
  Given actual is enumerable of decimal 1, 2.5, 3.5
  Given other is list of decimals "1", "2.5", "3.5"
  Then actual should be enumerable of decimals '1, 2.5, 3.5'
  Then other should be equal to array of decimals "1, 2.5, 3.5"
  Then actual should equal ICollection of decimals: 1, 2.5, 3.5
  Then actual should equal an IList of decimals: 1, 2.5, 3.5
  Then actual should equal an IReadOnlyCollection of decimals: 1, 2.5, 3.5
  Then actual should equal an IReadOnlyList of decimals: 1, 2.5, 3.5
  Then the actual should equal list of decimals: 1, 2.5, 3.5
  Then actual should be equivalent to list of decimals '2.5', '3.5', '1'
  Then actual should contain list of decimals "1", "3.5"
  Then actual should not be an ICollection of decimals '5', '6', '7'
  Then actual should not be equal to an ICollection of decimals: '5', '6', '7'
  Then actual should not equal an ICollection of decimals: '5', '6', '7'
  Then the actual should not equal ICollection of: '5', '6', '7'
  Then actual should not be equivalent to an ICollection of decimals '5', '6', '7'
  Then actual should not contain an ICollection of decimals '5', '6', '7'

#@ignore
Scenario: Default, value
  Given decimal 10.2
  Then result should be decimal 10.2
  Then result should be equal to decimal 10.2
  Then result should equal decimal 10.2
  Then the result should equal decimal 10.2
  Then result should be equivalent to decimal 10.2
  Then result should match decimal 10.2
  Then result should be greater than decimal 5.0
  Then result should be less than decimal 100.0
  Then result should be greater than or equal to decimal 10.2
  Then result should be greater than or equal decimal 10.2
  Then result should be greater or equal to decimal 5.0
  Then result should be greater or equal decimal 5.0
  Then result should be less than or equal to decimal 10.2
  Then result should be less than or equal decimal 10.2
  Then result should be less or equal to decimal 100.0
  Then result should be less or equal decimal 100.0
  Given 10.2 as a decimal
  Then result should not be decimal 5.0
  Then result should not be equal to decimal 5.0
  Then result should not equal decimal 5.0
  Then the result should not equal decimal 5.0
  Then result should not be equivalent to decimal 5.0
  Then result should not match decimal 5.0
  Then result should not be greater than or equal to decimal 100.0
  Then result should not be greater than or equal decimal 100.0
  Then result should not be greater or equal to decimal 100.0
  Then result should not be greater or equal decimal 100.0
  Then result should not be less than or equal to decimal 5.0
  Then result should not be less than or equal decimal 5.0
  Then result should not be less or equal to decimal 5.0
  Then result should not be less or equal decimal 5.0
  Given array of decimals "1, 2.5, 3.5"
  Given enumerable of decimals '1, 2.5, 3.5'
  Given an ICollection of decimals 1, 2.5, 3.5
  Given an IList of decimals: 1, 2.5, 3.5
  Given 1, 2.5, 3.5 as an IReadOnlyCollection of decimal
  Given "1", "2.5", "3.5" as an IReadOnlyList of decimals
  # Defaults to List<T>
  Given decimals '1', '2.5', '3.5'
  Then result should be decimals "1", "2.5", "3.5"
  Then result should be enumerable of decimals '1, 2.5, 3.5'
  Then result should be equal to array of decimals "1, 2.5, 3.5"
  Then result should equal ICollection of decimals: 1, 2.5, 3.5
  Then result should equal an IList of decimals: 1, 2.5, 3.5
  Then result should equal an IReadOnlyCollection of decimals: 1, 2.5, 3.5
  Then result should equal an IReadOnlyList of decimals: 1, 2.5, 3.5
  Then the result should equal list of decimals: 1, 2.5, 3.5
  Then result should be equivalent to list of decimals '2.5', '3.5', '1'
  Then result should contain list of decimals "1", "3.5"
  Then result should not be an ICollection of decimals '5.0', '6', '7'
  Then result should not be equal to an ICollection of decimals: '5.0', '6', '7'
  Then result should not equal an ICollection of decimals: '5.0', '6', '7'
  Then the result should not equal ICollection of decimals: '5.0', '6', '7'
  Then result should not be equivalent to an ICollection of decimals '5.0', '6', '7'
  Then result should not contain an ICollection of decimals '5.0', '6', '7'

#@ignore
Scenario: Default, name
  Given decimal 10.2
  Given expected is decimal 10.2
  Given decimal 10.2 as the target
  Given extraSmall is decimal: 1.0
  Given decimal 5.0 as small
  Given large as decimal 100.0
  Given extraLarge as decimal: 1000.0
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
  Given array of decimals "1, 2.5, 3.5"
  Given list of decimals "1", "2.5", "3.5"
  Given expectedArray is array of decimals "1, 2.5, 3.5"
  Given expectedEnumerable as enumerable of decimals '1, 2.5, 3.5'
  Given expectedCollection is an ICollection of decimals: 1, 2.5, 3.5
  Given expectedIList is an IList of decimals: 1, 2.5, 3.5
  Given expectedReadOnlyCollection is an IReadOnlyCollection of decimals: 1, 2.5, 3.5
  Given expectedReadOnlyList is an IReadOnlyList of decimals: 1, 2.5, 3.5
  Given the expectedList as a list of decimals: 1, 2.5, 3.5
  Given list of decimals "1", "3.5" as subset
  Given an ICollection of decimals '5', '6', '7' as other
  Given the scrambled as IList of decimals '2.5', '3.5', '1'
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

