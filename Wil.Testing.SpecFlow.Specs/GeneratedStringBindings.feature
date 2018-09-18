@dynamicBindings
Feature: Generated String Bindings
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
  Given instance as "alpha"
  Given a null array of string
  Given a null enumerable of string
  Given a null ICollection of string
  Given a null IList of string
  Given a null IReadOnlyCollection of string
  Given a null IReadOnlyList of string
  Given a null list of string
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of string
  Then the result should be a null enumerable of string
  Then the result should be a null ICollection of string
  Then the result should be a null IList of string
  Then the result should be a null IReadOnlyCollection of string
  Then the result should be a null IReadonlyList of string
  Then the result should be a null list of string
  Given collection is a list of alpha, bravo, charlie
  Given an array of string alpha, bravo, charlie
  Given an enumerable of string alpha, bravo, charlie
  Given an ICollection of string alpha, bravo, charlie
  Given an IList of string alpha, bravo, charlie
  Given an IReadOnlyCollection of string alpha, bravo, charlie
  Given an IReadOnlyList of string alpha, bravo, charlie
  Given a list of string alpha, bravo, charlie
  Then collection should not be null
  Then the result should not be a null array of string
  Then the result should not be a null enumerable of string
  Then the result should not be a null ICollection of string
  Then the result should not be a null IList of string
  Then the result should not be a null IReadOnlyCollection of string
  Then the result should not be a null IReadonlyList of string
  Then the result should not be a null list of string

#@ignore
Scenario: Name, name
  Given actual is string "foxtrot"
  Given expected is 'foxtrot'
  Given string "foxtrot" as the target
  Given extraSmall is string: alpha
  Given "charlie" as small
  Given large "tango"
  Given extraLarge: zulu
  Given other "\\nother\t\"
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
  Then actual should not equal other
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
  Given actual is enumerable of string alpha, bravo, charlie
  Given expectedArray is array of "alpha, bravo, charlie"
  Given expectedEnumerable as enumerable of 'alpha, bravo, charlie'
  Given expectedCollection is an ICollection of strings: alpha, bravo, charlie
  Given expectedIList is an IList of: alpha, bravo, charlie
  Given expectedReadOnlyCollection is an IReadOnlyCollection of: alpha, bravo, charlie
  Given expectedReadOnlyList is an IReadOnlyList of: alpha, bravo, charlie
  Given the expectedList as a list of strings: alpha, bravo, charlie
  Given "alpha", "charlie" as subset
  Given an ICollection of strings 'echo', 'foxtrot', 'golf' as other
  Given the scrambled as IList of 'bravo', 'charlie', 'alpha'
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
  Given actual is string "foxtrot"
  Then actual should be "foxtrot"
  Then actual should be equal to "foxtrot"
  Then actual should be equal to string "foxtrot"
  Then actual should equal "foxtrot"
  Then the actual should equal "foxtrot"
  Then actual should be equivalent to "foxtrot"
  Then actual should match "\D+"
  Then actual should be greater than "echo"
  Then actual should be less than "zulu"
  Then actual should be greater than or equal to "foxtrot"
  Then actual should be greater than or equal "foxtrot"
  Then actual should be greater or equal to "echo"
  Then actual should be greater or equal "echo"
  Then actual should be less than or equal to "foxtrot"
  Then actual should be less than or equal "foxtrot"
  Then actual should be less or equal to "zulu"
  Then actual should be less or equal "zulu"
  Then actual should not be "echo"
  Then actual should not be equal to "echo"
  Then actual should not equal "echo"
  Then the actual should not equal "echo"
  Then actual should not be equivalent to "echo"
  Then actual should not match "e.*"
  Then actual should not be greater than or equal to "zulu"
  Then actual should not be greater than or equal "zulu"
  Then actual should not be greater or equal to "zulu"
  Then actual should not be greater or equal "zulu"
  Then actual should not be less than or equal to "echo"
  Then actual should not be less than or equal "echo"
  Then actual should not be less or equal to "echo"
  Then actual should not be less or equal "echo"
  Given actual is enumerable of string alpha, bravo, charlie
  Given other is "alpha", "bravo", "charlie"
  Then actual should be enumerable of 'alpha, bravo, charlie'
  Then other should be equal to array of "alpha, bravo, charlie"
  Then actual should equal ICollection of: alpha, bravo, charlie
  Then actual should equal an IList of: alpha, bravo, charlie
  Then actual should equal an IReadOnlyCollection of: alpha, bravo, charlie
  Then actual should equal an IReadOnlyList of: alpha, bravo, charlie
  Then the actual should equal list of strings: alpha, bravo, charlie
  Then actual should be equivalent to 'bravo', 'charlie', 'alpha'
  Then actual should contain "alpha", "charlie"
  Then actual should not be an ICollection of strings 'echo', 'foxtrot', 'golf'
  Then actual should not be equal to an ICollection of strings: 'echo', 'foxtrot', 'golf'
  Then actual should not equal an ICollection of: 'echo', 'foxtrot', 'golf'
  Then the actual should not equal ICollection of: 'echo', 'foxtrot', 'golf'
  Then actual should not be equivalent to an ICollection of strings 'echo', 'foxtrot', 'golf'
  Then actual should not contain an ICollection of strings 'echo', 'foxtrot', 'golf'

