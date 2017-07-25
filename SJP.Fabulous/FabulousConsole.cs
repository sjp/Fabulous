using System;
using EnumsNET;
using System.Text.RegularExpressions;
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

            if (env.TryGetEnvironmentVariable("TEAMCITY_VERSION", out var tcVersion))
            {
                return Regex.IsMatch(tcVersion, @"^(9\.(0*[1-9]\d*)\.|\d{2,}\.)")
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

            if (env.TryGetEnvironmentVariable("TERM_PROGRAM", out var termProgram) &&
                env.TryGetEnvironmentVariable("TERM_PROGRAM_VERSION", out var termProgramVersion))
            {
                var pieces = termProgramVersion.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                var majorVersionText = pieces[0];

                switch (termProgram)
                {
                    case "iTerm.app":
                        return int.TryParse(majorVersionText, out var majorVersion) && majorVersion >= 3
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
                var isEnhancedTerm = term.Equals("screen-256color", StringComparison.OrdinalIgnoreCase)
                    || term.Equals("xterm-256color", StringComparison.OrdinalIgnoreCase);
                if (isEnhancedTerm)
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

        private static IEnvironmentVariableProvider Environment { get; } = new EnvironmentVariableProvider();
    }
}
