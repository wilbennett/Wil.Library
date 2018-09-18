using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Wil.Core
{
    public static class StringUtils
    {
        public const string SingleQuotedCommaField = @"(?:(?:\s*'(?<text>[^'\\]*(?:(?:\\|'').[^'\\]*)*)'\s*,?))";
        public const string DoubleQuotedCommaField = @"(?:(?:\s*""(?<text>[^""\\]*(?:(?:\\|"""").[^""\\]*)*)""\s*,?))";
        public const string SingleQuotedCommaString = @"(?:(?:\s*'[^'\\]*(?:(?:\\|'').[^'\\]*)*'\s*,)(?:\s*'[^'\\]*(?:(?:\\|'').[^'\\]*)*'\s*,?)*)";
        public const string DoubleQuotedCommaString = @"(?:(?:\s*""[^""\\]*(?:(?:\\|"""").[^""\\]*)*""\s*,)(?:\s*""[^""\\]*(?:(?:\\|"""").[^""\\]*)*""\s*,?)*)";

        public static string NullIfEmpty(this string text) => string.IsNullOrEmpty(text) ? null : text;
        public static string NullIfWhiteSpace(this string text) => string.IsNullOrWhiteSpace(text) ? null : text;

        public static string Clip(this string text, int length)
            => text == null || text.Length <= length ? text : text.Substring(0, length - 3) + "...";

        public static string Unescape(this string text)
        {
            if (text == null) return text;
            if (text.IndexOf('\\') < 0) return text;

            var result = new StringBuilder(text.Length);
            char ch = ' ';
            EscapeState state = EscapeState.Normal;

            for (int i = 0; i < text.Length; i++)
            {
                ch = text[i];

                switch (state)
                {
                    case EscapeState.Normal:
                        if (ch != '\\')
                            result.Append(ch);
                        else
                            state = EscapeState.Slash;
                        break;

                    case EscapeState.Slash:
                        if (ch == '\\')
                            result.Append(ch);
                        else
                        {
                            switch (ch)
                            {
                                case 'r': result.Append("\r"); break;
                                case 'n': result.Append("\n"); break;
                                case 't': result.Append("\t"); break;
                                default: result.Append("\\").Append(ch); break;
                            }
                        }

                        state = EscapeState.Normal;
                        break;
                }
            }

            if (state == EscapeState.Slash)
                result.Append(ch);

            return result.ToString();
        }

        // TODO: Add overloads to allow specifying delimiters and quote chars.

        #region Generics
        public static IEnumerable<T> ToEnumerable<T>(this string text, Func<string, T> parser)
            => Split(text, parser);

        public static bool TryConvertToEnumerable<T>(
            this string text,
            Func<string, T> parser,
            out IEnumerable<T> result)
        {
            try
            {
                result = ToEnumerable(text, parser).ToList();
                return true;
            }
            catch
            {
                result = Enumerable.Empty<T>();
                return false;
            }
        }

        public static IEnumerable<T> ToEnumerableOrDefault<T>(this string text, Func<string, T> parser)
        {
            IEnumerable<T> result;
            TryConvertToEnumerable(text, parser, out result);
            return result;
        }

        public static List<T> ToList<T>(this string text, Func<string, T> parser) => Split(text, parser).ToList();

        public static bool TryConvertToList<T>(this string text, Func<string, T> parser, out List<T> result)
        {
            try
            {
                result = ToList(text, parser);
                return true;
            }
            catch
            {
                result = Enumerable.Empty<T>().ToList();
                return false;
            }
        }

        public static List<T> ToListOrDefault<T>(this string text, Func<string, T> parser)
        {
            List<T> result;
            TryConvertToList(text, parser, out result);
            return result;
        }

        public static T[] ToArray<T>(this string text, Func<string, T> parser) => Split(text, parser).ToArray();

        public static bool TryConvertToArray<T>(this string text, Func<string, T> parser, out T[] result)
        {
            try
            {
                result = ToArray(text, parser);
                return true;
            }
            catch
            {
                result = Enumerable.Empty<T>().ToArray();
                return false;
            }
        }

        public static T[] ToArrayOrDefault<T>(this string text, Func<string, T> parser)
        {
            T[] result;
            TryConvertToArray(text, parser, out result);
            return result;
        }
        #endregion

        #region Type
        public static IEnumerable ToEnumerable(this string text, Type dataType) => Split(text, dataType);

        public static bool TryConvertToEnumerable(
            this string text,
            Type dataType,
            out IEnumerable result)
        {
            try
            {
                result = ToEnumerable(text, dataType);
                return true;
            }
            catch
            {
                result = Array.CreateInstance(dataType, 0);
                return false;
            }
        }

        public static IEnumerable ToEnumerableOrDefault(this string text, Type dataType)
        {
            IEnumerable result;
            TryConvertToEnumerable(text, dataType, out result);
            return result;
        }

        public static IList ToList(this string text, Type dataType)
            => dataType == typeof(char) ? SplitChars(text, dataType) : Split(text, dataType);

        public static bool TryConvertToList(this string text, Type dataType, out IList result)
        {
            try
            {
                result = ToList(text, dataType);
                return true;
            }
            catch
            {
                result = Array.CreateInstance(dataType, 0);
                return false;
            }
        }

        public static IList ToListOrDefault(this string text, Type dataType)
        {
            IList result;
            TryConvertToList(text, dataType, out result);
            return result;
        }

        public static Array ToArray(this string text, Type dataType) => SplitToArray(text, dataType);

        public static bool TryConvertToArray(this string text, Type dataType, out Array result)
        {
            try
            {
                result = ToArray(text, dataType);
                return true;
            }
            catch
            {
                result = Array.CreateInstance(dataType, 0);
                return false;
            }
        }

        public static Array ToArrayOrDefault(this string text, Type dataType)
        {
            Array result;
            TryConvertToArray(text, dataType, out result);
            return result;
        }
        #endregion

        public static IEnumerable<string> ToStrings(this string text) => Split(text);
        public static List<string> ToStringsList(this string text) => ToStrings(text).ToList();
        public static string[] ToStringsArray(this string text) => ToStrings(text).ToArray();

        public static IEnumerable<char> ToChars(this string text) => SplitChars(text);
        public static List<char> ToCharsList(this string text) => ToChars(text).ToList();
        public static char[] ToCharsArray(this string text) => ToChars(text).ToArray();

        public static IEnumerable<int> ToInts(this string text) => ToEnumerable(text, int.Parse);
        public static List<int> ToIntsList(this string text) => ToList(text, int.Parse);
        public static int[] ToIntsArray(this string text) => ToArray(text, int.Parse);

        public static IEnumerable<double> ToDoubles(this string text) => ToEnumerable(text, double.Parse);
        public static List<double> ToDoublesList(this string text) => ToList(text, double.Parse);
        public static double[] ToDoublesArray(this string text) => ToArray(text, double.Parse);

        public static IEnumerable<float> ToFloats(this string text) => ToEnumerable(text, float.Parse);
        public static List<float> ToFloatsList(this string text) => ToList(text, float.Parse);
        public static float[] ToFloatsArray(this string text) => ToArray(text, float.Parse);

        public static IEnumerable<byte> ToBytes(this string text) => ToEnumerable(text, byte.Parse);
        public static List<byte> ToBytesList(this string text) => ToList(text, byte.Parse);
        public static byte[] ToBytesArray(this string text) => ToArray(text, byte.Parse);

        public static IEnumerable<bool> ToBools(this string text) => ToEnumerable(text, bool.Parse);
        public static List<bool> ToBoolsList(this string text) => ToList(text, bool.Parse);
        public static bool[] ToBoolsArray(this string text) => ToArray(text, bool.Parse);

        public static double[,] ToMultiDimensionDouble(this string text)
        {
            string[] rows = Split(text, _multiArraySeparators).ToArray();
            int width = rows[0].ToStringsArray().Length;
            var result = new double[rows.Length, width];

            for (int r = 0; r < rows.Length; r++)
            {
                double[] row = rows[r].ToDoublesArray();

                for (int c = 0; c < width; c++)
                    result[r, c] = row[c];
            }

            return result;
        }

        public static float[,] ToMultiDimensionFloat(this string text)
        {
            string[] rows = Split(text, _multiArraySeparators).ToArray();
            int width = rows[0].ToStringsArray().Length;
            var result = new float[rows.Length, width];

            for (int r = 0; r < rows.Length; r++)
            {
                float[] row = rows[r].ToFloatsArray();

                for (int c = 0; c < width; c++)
                    result[r, c] = row[c];
            }

            return result;
        }

        public static double[][] ToJaggedDouble(this string text)
        {
            string[] rows = Split(text, _multiArraySeparators).ToArray();
            var result = new double[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
                result[i] = rows[i].ToDoublesArray();

            return result;
        }

        public static float[][] ToJaggedFloat(this string text)
        {
            string[] rows = Split(text, _multiArraySeparators).ToArray();
            var result = new float[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
                result[i] = rows[i].ToFloatsArray();

            return result;
        }

        public static byte[][] ToJaggedByte(this string text)
        {
            Console.WriteLine($"Converting: {text}");
            string[] rows = Split(text, _multiArraySeparators).ToArray();
            var result = new byte[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                Console.WriteLine($"Converting {i}: {string.Join(", ", rows[i])}");
                result[i] = rows[i].ToBytesArray();
            }

            return result;
        }

        public static char[][] ToJaggedChar(this string text)
        {
            string[] rows = Split(text, _multiArraySeparators).ToArray();
            var result = new char[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
                result[i] = rows[i].ToCharsArray();

            return result;
        }

        public static bool[][] ToJaggedBool(this string text)
        {
            string[] rows = Split(text, _multiArraySeparators).ToArray();
            var result = new bool[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
                result[i] = rows[i].ToBoolsArray();

            return result;
        }

        private static readonly char[] _defCharSeps = { ',' };
        private static readonly char[] _multiArraySeparators = { '[', ']' };

        private static readonly Regex _singleQuotedCommaFieldRegex = new Regex(SingleQuotedCommaField);
        private static readonly Regex _doubleQuotedCommaFieldRegex = new Regex(DoubleQuotedCommaField);
        private static readonly Regex _singleQuotedCommaRegex = new Regex(SingleQuotedCommaString);
        private static readonly Regex _doubleQuotedCommaRegex = new Regex(DoubleQuotedCommaString);

        private static IEnumerable<string> GetAsSimpleCommaSeparatedStrings(string text)
            => text.Split(',').Select(s => s.Trim());

        private static IEnumerable<string> GetStrings(string text, Regex regex)
        {
            Match match = regex.Match(text);

            while (match.Success)
            {
                yield return match.Groups["text"].Value;
                match = match.NextMatch();
            }
        }

        private static IEnumerable<string> Split(string text)
        {
            // TODO: Replace regular expressions with a parser.
            if (string.IsNullOrWhiteSpace(text))
                return Enumerable.Empty<string>();

            if (_singleQuotedCommaRegex.IsMatch(text))
                return GetStrings(text, _singleQuotedCommaFieldRegex);

            if (_doubleQuotedCommaRegex.IsMatch(text))
                return GetStrings(text, _doubleQuotedCommaFieldRegex);

            return GetAsSimpleCommaSeparatedStrings(text);
        }

        private static IEnumerable<string> Split(string text, char[] separators)
            => text
                .Split(separators.Length > 0 ? separators : _defCharSeps, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s));

        private static IEnumerable<T> Split<T>(string text, Func<string, T> parser) => Split(text).Select(parser);

        private static IList Split(string text, Type dataType)
        {
            IList result = TypeUtils.CreateList(dataType);

            Split(text)
                .Select(t => Convert.ChangeType(t, dataType))
                .ForEach(o => result.Add(o));

            return result;
        }

        private static Array SplitToArray(string text, Type dataType)
        {
            IList values = Split(text, dataType);
            int count = values.Count;
            Array result = Array.CreateInstance(dataType, count);
            int index = 0;

            foreach (object value in values)
                result.SetValue(value, index++);

            return result;
        }

        private static IEnumerable<char> GetAsSimpleCommaSeparatedChars(string text)
            => text.Split(',').Select(s =>
            {
                s = s.Trim();

                if (s == @"\r") s = "\r";
                if (s == @"\n") s = "\n";
                if (s == @"\t") s = "\t";

                return string.IsNullOrEmpty(s) ? ' ' : s[0];
            });

        private static IEnumerable<char> GetChars(string text, Regex regex)
        {
            Match match = regex.Match(text);

            while (match.Success)
            {
                yield return match.Groups["text"].Value[0];
                match = match.NextMatch();
            }
        }

        private static IEnumerable<char> SplitChars(string text)
        {
            // TODO: Replace regular expressions with a parser.
            if (string.IsNullOrWhiteSpace(text))
                return Enumerable.Empty<char>();

            if (_singleQuotedCommaRegex.IsMatch(text))
                return GetChars(text, _singleQuotedCommaFieldRegex);

            if (_doubleQuotedCommaRegex.IsMatch(text))
                return GetChars(text, _doubleQuotedCommaFieldRegex);

            return GetAsSimpleCommaSeparatedChars(text);
        }

        private static IList SplitChars(string text, Type dataType)
        {
            IList result = TypeUtils.CreateList(dataType);

            SplitChars(text)
                .Select(t => Convert.ChangeType(t, dataType))
                .ForEach(o => result.Add(o));

            return result;
        }

        private enum EscapeState { Normal, Slash };
    }
}