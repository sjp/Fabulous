using System;
using EnumsNET;
using System.IO;

namespace SJP.Fabulous
{
    /// <summary>
    /// Stores and provides settings for printing to a console with Fabulous
    /// </summary>
    public static class FabulousConsole
    {
        /// <summary>
        /// Determines the maximum color level for the current console. Defaults to <see cref="ConsoleColorMode.Standard"/>.
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

        private static ConsoleColorMode _colorLevel = ConsoleColorMode.Standard;

        /// <summary>
        /// Retrieves the maximum color level for the current console.
        /// </summary>
        /// <returns>A <see cref="ConsoleColorMode"/> object.</returns>
        public static ConsoleColorMode GetMaximumSupportedColorMode()
        {
            var env = Environment;
            if (env.TryGetEnvironmentVariable("CI", out var ciVar))
            {
                var isAnsiStyledCi = ciVar == "Travis"
                    || env.HasEnvironmentVariable("TRAVIS")
                    || env.HasEnvironmentVariable("CIRCLECI");

                return isAnsiStyledCi ? ConsoleColorMode.Basic : ConsoleColorMode.None;
            }

            if (env.TryGetEnvironmentVariable("TEAMCITY_VERSION", out var tcVersionText))
            {
                if (!Version.TryParse(tcVersionText, out var tcVersion))
                    return ConsoleColorMode.None;

                var minColoredVersion = new Version(9, 1);
                return tcVersion >= minColoredVersion
                    ? ConsoleColorMode.Basic
                    : ConsoleColorMode.None;
            }

            if (!IsConsoleApp)
                return ConsoleColorMode.None;

            if (WindowsConsole.IsWindowsPlatform)
            {
                // try conemu first, otherwise just use windows
                if (env.TryGetEnvironmentVariable("ConEmuANSI", out var conEmuAnsi))
                {
                    return "ON".Equals(conEmuAnsi, StringComparison.OrdinalIgnoreCase)
                        ? ConsoleColorMode.Enhanced
                        : ConsoleColorMode.Basic;
                }

                return WindowsConsole.MaximumSupportedColorLevel;
            }

            if (env.TryGetEnvironmentVariable("TERM_PROGRAM", out var termProgram))
            {
                switch (termProgram)
                {
                    case "iTerm.app":
                        if (!env.TryGetEnvironmentVariable("TERM_PROGRAM_VERSION", out var termProgramVersionText)
                            || !Version.TryParse(termProgramVersionText, out var termProgramVersion))
                            return ConsoleColorMode.Enhanced;

                        return termProgramVersion.Major >= 3
                            ? ConsoleColorMode.Full
                            : ConsoleColorMode.Enhanced;
                    case "Hyper":
                        return ConsoleColorMode.Full;
                    case "Apple_Terminal":
                        return ConsoleColorMode.Enhanced;
                }
            }

            if (env.TryGetEnvironmentVariable("TERM", out var term))
            {
                if (term.EndsWith("-256color", StringComparison.OrdinalIgnoreCase))
                    return ConsoleColorMode.Enhanced;

                var isBasicTerm = term.StartsWith("screen", StringComparison.OrdinalIgnoreCase)
                    || term.StartsWith("xterm", StringComparison.OrdinalIgnoreCase)
                    || term.StartsWith("vt100", StringComparison.OrdinalIgnoreCase)
                    || term.Equals("ansi", StringComparison.OrdinalIgnoreCase)
                    || term.Equals("color", StringComparison.OrdinalIgnoreCase)
                    || term.Equals("cygwin", StringComparison.OrdinalIgnoreCase)
                    || term.Equals("linux", StringComparison.OrdinalIgnoreCase);
                if (isBasicTerm)
                    return ConsoleColorMode.Basic;

                if (term.Equals("dumb", StringComparison.OrdinalIgnoreCase))
                    return ConsoleColorMode.None;
            }

            if (env.HasEnvironmentVariable("COLORTERM"))
                return ConsoleColorMode.Basic;

            return ConsoleColorMode.None;
        }

        private static bool IsConsoleApp => _isConsoleApp.Value;

        private readonly static Lazy<bool> _isConsoleApp = new Lazy<bool>(() =>
        {
            using (var stream = Console.OpenStandardInput())
                return (stream ?? Stream.Null) != Stream.Null;
        });

        /// <summary>
        /// Provides access to environment variables on the system. Not intended to be changed.
        /// </summary>
        public static IEnvironmentVariableProvider Environment
        {
            get => _environment;
            set => _environment = value ?? throw new ArgumentNullException(nameof(Environment));
        }

        private static IEnvironmentVariableProvider _environment = new EnvironmentVariableProvider();
    }
}
