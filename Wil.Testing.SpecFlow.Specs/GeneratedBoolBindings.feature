@dynamicBindings
Feature: Generated Bool Bindings
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
  Given instance as "true"
  Given a null array of bool
  Given a null enumerable of bool
  Given a null ICollection of bool
  Given a null IList of bool
  Given a null IReadOnlyCollection of bool
  Given a null IReadOnlyList of bool
  Given a null list of bool
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of bool
  Then the result should be a null enumerable of bool
  Then the result should be a null ICollection of bool
  Then the result should be a null IList of bool
  Then the result should be a null IReadOnlyCollection of bool
  Then the result should be a null IReadonlyList of bool
  Then the result should be a null list of bool
  Given collection is a list of true, false
  Given an array of bool true, false
  Given an enumerable of bool true, false
  Given an ICollection of bool true, false
  Given an IList of bool true, false
  Given an IReadOnlyCollection of bool true, false
  Given an IReadOnlyList of bool true, false
  Given a list of bool true, false
  Then collection should not be null
  Then the result should not be a null array of bool
  Then the result should not be a null enumerable of bool
  Then the result should not be a null ICollection of bool
  Then the result should not be a null IList of bool
  Then the result should not be a null IReadOnlyCollection of bool
  Then the result should not be a null IReadonlyList of bool
  Then the result should not be a null list of bool

#@ignore
Scenario: Name, name
  Given actual is bool "true"
  Given expected is bool 'true'
  Given bool "true" as the target
  Given bool "false" as small
  Given large as bool "true"
  Then actual should be expected
  Then actual should be equal to expected
  Then actual should equal expected
  Then the actual should equal expected
  Then actual should be equivalent to expected
  Then large should be greater than small
  Then small should be less than large
  Then actual should be greater than or equal to target
  Then actual should be greater than or equal target
  Then actual should be greater or equal to small
  Then actual should be greater or equal small
  Then actual should be less than or equal to target
  Then actual should be less than or equal target
  Then actual should be less or equal to large
  Then actual should be less or equal large
  Then actual should not be small
  Then actual should not be equal to small
  Then actual should not equal small
  Then actual should match expected
  Then the actual should not equal small
  Then actual should not be equivalent to small
  Then small should not be greater than or equal to large
  Then small should not be greater than or equal large
  Then small should not be greater or equal to large
  Then large should not be less or equal to small
  Then large should not be less or equal small
  Then large should not match small
  Given actual is enumerable of bool true, false
  Given expectedArray is array of "true, false"
  Given expectedEnumerable as enumerable of 'true, false'
  Given expectedCollection is an ICollection of bools: true, false
  Given expectedIList is an IList of: true, false
  Given expectedReadOnlyCollection is an IReadOnlyCollection of: true, false
  Given expectedReadOnlyList is an IReadOnlyList of: true, false
  Given the expectedList as a list of bools: true, false
  Given list of bools "true" as subset
  Given an ICollection of bools 'false', 'true' as other
  Given the scrambled as IList of 'false', 'true'
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

#@ignore
Scenario: Name, value
  Given actual is bool "true"
  Then actual should be true
  Then actual should be equal to true
  Then actual should be equal to bool true
  Then actual should equal true
  Then the actual should equal true
  Then actual should be equivalent to true
  Then actual should match "T"
  Then actual should be greater than false
  Then actual should be greater than or equal to true
  Then actual should be greater than or equal true
  Then actual should be greater or equal to true
  Then actual should be greater or equal true
  Given actual is bool "false"
  Then actual should be less than "true"
  Then actual should be less than or equal to "true"
  Then actual should be less than or equal "true"
  Then actual should be less or equal to "true"
  Then actual should be less or equal "true"
  Then actual should not be "true"
  Then actual should not be equal to "true"
  Then actual should not equal "true"
  Then the actual should not equal "true"
  Then actual should not be equivalent to "true"
  Then actual should not match "t.*"
  Then actual should not be greater than or equal to "true"
  Then actual should not be greater than or equal "true"
  Then actual should not be greater or equal to "true"
  Then actual should not be greater or equal "true"
  Given actual is bool "true"
  Then actual should not be less than or equal to "false"
  Then actual should not be less than or equal "false"
  Then actual should not be less or equal to "false"
  Then actual should not be less or equal "false"
  Given actual is enumerable of bool true, false
  Given other is booleans "true", "false"
  Then actual should be enumerable of bools 'true, false'
  Then other should be equal to array of bools "true, false"
  Then actual should equal ICollection of bools: true, false
  Then actual should equal an IList of bools: true, false
  Then actual should equal an IReadOnlyCollection of bools: true, false
  Then actual should equal an IReadOnlyList of: true, false
  Then the actual should equal list of bools: true, false
  Then actual should be equivalent to 'false', 'true'
  Then actual should contain enumerable of bools "true"
  Then actual should not be an ICollection of bools 'true'
  Then actual should not be equal to an ICollection of bools: true
  Then actual should not equal an ICollection of bools: true
  Then the actual should not equal ICollection of bools: true
  Then actual should not be equivalent to an ICollection of bools 'true'

