using System;
using System.IO;
using System.Text.RegularExpressions;
using EnumsNET;
#if NETFX
using Microsoft.Win32;
using SysEnv = System.Environment;
#endif
#if RUNTIME_INFORMATION
using System.Runtime.InteropServices;
#endif

namespace SJP.Fabulous
{
    /// <summary>
    /// Provides information on determining the level of support that the current console provides.
    /// </summary>
    public static class ConsoleSupport
    {
        /// <summary>
        /// Determines the maximum color level for the current console.
        /// </summary>
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

        private static IEnvironmentVariableProvider Environment => new EnvironmentVariableProvider();

        private static ConsoleColorMode _colorLevel = GetSupportedColorMode();

        /// <summary>
        /// Retrieves the maximum color level for the current console.
        /// </summary>
        /// <returns>A <see cref="ConsoleColorMode"/> object.</returns>
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

        private static bool IsAnsiStyledCiEnvironment
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

        private static bool IsTeamCityAnsiStyled
        {
            get
            {
                return Environment.TryGetEnvironmentVariable("TEAMCITY_VERSION", out var tcVersion)
                    && Regex.IsMatch(tcVersion, @"^(9\.(0*[1-9]\d*)\.|\d{2,}\.)");
            }
        }

        private static ConsoleColorMode AnsiStyledTerminalProgram
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

        private static ConsoleColorMode TermColorMode
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

        private static ConsoleColorMode SupportedColorMode
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

        private static bool IsConsoleApp => _isConsoleApp.Value;

        private readonly static Lazy<long> _windowsBuildNumber = new Lazy<long>(GetWindowsBuildNumber);

        private readonly static Lazy<bool> _isConsoleApp = new Lazy<bool>(() =>
        {
            using (var stream = Console.OpenStandardInput())
                return (stream ?? Stream.Null) != Stream.Null;
        });
    }
}
