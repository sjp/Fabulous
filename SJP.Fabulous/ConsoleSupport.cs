using System;

#if NETFX
using Microsoft.Win32;
#endif

namespace SJP.Fabulous
{
    public static class ConsoleSupport
    {
        public static ConsoleColorMode SupportedColorMode
        {
            get
            {
                if (WindowsConsole.IsWindows)
                {
                    // try enable ANSI
                    WindowsConsole.EnableVirtualTerminalProcessing();
                    if (!WindowsConsole.IsVirtualTerminalProcessingEnabled())
                        return ConsoleColorMode.Basic;

                    return WindowsVersionSupportsTrueColor
                        ? ConsoleColorMode.Full
                        : ConsoleColorMode.Enhanced;
                }

                // TODO: check for true color somehow...
                //       don't know how to do it on Windows yet, but apparently it is supported in an insiders build
                return WindowsVersionSupportsTrueColor
                    ? ConsoleColorMode.Full
                    : ConsoleColorMode.Enhanced;
            }
        }


        private static bool WindowsVersionSupportsTrueColor
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

                using (var hklmKey = Registry.LocalMachine)
                using (var subKey = hklmKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (subKey != null)
                    {
                        var buildNumberStr = Convert.ToString(subKey.GetValue("CurrentBuildNumber"));
                        if (buildNumberStr != null && long.TryParse(buildNumberStr, out var buildNumber))
                            return buildNumber >= 14931;
                    }
                }
                return false;
#else
                return false;
#endif
            }
        }
    }

    public enum ConsoleColorMode
    {
        None,
        Basic, // 16 colors
        Enhanced, // 256 colors
        Full // True colour
    }
}