#@ignore
Scenario: Default, value
  Given true
  Then result should be bool "true"
  Then result should be equal to bool "true"
  Then result should equal bool "true"
  Then the result should equal bool "true"
  Then result should be equivalent to bool "true"
  Then result should match bool "true"
  Given "true" as bool
  Then result should be greater than bool "false"
  Then result should be greater than or equal to bool "false"
  Then result should be greater than or equal bool "false"
  Then result should be greater or equal to bool "false"
  Then result should be greater or equal bool "true"
  Given "false" as a bool
  Then result should be less than bool "true"
  Then result should be less than or equal to bool "true"
  Then result should be less than or equal bool "true"
  Then result should be less or equal to bool "true"
  Then result should be less or equal bool "true"
  Then result should not be bool "true"
  Then result should not be equal to bool "true"
  Then result should not equal bool "true"
  Then the result should not equal bool "true"
  Then result should not be equivalent to bool "true"
  Then result should not match bool "true"
  Then result should not be greater than or equal to bool "true"
  Then result should not be greater than or equal bool "true"
  Then result should not be greater or equal to "true"
  Then result should not be greater or equal "true"
  Given "true" as a bool
  Then result should not be less than or equal to "false"
  Then result should not be less than or equal "false"
  Then result should not be less or equal to "false"
  Then result should not be less or equal "false"
  Given array of true, false
  Given enumerable of 'true, false'
  Given an ICollection of bools true, false
  Given an IList of: true, false
  Given true, false as an IReadOnlyCollection of bool
  Given "true", "false" as an IReadOnlyList
  # Defaults to List<T>
  Given true, false
  Then result should be "true", "false"
  Then result should be enumerable of 'true, false'
  Then result should be equal to array of "true, false"
  Then result should equal ICollection of: true, false
  Then result should equal an IList of: true, false
  Then result should equal an IReadOnlyCollection of: true, false
  Then result should equal an IReadOnlyList of: true, false
  Then the result should equal list of bools: true, false
  Then result should be equivalent to 'false', 'true'
  Then result should contain list of bools "true"
  Then result should not be an ICollection of bools 'true'
  Then result should not be equal to an ICollection of bools: true
  Then result should not equal an ICollection of: true
  Then the result should not equal ICollection of: true
  Then result should not be equivalent to an ICollection of bools 'true'

#@ignore
Scenario: Default, name
  Given "true"
  Given expected is true
  Given bool true as the target
  Given false as small
  Given large true
  Then result should be expected
  Then result should be equal to expected
  Then result should equal expected
  Then the result should equal expected
  Then result should be equivalent to expected
  Then result should match expected
  Then result should be greater than small
  Then result should be greater than or equal to target
  Then result should be greater than or equal target
  Then result should be greater or equal to small
  Then result should be greater or equal small
  Given false
  Then result should be less than large
  Then result should be less than or equal to target
  Then result should be less than or equal target
  Then result should be less or equal to large
  Then result should be less or equal large
  Then result should not be large
  Then result should not be equal to large
  Then result should not equal large
  Then the result should not equal large
  Then result should not be equivalent to large
  Then result should not match large
  Then result should not be greater than or equal to large
  Then result should not be greater than or equal large
  Then result should not be greater or equal to large
  Then result should not be greater or equal large
  Given bool "true"
  Then result should not be less than or equal to small
  Then result should not be less than or equal small
  Then result should not be less or equal to small
  Then result should not be less or equal small
  Given array of "true, false"
  # Defaults to List<T>
  Given "true", "false"
  Given expectedArray is array of "true, false"
  Given expectedEnumerable as enumerable of 'true, false'
  Given expectedCollection is an ICollection of bools: true, false
  Given expectedIList is an IList of: true, false
  Given expectedReadOnlyCollection is an IReadOnlyCollection of: true, false
  Given expectedReadOnlyList is an IReadOnlyList of: true, false
  Given the expectedList as a list of bools: true, false
  Given list of booleans "true" as subset
  Given an ICollection of bools 'true' as other
  Given the scrambled as IList of 'false', 'true'
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

