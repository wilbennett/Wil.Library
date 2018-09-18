@dynamicBindings
Feature: Generated TimeSpan Bindings
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
  Given a null array of timespan
  Given a null enumerable of timespan
  Given a null ICollection of timespan
  Given a null IList of timespan
  Given a null IReadOnlyCollection of timespan
  Given a null IReadOnlyList of timespan
  Given a null list of timespan
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of timespan
  Then the result should be a null enumerable of timespan
  Then the result should be a null ICollection of timespan
  Then the result should be a null IList of timespan
  Then the result should be a null IReadOnlyCollection of timespan
  Then the result should be a null IReadonlyList of timespan
  Then the result should be a null list of timespan
  Given collection is a list of 0:0:1, 0:0:2, 0:0:3
  Given an array of timespan 0:0:1, 0:0:2, 0:0:3
  Given an enumerable of timespan 0:0:1, 0:0:2, 0:0:3
  Given an ICollection of timespan 0:0:1, 0:0:2, 0:0:3
  Given an IList of timespan 0:0:1, 0:0:2, 0:0:3
  Given an IReadOnlyCollection of timespan 0:0:1, 0:0:2, 0:0:3
  Given an IReadOnlyList of timespan 0:0:1, 0:0:2, 0:0:3
  Given a list of timespan 0:0:1, 0:0:2, 0:0:3
  Then collection should not be null
  Then the result should not be a null array of timespan
  Then the result should not be a null enumerable of timespan
  Then the result should not be a null ICollection of timespan
  Then the result should not be a null IList of timespan
  Then the result should not be a null IReadOnlyCollection of timespan
  Then the result should not be a null IReadonlyList of timespan
  Then the result should not be a null list of timespan

#@ignore
Scenario: Name, name
  Given actual is timespan "0:0:6"
  Given expected as timespan '0:0:6'
  Given timespan "0:0:6" as the target
  Given extraSmall is timespan: 0:0:0.100
  Given timespan "0:0:3" as small
  Given large as timespan "0:1:0"
  Given extraLarge is timespan: 1:0:0
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
  Given actual is enumerable of timespan 0:0:1, 0:0:2, 0:0:3
  Given expectedArray is array of timespans "0:0:1, 0:0:2, 0:0:3"
  Given expectedEnumerable as enumerable of timespans '0:0:1, 0:0:2, 0:0:3'
  Given expectedCollection is an ICollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Given expectedIList is an IList of timespans: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyList is an IReadOnlyList of timespans: 0:0:1, 0:0:2, 0:0:3
  Given the expectedList as a list of timespans: 0:0:1, 0:0:2, 0:0:3
  Given list of timespans "0:0:1", "0:0:3" as subset
  Given an ICollection of timespans '0:0:5', '0:0:6', '0:0:7' as other
  Given the scrambled as IList of timespans '0:0:2', '0:0:3', '0:0:1'
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
  Given actual is timespan "0:0:6"
  Then actual should be timespan "0:0:6"
  Then actual should be equal to timespan "0:0:6"
  Then actual should be equal to timespan "0:0:6"
  Then actual should equal timespan "0:0:6"
  Then the actual should equal timespan "0:0:6"
  Then actual should be equivalent to timespan "0:0:6"
  Then actual should match "\D+"
  Then actual should be greater than timespan "0:0:5"
  Then actual should be less than timespan "1:0:0"
  Then actual should be greater than or equal to timespan "0:0:6"
  Then actual should be greater than or equal timespan "0:0:6"
  Then actual should be greater or equal to timespan "0:0:5"
  Then actual should be greater or equal timespan "0:0:5"
  Then actual should be less than or equal to timespan "0:0:6"
  Then actual should be less than or equal timespan "0:0:6"
  Then actual should be less or equal to timespan "1:0:0"
  Then actual should be less or equal timespan "1:0:0"
  Then actual should not be timespan "0:0:5"
  Then actual should not be equal to timespan "0:0:5"
  Then actual should not equal timespan "0:0:5"
  Then the actual should not equal timespan "0:0:5"
  Then actual should not be equivalent to timespan "0:0:5"
  Then actual should not match "e.*"
  Then actual should not be greater than or equal to timespan "1:0:0"
  Then actual should not be greater than or equal timespan "1:0:0"
  Then actual should not be greater or equal to timespan "1:0:0"
  Then actual should not be greater or equal timespan "1:0:0"
  Then actual should not be less than or equal to timespan "0:0:5"
  Then actual should not be less than or equal timespan "0:0:5"
  Then actual should not be less or equal to timespan "0:0:5"
  Then actual should not be less or equal timespan "0:0:5"
  Given actual is enumerable of timespan 0:0:1, 0:0:2, 0:0:3
  Given other is list of timespans "0:0:1", "0:0:2", "0:0:3"
  Then actual should be enumerable of timespans '0:0:1, 0:0:2, 0:0:3'
  Then other should be equal to array of timespans "0:0:1, 0:0:2, 0:0:3"
  Then actual should equal ICollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Then actual should equal an IList of timespans: 0:0:1, 0:0:2, 0:0:3
  Then actual should equal an IReadOnlyCollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Then actual should equal an IReadOnlyList of timespans: 0:0:1, 0:0:2, 0:0:3
  Then the actual should equal list of timespans: 0:0:1, 0:0:2, 0:0:3
  Then actual should be equivalent to list of timespans '0:0:2', '0:0:3', '0:0:1'
  Then actual should contain list of timespans "0:0:1", "0:0:3"
  Then actual should not be an ICollection of timespans '0:0:5', '0:0:6', '0:0:7'
  Then actual should not be equal to an ICollection of timespans: '0:0:5', '0:0:6', '0:0:7'
  Then actual should not equal an ICollection of timespans: '0:0:5', '0:0:6', '0:0:7'
  Then the actual should not equal ICollection of timespans: '0:0:5', '0:0:6', '0:0:7'
  Then actual should not be equivalent to an ICollection of timespans '0:0:5', '0:0:6', '0:0:7'
  Then actual should not contain an ICollection of timespans '0:0:5', '0:0:6', '0:0:7'

