@dynamicBindings
Feature: Generated datetimeoffsetOffset Bindings
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
  Given instance as "2000-01-02 0:0:1 04:00"
  Given a null array of datetimeoffset
  Given a null enumerable of datetimeoffset
  Given a null ICollection of datetimeoffset
  Given a null IList of datetimeoffset
  Given a null IReadOnlyCollection of datetimeoffset
  Given a null IReadOnlyList of datetimeoffset
  Given a null list of datetimeoffset
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of datetimeoffset
  Then the result should be a null enumerable of datetimeoffset
  Then the result should be a null ICollection of datetimeoffset
  Then the result should be a null IList of datetimeoffset
  Then the result should be a null IReadOnlyCollection of datetimeoffset
  Then the result should be a null IReadonlyList of datetimeoffset
  Then the result should be a null list of datetimeoffset
  Given collection is a list of "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given an array of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given an enumerable of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given an ICollection of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given an IList of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given an IReadOnlyCollection of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given an IReadOnlyList of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given a list of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Then collection should not be null
  Then the result should not be a null array of datetimeoffset
  Then the result should not be a null enumerable of datetimeoffset
  Then the result should not be a null ICollection of datetimeoffset
  Then the result should not be a null IList of datetimeoffset
  Then the result should not be a null IReadOnlyCollection of datetimeoffset
  Then the result should not be a null IReadonlyList of datetimeoffset
  Then the result should not be a null list of datetimeoffset

#@ignore
Scenario: Name, name
  Given actual is datetimeoffset "2000-01-02 0:0:6 04:00"
  Given expected as datetimeoffset '2000-01-02 0:0:6 04:00'
  Given datetimeoffset "2000-01-02 0:0:6 04:00" as the target
  Given extraSmall is datetimeoffset: 2000-01-01 0:0:0.100 -04:00
  Given datetimeoffset "2000-01-01 0:0:3 -04:00" as small
  Given large as datetimeoffset "2000-01-03 0:1:0 05:00"
  Given extraLarge is datetimeoffset: 2000-01-03 1:0:0 05:00
  Given regex is "\d"
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
  Then actual should match regex
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
  Given actual is enumerable of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given expectedArray is array of datetimeoffsets "2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00"
  Given expectedEnumerable as enumerable of datetimeoffsets '2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00'
  Given expectedCollection is an ICollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given expectedIList is an IList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given expectedReadOnlyCollection is an IReadOnlyCollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given expectedReadOnlyList is an IReadOnlyList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given the expectedList as a list of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given list of datetimeoffsets "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:3 04:00" as subset
  Given an ICollection of datetimeoffsets '2000-01-01 04:00', '2000-01-01 -04:00', '2000/01/01 0:0:7 04:00' as other
  Given the scrambled as IList of datetimeoffsets '2000-01-02 0:0:2 04:00', '2000-01-02 0:0:3 04:00', '2000-01-02 0:0:1 04:00'
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
  Given actual is datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be equal to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be equal to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then the actual should equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be equivalent to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should match "\D+"
  Then actual should be greater than datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should be less than datetimeoffset "2000-01-02 1:0:0 04:00"
  Then actual should be greater than or equal to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be greater than or equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be greater or equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should be greater or equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should be less than or equal to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be less than or equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then actual should be less or equal to datetimeoffset "2000-01-02 1:0:0 04:00"
  Then actual should be less or equal datetimeoffset "2000-01-02 1:0:0 04:00"
  Then actual should not be datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should not be equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should not equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then the actual should not equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should not be equivalent to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should not match "e.*"
  Then actual should not be greater than or equal to datetimeoffset "2000-01-02 1:0:0 04:00"
  Then actual should not be greater than or equal datetimeoffset "2000-01-02 1:0:0 04:00"
  Then actual should not be greater or equal to datetimeoffset "2000-01-02 1:0:0 04:00"
  Then actual should not be greater or equal datetimeoffset "2000-01-02 1:0:0 04:00"
  Then actual should not be less than or equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should not be less than or equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should not be less or equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then actual should not be less or equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Given actual is enumerable of datetimeoffset "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given other is list of datetimeoffsets "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Then actual should be enumerable of datetimeoffsets '2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00'
  Then other should be equal to array of datetimeoffsets "2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00"
  Then actual should equal ICollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then actual should equal an IList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then actual should equal an IReadOnlyCollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then actual should equal an IReadOnlyList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then the actual should equal list of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then actual should be equivalent to list of datetimeoffsets '2000-01-02 0:0:2 04:00', '2000-01-02 0:0:3 04:00', '2000-01-02 0:0:1 04:00'
  Then actual should contain list of datetimeoffsets "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:3 04:00"
  Then actual should not be an ICollection of datetimeoffsets '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then actual should not be equal to an ICollection of datetimeoffsets: '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then actual should not equal an ICollection of datetimeoffsets: '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then the actual should not equal ICollection of datetimeoffsets: '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then actual should not be equivalent to an ICollection of datetimeoffsets '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then actual should not contain an ICollection of datetimeoffsets '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'

