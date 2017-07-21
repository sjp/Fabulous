using System;
using System.IO;
using System.Text.RegularExpressions;
using EnumsNET;

#if NETFX
using Microsoft.Win32;
#endif

namespace SJP.Fabulous
{
    public static class ConsoleSupport
    {
        public static ConsoleColorMode ColorLevel
        {
            get => _colorLevel;
            set
            {
                if (!value.IsDefined())
                    throw new ArgumentException($"The { nameof(ConsoleColorMode) } object is not set to a valid value.", nameof(ColorLevel));

                _colorLevel = value;
            }
        }

        private static ConsoleColorMode _colorLevel = GetSupportedColorMode();

        public static ConsoleColorMode GetSupportedColorMode()
        {
            if (!IsConsoleApp)
                return ConsoleColorMode.None;

            if (WindowsConsole.IsWindows)
            {
                WindowsConsole.EnableVirtualTerminalProcessing();
                if (!WindowsConsole.IsVirtualTerminalProcessingEnabled())
                    return ConsoleColorMode.Basic;

                if (WindowsVersionSupportsTrueColor)
                    return ConsoleColorMode.Full;

                if (WindowsVersionSupportsEnhancedColor)
                    return ConsoleColorMode.Enhanced;

                return ConsoleColorMode.Basic;
            }

            return ConsoleColorMode.None;
        }

        public static bool IsAnsiStyledCiEnvironment
        {
            get
            {
                var ci = Environment.GetEnvironmentVariable("CI");
                if (ci != null)
                {
                    return ci == "Travis"
                        || Environment.GetEnvironmentVariable("TRAVIS") != null
                        || Environment.GetEnvironmentVariable("CIRCLECI") != null;
                }

                return false;
            }
        }

        public static bool IsTeamCityAnsiStyled
        {
            get
            {
                var tcVersion = Environment.GetEnvironmentVariable("TEAMCITY_VERSION");
                if (tcVersion == null)
                    return false;

                return Regex.IsMatch(tcVersion, @"^(9\.(0*[1-9]\d*)\.|\d{2,}\.)");
            }
        }

        public static ConsoleColorMode AnsiStyledTerminalProgram
        {
            get
            {
                var termProgramVersion = Environment.GetEnvironmentVariable("TERM_PROGRAM_VERSION");
                if (termProgramVersion == null)
                    return ConsoleColorMode.None;

                switch (termProgramVersion)
                {
                    case "iTerm.app":
                        var pieces = termProgramVersion.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                        var majorVersionText = pieces[0];
                        if (!int.TryParse(majorVersionText, out var majorVersion))
                            return ConsoleColorMode.None;
                        return majorVersion >= 3 ? ConsoleColorMode.Full : ConsoleColorMode.Enhanced;
                    case "Hyper":
                        return ConsoleColorMode.Full;
                    case "Apple_Terminal":
                        return ConsoleColorMode.Enhanced;
                }

                return ConsoleColorMode.None;
            }
        }

        public static ConsoleColorMode TermColorMode
        {
            get
            {
                var term = Environment.GetEnvironmentVariable("TERM");
                if (term == null)
                    return ConsoleColorMode.None;

                if (Regex.IsMatch(term, "^(screen|xterm)-256(?:color)?"))
                    return ConsoleColorMode.Enhanced;

                if (Regex.IsMatch(term, "^screen|^xterm|^vt100|color|ansi|cygwin|linux", RegexOptions.IgnoreCase))
                    return ConsoleColorMode.Basic;

                var colorTerm = Environment.GetEnvironmentVariable("COLORTERM");
                if (colorTerm != null)
                    return ConsoleColorMode.Basic;

                if (term == "dumb")
                    return ConsoleColorMode.Standard;

                return ConsoleColorMode.None;
            }
        }

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

                return WindowsBuildNumber >= 14931;
#else
                return false;
#endif
            }
        }

        private static bool WindowsVersionSupportsEnhancedColor
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

        private static long WindowsBuildNumber => _windowsBuildNumberLoader.Value;

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
#endif
            return 0;
        }

        private static bool IsConsoleApp => _isConsoleApp.Value;

        private readonly static Lazy<long> _windowsBuildNumberLoader = new Lazy<long>(GetWindowsBuildNumber);

        private readonly static Lazy<bool> _isConsoleApp = new Lazy<bool>(() => Console.OpenStandardInput() != Stream.Null);
    }
}
