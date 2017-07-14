using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(string input) => string.IsNullOrEmpty(input);

        public static bool IsNullOrWhiteSpace(string input) => string.IsNullOrWhiteSpace(input);
    }
}
