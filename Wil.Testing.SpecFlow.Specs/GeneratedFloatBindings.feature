@dynamicBindings
Feature: Generated Float Bindings
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
  Given a null array of float
  Given a null enumerable of float
  Given a null ICollection of float
  Given a null IList of float
  Given a null IReadOnlyCollection of float
  Given a null IReadOnlyList of float
  Given a null list of float
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of float
  Then the result should be a null enumerable of float
  Then the result should be a null ICollection of float
  Then the result should be a null IList of float
  Then the result should be a null IReadOnlyCollection of float
  Then the result should be a null IReadonlyList of float
  Then the result should be a null list of float
  Given collection is a list of 1, 2.5, 3.5
  Given an array of float 1, 2.5, 3.5
  Given an enumerable of float 1, 2.5, 3.5
  Given an ICollection of float 1, 2.5, 3.5
  Given an IList of float 1, 2.5, 3.5
  Given an IReadOnlyCollection of float 1, 2.5, 3.5
  Given an IReadOnlyList of float 1, 2.5, 3.5
  Given a list of float 1, 2.5, 3.5
  Then collection should not be null
  Then the result should not be a null array of float
  Then the result should not be a null enumerable of float
  Then the result should not be a null ICollection of float
  Then the result should not be a null IList of float
  Then the result should not be a null IReadOnlyCollection of float
  Then the result should not be a null IReadonlyList of float
  Then the result should not be a null list of float

#@ignore
Scenario: Name, name
  Given actual is float 10.2
  Given expected as float 10.2
  Given float 10.2 as the target
  Given extraSmall is float: 1.0
  Given float 5.0 as small
  Given large as float 100.0
  Given extraLarge as float: 1000.0
  Given the temp is float 4.0
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
  Given actual is enumerable of float 1, 2.5, 3.5
  Given expectedArray is array of floats "1, 2.5, 3.5"
  Given expectedEnumerable as enumerable of floats '1, 2.5, 3.5'
  Given expectedCollection is an ICollection of floats: 1, 2.5, 3.5
  Given expectedIList is an IList of floats: 1, 2.5, 3.5
  Given expectedReadOnlyCollection is an IReadOnlyCollection of floats: 1, 2.5, 3.5
  Given expectedReadOnlyList is an IReadOnlyList of floats: 1, 2.5, 3.5
  Given the expectedList as a list of floats: 1, 2.5, 3.5
  Given list of floats "1", "3.5" as subset
  Given an ICollection of floats '5', '6', '7' as other
  Given the scrambled as IList of floats '2.5', '3.5', '1'
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
  Given actual is float 10.2
  Then actual should be 10.2
  Then actual should be equal to 10.2
  Then actual should be equal to float 10.2
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
  Given actual is enumerable of float 1, 2.5, 3.5
  Given other is list of floats "1", "2.5", "3.5"
  Then actual should be enumerable of floats '1, 2.5, 3.5'
  Then other should be equal to array of floats "1, 2.5, 3.5"
  Then actual should equal ICollection of floats: 1, 2.5, 3.5
  Then actual should equal an IList of floats: 1, 2.5, 3.5
  Then actual should equal an IReadOnlyCollection of floats: 1, 2.5, 3.5
  Then actual should equal an IReadOnlyList of floats: 1, 2.5, 3.5
  Then the actual should equal list of floats: 1, 2.5, 3.5
  Then actual should be equivalent to list of floats '2.5', '3.5', '1'
  Then actual should contain list of floats "1", "3.5"
  Then actual should not be an ICollection of floats '5', '6', '7'
  Then actual should not be equal to an ICollection of floats: '5', '6', '7'
  Then actual should not equal an ICollection of floats: '5', '6', '7'
  Then the actual should not equal ICollection of: '5', '6', '7'
  Then actual should not be equivalent to an ICollection of floats '5', '6', '7'
  Then actual should not contain an ICollection of floats '5', '6', '7'

