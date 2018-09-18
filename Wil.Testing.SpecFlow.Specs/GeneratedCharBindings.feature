@dynamicBindings
Feature: Generated Char Bindings
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
  Given instance as "a"
  Given a null array of char
  Given a null enumerable of char
  Given a null ICollection of char
  Given a null IList of char
  Given a null IReadOnlyCollection of char
  Given a null IReadOnlyList of char
  Given a null list of char
  Then actual should be expected
  Then actual should be equal to other
  Then actual should be goal
  Then actual should be null
  Then the result should be null
  Then instance should not be null
  Then the result should be a null array of char
  Then the result should be a null enumerable of char
  Then the result should be a null ICollection of char
  Then the result should be a null IList of char
  Then the result should be a null IReadOnlyCollection of char
  Then the result should be a null IReadonlyList of char
  Then the result should be a null list of char
  Given collection is a list of char a, b, c
  Given an array of char a, b, c
  Given an enumerable of char a, b, c
  Given an ICollection of char a, b, c
  Given an IList of char a, b, c
  Given an IReadOnlyCollection of char a, b, c
  Given an IReadOnlyList of char a, b, c
  Given a list of char a, b, c
  Then collection should not be null
  Then the result should not be a null array of char
  Then the result should not be a null enumerable of char
  Then the result should not be a null ICollection of char
  Then the result should not be a null IList of char
  Then the result should not be a null IReadOnlyCollection of char
  Then the result should not be a null IReadonlyList of char
  Then the result should not be a null list of char

#@ignore
Scenario: Name, name
  Given actual is char "f"
  Given expected is 'f'
  Given char "f" as the target
  Given extraSmall is char: a
  Given "c" as small
  Given large "t"
  Given extraLarge: z
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
  Given actual is enumerable of char a, b, c
  Given expectedArray is array of char "a, b, c"
  Given expectedEnumerable as enumerable of char 'a, b, c'
  Given expectedCollection is an ICollection of chars: a, b, c
  Given expectedIList is an IList of char: a, b, c
  Given expectedReadOnlyCollection is an IReadOnlyCollection of char: a, b, c
  Given expectedReadOnlyList is an IReadOnlyList of char: a, b, c
  Given the expectedList as a list of chars: a, b, c
  Given enumerable of chars "a", "c" as subset
  Given an ICollection of chars 'e', 'f', 'g' as other
  Given the scrambled as IList of char 'b', 'c', 'a'
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
  Given actual is char "f"
  Then actual should be "f"
  Then actual should be equal to "f"
  Then actual should be equal to char "f"
  Then actual should equal "f"
  Then the actual should equal "f"
  Then actual should be equivalent to "f"
  Then actual should match "\D+"
  Then actual should be greater than "e"
  Then actual should be less than "z"
  Then actual should be greater than or equal to "f"
  Then actual should be greater than or equal "f"
  Then actual should be greater or equal to "e"
  Then actual should be greater or equal "e"
  Then actual should be less than or equal to "f"
  Then actual should be less than or equal "f"
  Then actual should be less or equal to "z"
  Then actual should be less or equal "z"
  Then actual should not be "e"
  Then actual should not be equal to "e"
  Then actual should not equal "e"
  Then the actual should not equal "e"
  Then actual should not be equivalent to "e"
  Then actual should not match "e.*"
  Then actual should not be greater than or equal to "z"
  Then actual should not be greater than or equal "z"
  Then actual should not be greater or equal to "z"
  Then actual should not be greater or equal "z"
  Then actual should not be less than or equal to "e"
  Then actual should not be less than or equal "e"
  Then actual should not be less or equal to "e"
  Then actual should not be less or equal "e"
  Given actual is enumerable of char a, b, c
  Given other is list of chars "a", "b", "c"
  Then actual should be enumerable of chars 'a, b, c'
  Then other should be equal to array of chars "a, b, c"
  Then actual should equal ICollection of chars: a, b, c
  Then actual should equal an IList of chars: a, b, c
  Then actual should equal an IReadOnlyCollection of chars: a, b, c
  Then actual should equal an IReadOnlyList of chars: a, b, c
  Then the actual should equal list of chars: a, b, c
  Then actual should be equivalent to list of chars 'b', 'c', 'a'
  Then actual should contain list of chars "a", "c"
  Then actual should not be an ICollection of chars 'e', 'f', 'g'
  Then actual should not be equal to an ICollection of chars: 'e', 'f', 'g'
  Then actual should not equal an ICollection of chars: 'e', 'f', 'g'
  Then the actual should not equal ICollection of chars: 'e', 'f', 'g'
  Then actual should not be equivalent to an ICollection of chars 'e', 'f', 'g'
  Then actual should not contain an ICollection of chars 'e', 'f', 'g'

