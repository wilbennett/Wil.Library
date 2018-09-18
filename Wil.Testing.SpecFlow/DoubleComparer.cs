using System;
using System.Collections;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class DoubleComparer : IComparer
    {
        public DoubleComparer(SpecFlowContext context)
        {
            _context = context;
        }

        public int Compare(object x, object y)
        {
            var d1 = (double)x;
            var d2 = (double)y;

            return Math.Abs(d1 - d2) < _context.GetDoubleEpsilon()
                ? 0
                : d1 < d2 ? -1 : 1;
        }

        private readonly SpecFlowContext _context;
    }
}