#@ignore
Scenario: Default, value
  Given float 10.2
  Then result should be float 10.2
  Then result should be equal to float 10.2
  Then result should equal float 10.2
  Then the result should equal float 10.2
  Then result should be equivalent to float 10.2
  Then result should match float 10.2
  Then result should be greater than float 5.0
  Then result should be less than float 100.0
  Then result should be greater than or equal to float 10.2
  Then result should be greater than or equal float 10.2
  Then result should be greater or equal to float 5.0
  Then result should be greater or equal float 5.0
  Then result should be less than or equal to float 10.2
  Then result should be less than or equal float 10.2
  Then result should be less or equal to float 100.0
  Then result should be less or equal float 100.0
  Given 10.2 as a float
  Then result should not be float 5.0
  Then result should not be equal to float 5.0
  Then result should not equal float 5.0
  Then the result should not equal float 5.0
  Then result should not be equivalent to float 5.0
  Then result should not match float 5.0
  Then result should not be greater than or equal to float 100.0
  Then result should not be greater than or equal float 100.0
  Then result should not be greater or equal to float 100.0
  Then result should not be greater or equal float 100.0
  Then result should not be less than or equal to float 5.0
  Then result should not be less than or equal float 5.0
  Then result should not be less or equal to float 5.0
  Then result should not be less or equal float 5.0
  Given array of floats "1, 2.5, 3.5"
  Given enumerable of floats '1, 2.5, 3.5'
  Given an ICollection of floats 1, 2.5, 3.5
  Given an IList of floats: 1, 2.5, 3.5
  Given 1, 2.5, 3.5 as an IReadOnlyCollection of float
  Given "1", "2.5", "3.5" as an IReadOnlyList of floats
  # Defaults to List<T>
  Given floats '1', '2.5', '3.5'
  Then result should be floats "1", "2.5", "3.5"
  Then result should be enumerable of floats '1, 2.5, 3.5'
  Then result should be equal to array of floats "1, 2.5, 3.5"
  Then result should equal ICollection of floats: 1, 2.5, 3.5
  Then result should equal an IList of floats: 1, 2.5, 3.5
  Then result should equal an IReadOnlyCollection of floats: 1, 2.5, 3.5
  Then result should equal an IReadOnlyList of floats: 1, 2.5, 3.5
  Then the result should equal list of floats: 1, 2.5, 3.5
  Then result should be equivalent to list of floats '2.5', '3.5', '1'
  Then result should contain list of floats "1", "3.5"
  Then result should not be an ICollection of floats '5.0', '6', '7'
  Then result should not be equal to an ICollection of floats: '5.0', '6', '7'
  Then result should not equal an ICollection of floats: '5.0', '6', '7'
  Then the result should not equal ICollection of floats: '5.0', '6', '7'
  Then result should not be equivalent to an ICollection of floats '5.0', '6', '7'
  Then result should not contain an ICollection of floats '5.0', '6', '7'

#@ignore
Scenario: Default, name
  Given float 10.2
  Given expected is float 10.2
  Given float 10.2 as the target
  Given extraSmall is float: 1.0
  Given float 5.0 as small
  Given large as float 100.0
  Given extraLarge as float: 1000.0
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
  Given array of floats "1, 2.5, 3.5"
  Given list of floats "1", "2.5", "3.5"
  Given expectedArray is array of floats "1, 2.5, 3.5"
  Given expectedEnumerable as enumerable of floats '1, 2.5, 3.5'
  Given expectedCollection is an ICollection of floats: 1, 2.5, 3.5
  Given expectedIList is an IList of floats: 1, 2.5, 3.5
  Given expectedReadOnlyCollection is an IReadOnlyCollection of floats: 1, 2.5, 3.5
  Given expectedReadOnlyList is an IReadOnlyList of floats: 1, 2.5, 3.5
  Given the expectedList as a list of floats: 1, 2.5, 3.5
  Given list of floats "1", "3.5" as subset
  Given an ICollection of floats '5', '6', '7' as other
  Given the scrambled as IList of floats '2.5', '3.5', '1'
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

