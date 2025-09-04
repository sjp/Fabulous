using System.Threading.Tasks;

namespace SJP.Fabulous.Writers;

/// <summary>
/// Defines methods to print styled text to a console.
/// </summary>
public interface IConsoleWriter : IConsoleWriterSync, IConsoleWriterAsync
{
}

/// <summary>
/// Defines methods to synchronously print styled text to a console.
/// </summary>
public interface IConsoleWriterSync
{
    /// <summary>
    /// Writes styled text to the standard output stream.
    /// </summary>
    void Write();

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    void Write(params object[] args);

    /// <summary>
    /// Writes styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    void WriteLine();

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be printed to standard output stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    void WriteLine(params object[] args);

    /// <summary>
    /// Writes styled text to the standard error stream.
    /// </summary>
    void WriteError();

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    void WriteError(params object[] args);

    /// <summary>
    /// Writes styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    void WriteErrorLine();

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    void WriteErrorLine(params object[] args);
}

/// <summary>
/// Defines methods to asynchronously print styled text to a console.
/// </summary>
public interface IConsoleWriterAsync
{
    /// <summary>
    /// Asynchronously writes styled text to the standard output stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteAsync();

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteAsync(params object[] args);

    /// <summary>
    /// Asynchronously writes styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteLineAsync();

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to standard output stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteLineAsync(params object[] args);

    /// <summary>
    /// Asynchronously writes styled text to the standard error stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteErrorAsync();

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteErrorAsync(params object[] args);

    /// <summary>
    /// Asynchronously writes styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteErrorLineAsync();

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    Task WriteErrorLineAsync(params object[] args);
}