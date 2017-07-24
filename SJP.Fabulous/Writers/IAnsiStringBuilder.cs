namespace SJP.Fabulous
{
    /// <summary>
    /// Defines methods used to create ANSI-compatible strings.
    /// </summary>
    public interface IAnsiStringBuilder
    {
        /// <summary>
        /// Converts the value of an <see cref="IAnsiStringBuilder"/> to a <see cref="string"/>.
        /// </summary>
        /// <returns>A string that can contain ANSI styling if present.</returns>
        string ToAnsiString();
    }
}
