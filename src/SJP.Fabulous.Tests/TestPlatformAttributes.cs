using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace SJP.Fabulous.Tests
{
    internal static class TestPlatform
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public sealed class Windows : NUnitAttribute, IApplyToTest
        {
            public void ApplyToTest(Test test)
            {
                if (test.RunState == RunState.NotRunnable || _isWindows)
                    return;

                test.RunState = RunState.Ignored;

                const string reason = "This test is ignored because the current platform is non-Windows and the test is for Windows platforms only.";
                test.Properties.Set(PropertyNames.SkipReason, reason);
            }

            private readonly static bool _isWindows = WindowsConsole.IsWindowsPlatform;
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public sealed class NonWindows : NUnitAttribute, IApplyToTest
        {
            public void ApplyToTest(Test test)
            {
                if (test.RunState == RunState.NotRunnable || _isNotWindows)
                    return;

                test.RunState = RunState.Ignored;

                const string reason = "This test is ignored because the current platform is Windows and the test is for non-Windows platforms only.";
                test.Properties.Set(PropertyNames.SkipReason, reason);
            }

            private readonly static bool _isNotWindows = !WindowsConsole.IsWindowsPlatform;
        }
    }
}
