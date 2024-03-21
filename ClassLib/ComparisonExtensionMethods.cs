using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public static class ComparisonExtensionMethods
    {
        public static bool floatCompare(this double a, double b)
        {
            return Math.Abs(a - b) < 0.00001;
        }

        public static bool Compare(this int a, int b)
        {
            return Math.Abs(a - b) < 0.00001;
        }
    }
}
