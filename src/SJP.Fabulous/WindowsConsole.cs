#if PINVOKE
using System;
using System.Runtime.InteropServices;
#else
using System;
#endif
#if NETFX
using Microsoft.Win32;
#endif

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

                // disabling true color for now, seems to not be fully supported in creators build
                //if (VersionSupportsTrueColor)
                //    return ConsoleColorMode.Full;

                //if (VersionSupportsEnhancedColor)
                //    return ConsoleColorMode.Enhanced;

                return ConsoleColorMode.Basic; // could use ConsoleColorMode.Standard, but would provide less styling than Basic
            }
        }

#if PINVOKE
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
#else
        /// <summary>
        /// If supported, this will enable ANSI escape sequence processing on Windows consoles.
        /// </summary>
        private static void EnableVirtualTerminalProcessing()
        {
        }

        /// <summary>
        /// If supported, this will enable ANSI escape sequence processing on Windows consoles.
        /// </summary>
        private static bool IsVirtualTerminalProcessingEnabled() => false;
#endif

        /// <summary>
        /// Determines whether the current environment is running on Windows.
        /// </summary>
        public static bool IsWindowsPlatform => _isWindows.Value;

        private readonly static Lazy<bool> _isWindows = new Lazy<bool>(() =>
        {
#if RUNTIME_INFORMATION
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#elif NETFX
            return Environment.OSVersion.Platform == PlatformID.Win32NT;
#else
            return false;
#endif
        });

        private static bool VersionSupportsTrueColor
        {
            get
            {
#if NETFX
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
#else
                return false;
#endif
            }
        }

        private static bool VersionSupportsEnhancedColor
        {
            get
            {
#if NETFX
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
#else
                return false;
#endif
            }
        }

        private static long WindowsBuildNumber => _windowsBuildNumber.Value;

        private static long GetWindowsBuildNumber()
        {
#if NETFX
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
#elif RUNTIME_INFORMATION
            var osDesc = RuntimeInformation.OSDescription ?? string.Empty;
            if (osDesc.IndexOf("Windows", StringComparison.OrdinalIgnoreCase) < 0)
                return 0;

            var pieces = osDesc.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var lastPiece = pieces[pieces.Length - 1];
            if (long.TryParse(lastPiece, out var buildNumber))
                return buildNumber;
#endif
            return 0;
        }

        private readonly static Lazy<long> _windowsBuildNumber = new Lazy<long>(GetWindowsBuildNumber);
    }
}