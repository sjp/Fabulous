namespace SJP.Fabulous
{
    /// <summary>
    /// Represents the way in which the console will be styled.
    /// </summary>
    public enum ConsoleColorMode
    {
        /// <summary>
        /// No styling will be applied.
        /// </summary>
        None,

        /// <summary>
        /// The standard set of code styling will be applied. Equivalent in behaviour to using System.Console.
        /// </summary>
        Standard,

        /// <summary>
        /// ANSI styling will be applied using the basic 16 color set.
        /// </summary>
        Basic, // 16 colors

        /// <summary>
        /// ANSI styling will be applied with 256 colors available.
        /// </summary>
        Enhanced,

        /// <summary>
        /// ANSI styling will be applied with 24-bit color.
        /// </summary>
        Full
    }
}
