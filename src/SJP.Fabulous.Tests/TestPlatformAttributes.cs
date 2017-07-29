﻿using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace SJP.Fabulous.Tests
{
    public static class TestPlatform
    {
        public class Windows : NUnitAttribute, IApplyToTest
        {
            public void ApplyToTest(Test test)
            {
                if (test.RunState == RunState.NotRunnable || _isWindows)
                    return;

                test.RunState = RunState.Ignored;

                var reason = "This test is ignored because the current platform is non-Windows and the test is for Windows platforms only.";
                test.Properties.Set(PropertyNames.SkipReason, reason);
            }

            private readonly static bool _isWindows = WindowsConsole.IsWindowsPlatform;
        }

        public class NonWindows : NUnitAttribute, IApplyToTest
        {
            public void ApplyToTest(Test test)
            {
                if (test.RunState == RunState.NotRunnable || _isNotWindows)
                    return;

                test.RunState = RunState.Ignored;

                var reason = "This test is ignored because the current platform is Windows and the test is for non-Windows platforms only.";
                test.Properties.Set(PropertyNames.SkipReason, reason);
            }

            private readonly static bool _isNotWindows = !WindowsConsole.IsWindowsPlatform;
        }
    }
}