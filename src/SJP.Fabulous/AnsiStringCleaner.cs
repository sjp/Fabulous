using System.Text.RegularExpressions;

namespace SJP.Fabulous
{
    /// <summary>
    /// An ANSI string cleaner that removes any ANSI escapes from a string.
    /// </summary>
    public class AnsiStringCleaner : IAnsiStringCleaner
    {
        /// <summary>
        /// Creates an ANSI string cleaner that removes ANSI escapes.
        /// </summary>
        /// <param name="ansiText">A piece of text that may contain ANSI escapes.</param>
        public AnsiStringCleaner(string ansiText)
        {
            AnsiText = ansiText ?? string.Empty;
        }

        /// <summary>
        /// Text containing ANSI escapes.
        /// </summary>
        protected string AnsiText { get; }

        /// <summary>
        /// Returns a string that has ANSI escape sequences removed.
        /// </summary>
        /// <returns>A string without ANSI escape sequences.</returns>
        public string ToAnsiCleanedString()
        {
            return Regex.Replace(AnsiText, "\u001B\\[[0-9;:]+m", string.Empty);
        }
    }
}
