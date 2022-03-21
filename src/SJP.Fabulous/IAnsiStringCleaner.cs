namespace SJP.Fabulous;

/// <summary>
/// Defines methods used to clean ANSI escapes from a string.
/// </summary>
public interface IAnsiStringCleaner
{
    /// <summary>
    /// Converts the value of an <see cref="IAnsiStringCleaner"/> to a <see cref="string"/> containing no ANSI escapes.
    /// </summary>
    /// <returns>A string that will not contain any ANSI escapes.</returns>
    string ToAnsiCleanedString();
}
