using System;
using System.Text.RegularExpressions;

namespace Wil.Testing.SpecFlow.Specs
{
    public struct Person : IEquatable<Person>
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            FullName = $"{FirstName} {LastName}";
            Nickname = string.Empty;
            Age = 0;
            Unregistered = null;
        }

        public Person(string nickname)
        {
            Nickname = nickname;

            FirstName = string.Empty;
            LastName = string.Empty;
            FullName = $"{FirstName} {LastName}";
            Age = 0;
            Unregistered = null;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Nickname { get; set; }
        public string FullName { get; }
        public int Age { get; set; }
        public UnregisteredType Unregistered { get; set; }

        public static Person Parse(string text)
        {
            Match match = Regex.Match(text, @"\((\w+)\s*:\s*(\w+)\)");

            if (!match.Success) throw new Exception($"Invalid person: {text}");

            var result = new Person(match.Groups[1].Value, match.Groups[2].Value);
            return result;
        }

        public override string ToString() => FullName;
        public bool Equals(Person other) => Equals(FirstName, other.FirstName) && Equals(LastName, other.LastName);
        public override bool Equals(object obj) => obj is Person p ? Equals(p) : base.Equals(obj);

        public string FormatWithId(int id) => $"{FullName} ({id})";
        public string FormatWithIdAndNickname(int id, string nickname) => $"{id}: {FullName} ({nickname})";
        public static Person CreateNew(string firstName, string lastName) => new Person(firstName, lastName);
        public override int GetHashCode() => FullName.GetHashCode();

        public class UnregisteredType
        {
        }
    }
}

