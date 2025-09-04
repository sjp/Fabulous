using System;
using System.Threading.Tasks;

namespace SJP.Fabulous.Writers;

/// <summary>
/// A console writer that prints and styles text using ANSI escape sequences.
/// </summary>
public class AnsiConsoleWriter : IConsoleWriter
{
    /// <summary>
    /// Creates a console writer that prints text formatted with ANSI styling.
    /// </summary>
    /// <param name="text">That is (optionally) styled with ANSI escape sequences.</param>
    public AnsiConsoleWriter(string text)
    {
        Text = text ?? string.Empty;
    }

    /// <summary>
    /// The text to be printed to the console.
    /// </summary>
    protected string Text { get; }

    /// <summary>
    /// Writes styled text to the standard output stream.
    /// </summary>
    public void Write() => Console.Write(Text);

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    public void Write(params object[] args) => Console.Write(Text, args);

    /// <summary>
    /// Writes styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    public void WriteLine()
    {
        Write();
        Console.WriteLine();
    }

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be printed to standard output stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    public void WriteLine(params object[] args)
    {
        Write(args);
        Console.WriteLine();
    }

    /// <summary>
    /// Writes styled text to the standard error stream.
    /// </summary>
    public void WriteError() => Console.Error.Write(Text);

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    public void WriteError(params object[] args) => Console.Error.Write(Text, args);

    /// <summary>
    /// Writes styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    public void WriteErrorLine()
    {
        WriteError();
        Console.Error.WriteLine();
    }

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    public void WriteErrorLine(params object[] args)
    {
        WriteError(args);
        Console.Error.WriteLine();
    }

    /// <summary>
    /// Asynchronously writes styled text to the standard output stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteAsync() => await Console.Out.WriteAsync(Text).ConfigureAwait(false);

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteAsync(params object[] args) => await Console.Out.WriteAsync(string.Format(Text, args)).ConfigureAwait(false);

    /// <summary>
    /// Asynchronously writes styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteLineAsync()
    {
        await WriteAsync().ConfigureAwait(false);
        await Console.Out.WriteLineAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to standard output stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteLineAsync(params object[] args)
    {
        await WriteAsync(args).ConfigureAwait(false);
        await Console.Out.WriteLineAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously writes styled text to the standard error stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteErrorAsync() => await Console.Error.WriteAsync(Text).ConfigureAwait(false);

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteErrorAsync(params object[] args) => await Console.Error.WriteAsync(string.Format(Text, args)).ConfigureAwait(false);

    /// <summary>
    /// Asynchronously writes styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteErrorLineAsync()
    {
        await WriteErrorAsync().ConfigureAwait(false);
        await Console.Error.WriteLineAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteErrorLineAsync(params object[] args)
    {
        await WriteErrorAsync(args).ConfigureAwait(false);
        await Console.Error.WriteLineAsync().ConfigureAwait(false);
    }
}