using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    public static class DoubleExtensions
    {
        public static bool ApproxEquals(this double input, double comparison, double epsilon = 0.0001) => Math.Abs(input - comparison) <= epsilon;

        public static bool IsNaN(this double input) => double.IsNaN(input);

        public static bool IsNegativeInfinity(this double input) => double.IsNegativeInfinity(input);

        public static bool IsPositiveInfinity(this double input) => double.IsPositiveInfinity(input);
    }

    public static class MathExtensions
    {
        public static T Clamp<T>(this T value, T max, T min) where T : IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }
    }

    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(string input) => string.IsNullOrEmpty(input);

        public static bool IsNullOrWhiteSpace(string input) => string.IsNullOrWhiteSpace(input);
    }
}
