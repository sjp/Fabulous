using System;
using System.IO;
using System.Text.RegularExpressions;
using EnumsNET;
using Microsoft.Win32;
using SysEnv = System.Environment;

namespace SJP.Fabulous
{
    public static class ConsoleSupport
    {
        public static ConsoleColorMode ColorLevel
        {
            get => _colorLevel;
            set
            {
                if (!value.IsValid())
                    throw new ArgumentException($"The { nameof(ConsoleColorMode) } object is not set to a valid value.", nameof(ColorLevel));

                _colorLevel = value;
            }
        }

        public static IEnvironmentVariableProvider Environment => new EnvironmentVariableProvider();

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
                var env = Environment;
                if (env.HasEnvironmentVariable("CI"))
                {
                    var ciValue = env.GetEnvironmentVariable("CI");
                    return ciValue == "Travis"
                        || env.HasEnvironmentVariable("TRAVIS")
                        || env.HasEnvironmentVariable("CIRCLECI");
                }

                return false;
            }
        }

        public static bool IsTeamCityAnsiStyled
        {
            get
            {
                return Environment.TryGetEnvironmentVariable("TEAMCITY_VERSION", out var tcVersion)
                    && Regex.IsMatch(tcVersion, @"^(9\.(0*[1-9]\d*)\.|\d{2,}\.)");
            }
        }

        public static ConsoleColorMode AnsiStyledTerminalProgram
        {
            get
            {
                if (Environment.TryGetEnvironmentVariable("TERM_PROGRAM_VERSION", out var termProgramVersion))
                {
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
                }

                return ConsoleColorMode.None;
            }
        }

        public static ConsoleColorMode TermColorMode
        {
            get
            {
                var env = Environment;
                if (!env.TryGetEnvironmentVariable("TERM", out var term))
                    return ConsoleColorMode.None;

                if (Regex.IsMatch(term, "^(screen|xterm)-256(?:color)?"))
                    return ConsoleColorMode.Enhanced;

                if (Regex.IsMatch(term, "^screen|^xterm|^vt100|color|ansi|cygwin|linux", RegexOptions.IgnoreCase))
                    return ConsoleColorMode.Basic;

                if (!env.HasEnvironmentVariable("COLORTERM"))
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
                        return ConsoleColorMode.Standard;

                    if (WindowsVersionSupportsTrueColor)
                        return ConsoleColorMode.Full;

                    if (WindowsVersionSupportsEnhancedColor)
                        return ConsoleColorMode.Enhanced;

                    return ConsoleColorMode.Standard;
                }

                // TODO: check support for Linux/Mac ANSI
                return ConsoleColorMode.Basic;
            }
        }

        private static bool WindowsVersionSupportsTrueColor
        {
            get
            {
#if NETFX
                if (SysEnv.OSVersion.Version.Major > 6)
                    return true;
                if (SysEnv.OSVersion.Version.Major < 6)
                    return false;

                if (SysEnv.OSVersion.Version.Minor > 2)
                    return true;
                if (SysEnv.OSVersion.Version.Minor < 2)
                    return false;

                if (SysEnv.OSVersion.Version.Build > 9200)
                    return true;
                if (SysEnv.OSVersion.Version.Build < 9200)
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
                if (SysEnv.OSVersion.Version.Major > 6)
                    return true;
                if (SysEnv.OSVersion.Version.Major < 6)
                    return false;

                if (SysEnv.OSVersion.Version.Minor > 2)
                    return true;
                if (SysEnv.OSVersion.Version.Minor < 2)
                    return false;

                if (SysEnv.OSVersion.Version.Build > 9200)
                    return true;
                if (SysEnv.OSVersion.Version.Build < 9200)
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

        private static bool IsConsoleApp => _isConsoleApp.Value;

        private readonly static Lazy<long> _windowsBuildNumberLoader = new Lazy<long>(GetWindowsBuildNumber);

        private readonly static Lazy<bool> _isConsoleApp = new Lazy<bool>(() => Console.OpenStandardInput() != Stream.Null);
    }
}
