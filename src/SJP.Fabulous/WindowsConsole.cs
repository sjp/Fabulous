using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SJP.Fabulous
{
    /// <summary>
    /// Provides methods for working with the console on Windows.
    /// </summary>
    public static class WindowsConsole
    {
        /// <summary>
        /// Detects the maximum supported color level that the standard Windows console supports.
        /// </summary>
        public static ConsoleColorMode MaximumSupportedColorLevel
        {
            get
            {
                if (!IsWindowsPlatform)
                    return ConsoleColorMode.Standard;

                EnableVirtualTerminalProcessing();
                if (!IsVirtualTerminalProcessingEnabled())
                    return ConsoleColorMode.Standard;

                // disabling true color for now, seems to not be fully supported yet
                //if (VersionSupportsTrueColor)
                //    return ConsoleColorMode.Full;

                //if (VersionSupportsEnhancedColor)
                //    return ConsoleColorMode.Enhanced;

                return ConsoleColorMode.Basic; // could use ConsoleColorMode.Standard, but would provide less styling than Basic
            }
        }

        /// <summary>
        /// If supported, this will enable ANSI escape sequence processing on Windows consoles.
        /// </summary>
        private static void EnableVirtualTerminalProcessing()
        {
            if (!IsWindowsPlatform)
                return;

            var stdout = GetStdHandle(StandardOutputHandleId);
            if (stdout != (IntPtr)InvalidHandleValue && GetConsoleMode(stdout, out var mode))
            {
                SetConsoleMode(stdout, mode | EnableVirtualTerminalProcessingMode);
            }
        }

        /// <summary>
        /// Determines whether the current console is able to process ANSI escape sequences.
        /// </summary>
        /// <returns><c>true</c> if the console can process ANSI escape sequences. <c>false</c> otherwise.</returns>
        private static bool IsVirtualTerminalProcessingEnabled()
        {
            var stdout = GetStdHandle(StandardOutputHandleId);
            return stdout != (IntPtr)InvalidHandleValue
                && GetConsoleMode(stdout, out var mode)
                && ((mode & EnableVirtualTerminalProcessingMode) == EnableVirtualTerminalProcessingMode);
        }

        private const int StandardOutputHandleId = -11;
        private const uint EnableVirtualTerminalProcessingMode = 4;
        private const long InvalidHandleValue = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int handleId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out uint mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr handle, uint mode);

        /// <summary>
        /// Determines whether the current environment is running on Windows.
        /// </summary>
        public static bool IsWindowsPlatform => Environment.OSVersion.Platform == PlatformID.Win32NT;

        private static bool VersionSupportsTrueColor
        {
            get
            {
                if (Environment.OSVersion.Version.Major > 6)
                    return true;
                if (Environment.OSVersion.Version.Major < 6)
                    return false;

                if (Environment.OSVersion.Version.Minor > 2)
                    return true;
                if (Environment.OSVersion.Version.Minor < 2)
                    return false;

                if (Environment.OSVersion.Version.Build > 9200)
                    return true;
                if (Environment.OSVersion.Version.Build < 9200)
                    return false;

                return WindowsBuildNumber >= 14931;
            }
        }

        private static bool VersionSupportsEnhancedColor
        {
            get
            {
                if (Environment.OSVersion.Version.Major > 6)
                    return true;
                if (Environment.OSVersion.Version.Major < 6)
                    return false;

                if (Environment.OSVersion.Version.Minor > 2)
                    return true;
                if (Environment.OSVersion.Version.Minor < 2)
                    return false;

                if (Environment.OSVersion.Version.Build > 9200)
                    return true;
                if (Environment.OSVersion.Version.Build < 9200)
                    return false;

                return WindowsBuildNumber >= 10586;
            }
        }

        private static long WindowsBuildNumber => _windowsBuildNumber.Value;

        private static long GetWindowsBuildNumber()
        {
            using (var hklmKey = Registry.LocalMachine)
            using (var subKey = hklmKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                if (subKey != null)
                {
                    var buildNumberStr = Convert.ToString(subKey.GetValue("CurrentBuildNumber"));
                    if (buildNumberStr != null && long.TryParse(buildNumberStr, out var buildNumber))
                        return buildNumber;
                }
            }

            return 0;
        }

        private readonly static Lazy<long> _windowsBuildNumber = new Lazy<long>(GetWindowsBuildNumber);
    }
}