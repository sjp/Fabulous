#if PINVOKE
using System;
using System.Runtime.InteropServices;
#endif

namespace SJP.Fabulous
{
    public static class WindowsConsole
    {
#if PINVOKE
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
        public static void EnableVirtualTerminalProcessing()
        {
        }

        public static bool IsVirtualTerminalProcessingEnabled() => false;
#endif

        public static bool IsWindows
        {
            get
            {
#if RUNTIME_INFORMATION
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#elif NETFX
                return Environment.OSVersion.Platform == PlatformID.Win32NT;
#else
                return false;
#endif
            }
        }
    }
}