#@ignore
Scenario: Default, value
  Given string "foxtrot"
  Then result should be "foxtrot"
  Then result should be equal to "foxtrot"
  Then result should equal "foxtrot"
  Then the result should equal "foxtrot"
  Then result should be equivalent to "foxtrot"
  Then result should match "foxtrot"
  Given "foxtrot"
  Then result should be greater than "echo"
  Then result should be less than "zulu"
  Then result should be greater than or equal to "foxtrot"
  Then result should be greater than or equal "foxtrot"
  Then result should be greater or equal to "echo"
  Then result should be greater or equal "echo"
  Then result should be less than or equal to "foxtrot"
  Then result should be less than or equal "foxtrot"
  Then result should be less or equal to "zulu"
  Then result should be less or equal "zulu"
  Given "foxtrot" as a string
  Then result should not be "echo"
  Then result should not be equal to "echo"
  Then result should not equal "echo"
  Then the result should not equal "echo"
  Then result should not be equivalent to "echo"
  Then result should not match "echo"
  Then result should not be greater than or equal to "zulu"
  Then result should not be greater than or equal "zulu"
  Then result should not be greater or equal to "zulu"
  Then result should not be greater or equal "zulu"
  Then result should not be less than or equal to "echo"
  Then result should not be less than or equal "echo"
  Then result should not be less or equal to "echo"
  Then result should not be less or equal "echo"
  Given array of "alpha, bravo, charlie"
  Given enumerable of 'alpha, bravo, charlie'
  Given an ICollection of strings alpha, bravo, charlie
  Given an IList of: alpha, bravo, charlie
  Given alpha, bravo, charlie as an IReadOnlyCollection of string
  Given "alpha", "bravo", "charlie" as an IReadOnlyList
  # Defaults to List<T>
  Given 'alpha', 'bravo', 'charlie'
  Then result should be "alpha", "bravo", "charlie"
  Then result should be enumerable of 'alpha, bravo, charlie'
  Then result should be equal to array of "alpha, bravo, charlie"
  Then result should equal ICollection of: alpha, bravo, charlie
  Then result should equal an IList of: alpha, bravo, charlie
  Then result should equal an IReadOnlyCollection of: alpha, bravo, charlie
  Then result should equal an IReadOnlyList of: alpha, bravo, charlie
  Then the result should equal list of strings: alpha, bravo, charlie
  Then result should be equivalent to 'bravo', 'charlie', 'alpha'
  Then result should contain strings "alpha", "charlie"
  Then result should not be an ICollection of strings 'echo', 'foxtrot', 'golf'
  Then result should not be equal to an ICollection of strings: 'echo', 'foxtrot', 'golf'
  Then result should not equal an ICollection of: 'echo', 'foxtrot', 'golf'
  Then the result should not equal ICollection of: 'echo', 'foxtrot', 'golf'
  Then result should not be equivalent to an ICollection of strings 'echo', 'foxtrot', 'golf'
  Then result should not contain an ICollection of strings 'echo', 'foxtrot', 'golf'

#@ignore
Scenario: Default, name
  Given string "foxtrot"
  Given expected is "foxtrot"
  Given string "foxtrot" as the target
  Given extraSmall is string: alpha
  Given "charlie" as small
  Given large "tango"
  Given extraLarge: zulu
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
  Given array of "alpha, bravo, charlie"
  # Defaults to List<T>
  Given "alpha", "bravo", "charlie"
  Given expectedArray is array of "alpha, bravo, charlie"
  Given expectedEnumerable as enumerable of 'alpha, bravo, charlie'
  Given expectedCollection is an ICollection of strings: alpha, bravo, charlie
  Given expectedIList is an IList of: alpha, bravo, charlie
  Given expectedReadOnlyCollection is an IReadOnlyCollection of: alpha, bravo, charlie
  Given expectedReadOnlyList is an IReadOnlyList of: alpha, bravo, charlie
  Given the expectedList as a list of strings: alpha, bravo, charlie
  Given "alpha", "charlie" as subset
  Given an ICollection of strings 'echo', 'foxtrot', 'golf' as other
  Given the scrambled as IList of 'bravo', 'charlie', 'alpha'
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

