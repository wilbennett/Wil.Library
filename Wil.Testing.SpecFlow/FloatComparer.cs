using System;
using System.Collections;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class FloatComparer : IComparer
    {
        public FloatComparer(SpecFlowContext context)
        {
            _context = context;
        }

        public int Compare(object x, object y)
        {
            var d1 = (float)x;
            var d2 = (float)y;

            return Math.Abs(d1 - d2) < _context.GetFloatEpsilon()
                ? 0
                : d1 < d2 ? -1 : 1;
        }

        private readonly SpecFlowContext _context;
    }
}