#@ignore
Scenario: Default, value
  Given timespan "0:0:6"
  Then result should be timespan "0:0:6"
  Then result should be equal to timespan "0:0:6"
  Then result should equal timespan "0:0:6"
  Then the result should equal timespan "0:0:6"
  Then result should be equivalent to timespan "0:0:6"
  Then result should match timespan "0:0:6"
  Then result should be greater than timespan "0:0:5"
  Then result should be less than timespan "1:0:0"
  Then result should be greater than or equal to timespan "0:0:6"
  Then result should be greater than or equal timespan "0:0:6"
  Then result should be greater or equal to timespan "0:0:5"
  Then result should be greater or equal timespan "0:0:5"
  Then result should be less than or equal to timespan "0:0:6"
  Then result should be less than or equal timespan "0:0:6"
  Then result should be less or equal to timespan "1:0:0"
  Then result should be less or equal timespan "1:0:0"
  Given "0:0:6" as a timespan
  Then result should not be timespan "0:0:5"
  Then result should not be equal to timespan "0:0:5"
  Then result should not equal timespan "0:0:5"
  Then the result should not equal timespan "0:0:5"
  Then result should not be equivalent to timespan "0:0:5"
  Then result should not match timespan "0:0:5"
  Then result should not be greater than or equal to timespan "1:0:0"
  Then result should not be greater than or equal timespan "1:0:0"
  Then result should not be greater or equal to timespan "1:0:0"
  Then result should not be greater or equal timespan "1:0:0"
  Then result should not be less than or equal to timespan "0:0:5"
  Then result should not be less than or equal timespan "0:0:5"
  Then result should not be less or equal to timespan "0:0:5"
  Then result should not be less or equal timespan "0:0:5"
  Given array of timespans "0:0:1, 0:0:2, 0:0:3"
  Given enumerable of timespans '0:0:1, 0:0:2, 0:0:3'
  Given an ICollection of timespans 0:0:1, 0:0:2, 0:0:3
  Given an IList of timespans: 0:0:1, 0:0:2, 0:0:3
  Given 0:0:1, 0:0:2, 0:0:3 as an IReadOnlyCollection of timespan
  Given "0:0:1", "0:0:2", "0:0:3" as an IReadOnlyList of timespans
  # Defaults to List<T>
  Given timespans '0:0:1', '0:0:2', '0:0:3'
  Then result should be timespans "0:0:1", "0:0:2", "0:0:3"
  Then result should be enumerable of timespans '0:0:1, 0:0:2, 0:0:3'
  Then result should be equal to array of timespans "0:0:1, 0:0:2, 0:0:3"
  Then result should equal ICollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Then result should equal an IList of timespans: 0:0:1, 0:0:2, 0:0:3
  Then result should equal an IReadOnlyCollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Then result should equal an IReadOnlyList of timespans: 0:0:1, 0:0:2, 0:0:3
  Then the result should equal list of timespans: 0:0:1, 0:0:2, 0:0:3
  Then result should be equivalent to list of timespans '0:0:2', '0:0:3', '0:0:1'
  Then result should contain list of timespans "0:0:1", "0:0:3"
  Then result should not be an ICollection of timespans '0:0:5', '0:0:6', '0:0:7'
  Then result should not be equal to an ICollection of timespans: '0:0:5', '0:0:6', '0:0:7'
  Then result should not equal an ICollection of timespans: '0:0:5', '0:0:6', '0:0:7'
  Then the result should not equal ICollection of timespans: '0:0:5', '0:0:6', '0:0:7'
  Then result should not be equivalent to an ICollection of timespans '0:0:5', '0:0:6', '0:0:7'
  Then result should not contain an ICollection of timespans '0:0:5', '0:0:6', '0:0:7'

#@ignore
Scenario: Default, name
  Given timespan "0:0:6"
  Given expected is timespan "0:0:6"
  Given timespan "0:0:6" as the target
  Given extraSmall is timespan: 0:0:1
  Given timespan "0:0:3" as small
  Given large as timespan "0:1:0"
  Given extraLarge is timespan: 1:0:0
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
  Given array of timespans "0:0:1, 0:0:2, 0:0:3"
  Given list of timespans "0:0:1", "0:0:2", "0:0:3"
  Given expectedArray is array of timespans "0:0:1, 0:0:2, 0:0:3"
  Given expectedEnumerable as enumerable of timespans '0:0:1, 0:0:2, 0:0:3'
  Given expectedCollection is an ICollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Given expectedIList is an IList of timespans: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyCollection is an IReadOnlyCollection of timespans: 0:0:1, 0:0:2, 0:0:3
  Given expectedReadOnlyList is an IReadOnlyList of timespans: 0:0:1, 0:0:2, 0:0:3
  Given the expectedList as a list of timespans: 0:0:1, 0:0:2, 0:0:3
  Given list of timespans "0:0:1", "0:0:3" as subset
  Given an ICollection of timespans '0:0:5', '0:0:6', '0:0:7' as other
  Given the scrambled as IList of timespans '0:0:2', '0:0:3', '0:0:1'
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

