#if PINVOKE
using System;
using System.Runtime.InteropServices;
#else
using System;
#endif

namespace SJP.Fabulous
{
    /// <summary>
    /// Provides methods for working with the console on Windows.
    /// </summary>
    public static class WindowsConsole
    {
#if PINVOKE
        /// <summary>
        /// If supported, this will enable ANSI escape sequence processing on Windows consoles.
        /// </summary>
        public static void EnableVirtualTerminalProcessing()
        {
            if (!IsWindows)
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
        /// <returns><b>True</b> if the console can process ANSI escape sequences. <b>False</b> otherwise.</returns>
        public static bool IsVirtualTerminalProcessingEnabled()
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
        public static void EnableVirtualTerminalProcessing()
        {
        }

        /// <summary>
        /// If supported, this will enable ANSI escape sequence processing on Windows consoles.
        /// </summary>
        public static bool IsVirtualTerminalProcessingEnabled() => false;
#endif

        /// <summary>
        /// Determines whether the current environment is running on Windows.
        /// </summary>
        public static bool IsWindows => _isWindows.Value;

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
    }
}