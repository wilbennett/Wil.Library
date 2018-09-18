using System;

namespace Wil.Core
{
    public static class StringArrayUtils
    {
        public static void ShuffleRows(string[] lines, string[] lines2)
        {
            for (int i = 0; i < lines.Length; ++i)
            {
                int r = _rnd.Next(i, lines.Length);
                string tmp = lines[r];
                lines[r] = lines[i];
                lines[i] = tmp;

                tmp = lines2[r];
                lines2[r] = lines2[i];
                lines2[i] = tmp;
            }
        }

        private static readonly Random _rnd = new Random();
    }
}