#@ignore
Scenario: Default, value
  Given char "f"
  Then result should be char "f"
  Then result should be equal to char "f"
  Then result should equal char "f"
  Then the result should equal char "f"
  Then result should be equivalent to char "f"
  Then result should match char "f"
  Then result should be greater than char "e"
  Then result should be less than char "z"
  Then result should be greater than or equal to char "f"
  Then result should be greater than or equal char "f"
  Then result should be greater or equal to char "e"
  Then result should be greater or equal char "e"
  Then result should be less than or equal to char "f"
  Then result should be less than or equal char "f"
  Then result should be less or equal to char "z"
  Then result should be less or equal char "z"
  Given "f" as a char
  Then result should not be char "e"
  Then result should not be equal to char "e"
  Then result should not equal char "e"
  Then the result should not equal char "e"
  Then result should not be equivalent to char "e"
  Then result should not match char "e"
  Then result should not be greater than or equal to char "z"
  Then result should not be greater than or equal char "z"
  Then result should not be greater or equal to char "z"
  Then result should not be greater or equal char "z"
  Then result should not be less than or equal to char "e"
  Then result should not be less than or equal char "e"
  Then result should not be less or equal to char "e"
  Then result should not be less or equal char "e"
  Given array of chars "a, b, c"
  Given enumerable of chars 'a, b, c'
  Given an ICollection of chars a, b, c
  Given an IList of chars: a, b, c
  Given a, b, c as an IReadOnlyCollection of char
  Given "a", "b", "c" as an IReadOnlyList of chars
  # Defaults to List<T>
  Given chars 'a', 'b', 'c'
  Then result should be chars "a", "b", "c"
  Then result should be enumerable of chars 'a, b, c'
  Then result should be equal to array of chars "a, b, c"
  Then result should equal ICollection of chars: a, b, c
  Then result should equal an IList of chars: a, b, c
  Then result should equal an IReadOnlyCollection of chars: a, b, c
  Then result should equal an IReadOnlyList of chars: a, b, c
  Then the result should equal list of chars: a, b, c
  Then result should be equivalent to list of chars 'b', 'c', 'a'
  Then result should contain list of chars "a", "c"
  Then result should not be an ICollection of chars 'e', 'f', 'g'
  Then result should not be equal to an ICollection of chars: 'e', 'f', 'g'
  Then result should not equal an ICollection of chars: 'e', 'f', 'g'
  Then the result should not equal ICollection of chars: 'e', 'f', 'g'
  Then result should not be equivalent to an ICollection of chars 'e', 'f', 'g'
  Then result should not contain an ICollection of chars 'e', 'f', 'g'

#@ignore
Scenario: Default, name
  Given char "f"
  Given expected is char "f"
  Given char "f" as the target
  Given extraSmall is char: a
  Given char "c" as small
  Given large as char "t"
  Given extraLarge is char: z
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
  Given array of chars "a, b, c"
  Given list of chars "a", "b", "c"
  Given expectedArray is array of chars "a, b, c"
  Given expectedEnumerable as enumerable of chars 'a, b, c'
  Given expectedCollection is an ICollection of chars: a, b, c
  Given expectedIList is an IList of chars: a, b, c
  Given expectedReadOnlyCollection is an IReadOnlyCollection of chars: a, b, c
  Given expectedReadOnlyList is an IReadOnlyList of chars: a, b, c
  Given the expectedList as a list of chars: a, b, c
  Given list of chars "a", "c" as subset
  Given an ICollection of chars 'e', 'f', 'g' as other
  Given the scrambled as IList of chars 'b', 'c', 'a'
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