#@ignore
Scenario: Default, value
  Given datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be equal to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then the result should equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be equivalent to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be greater than datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should be less than datetimeoffset "2000-01-02 1:0:0 04:00"
  Then result should be greater than or equal to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be greater than or equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be greater or equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should be greater or equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should be less than or equal to datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be less than or equal datetimeoffset "2000-01-02 0:0:6 04:00"
  Then result should be less or equal to datetimeoffset "2000-01-02 1:0:0 04:00"
  Then result should be less or equal datetimeoffset "2000-01-02 1:0:0 04:00"
  Given "2000-01-02 0:0:6 04:00"
  Then result should not be datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not be equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then the result should not equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not be equivalent to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not match datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not be greater than or equal to datetimeoffset "2000-01-02 1:0:0 04:00"
  Then result should not be greater than or equal datetimeoffset "2000-01-02 1:0:0 04:00"
  Then result should not be greater or equal to datetimeoffset "2000-01-02 1:0:0 04:00"
  Then result should not be greater or equal datetimeoffset "2000-01-02 1:0:0 04:00"
  Then result should not be less than or equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not be less than or equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not be less or equal to datetimeoffset "2000-01-02 0:0:5 04:00"
  Then result should not be less or equal datetimeoffset "2000-01-02 0:0:5 04:00"
  Given array of datetimeoffsets "2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00"
  Given enumerable of datetimeoffsets '2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00'
  Given an ICollection of datetimeoffsets "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given an IList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00" as an IReadOnlyCollection of datetimeoffset
  Given "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00" as an IReadOnlyList of datetimeoffsets
  # Defaults to List<T>
  Given '2000-01-02 0:0:1 04:00', '2000-01-02 0:0:2 04:00', '2000-01-02 0:0:3 04:00'
  Then result should be datetimeoffsets "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Then result should be enumerable of datetimeoffsets '2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00'
  Then result should be equal to array of datetimeoffsets "2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00"
  Then result should equal ICollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then result should equal an IList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then result should equal an IReadOnlyCollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then result should equal an IReadOnlyList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then the result should equal list of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Then result should be equivalent to list of datetimeoffsets '2000-01-02 0:0:2 04:00', '2000-01-02 0:0:3 04:00', '2000-01-02 0:0:1 04:00'
  Then result should contain list of datetimeoffsets "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:3 04:00"
  Then result should not be an ICollection of datetimeoffsets '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then result should not be equal to an ICollection of datetimeoffsets: '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then result should not equal an ICollection of datetimeoffsets: '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then the result should not equal ICollection of datetimeoffsets: '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then result should not be equivalent to an ICollection of datetimeoffsets '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'
  Then result should not contain an ICollection of datetimeoffsets '2000-01-02 0:0:5 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00'

#@ignore
Scenario: Default, name
  Given datetimeoffset "2000-01-02 0:0:6 04:00"
  Given expected is datetimeoffset "2000-01-02 0:0:6 04:00"
  Given datetimeoffset "2000-01-02 0:0:6 04:00" as the target
  Given extraSmall is datetimeoffset: 2000-01-01 0:0:1 04:00
  Given datetimeoffset "2000-01-01 0:0:3 04:00" as small
  Given large as datetimeoffset "2000-01-03 0:1:0 04:00"
  Given extraLarge is datetimeoffset: 2000-01-03 1:0:0 04:00
  Then result should be expected
  Then result should be equal to expected
  Then result should equal expected
  Then the result should equal expected
  Then result should be equivalent to expected
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
  Given array of datetimeoffsets "2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00"
  # Defaults to List<T>
  Given "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:2 04:00", "2000-01-02 0:0:3 04:00"
  Given expectedArray is array of datetimeoffsets "2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00"
  Given expectedEnumerable as enumerable of datetimeoffsets '2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00'
  Given expectedCollection is an ICollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given expectedIList is an IList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given expectedReadOnlyCollection is an IReadOnlyCollection of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given expectedReadOnlyList is an IReadOnlyList of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given the expectedList as a list of datetimeoffsets: 2000-01-02 0:0:1 04:00, 2000-01-02 0:0:2 04:00, 2000-01-02 0:0:3 04:00
  Given list of datetimeoffsets "2000-01-02 0:0:1 04:00", "2000-01-02 0:0:3 04:00" as subset
  Given an ICollection of datetimeoffsets '2000-01-04 04:00', '2000-01-02 0:0:6 04:00', '2000-01-02 0:0:7 04:00' as other
  Given the scrambled as IList of datetimeoffsets '2000-01-02 0:0:2 04:00', '2000-01-02 0:0:3 04:00', '2000-01-02 0:0:1 04:00'
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

