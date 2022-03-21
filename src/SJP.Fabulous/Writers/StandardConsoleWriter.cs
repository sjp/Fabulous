using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous;

/// <summary>
/// A console writer that prints and styles text using the styling available in <see cref="Console"/>.
/// </summary>
public class StandardConsoleWriter : IConsoleWriter
{
    /// <summary>
    /// Creates a console writer that performs styling using <see cref="Console"/>.
    /// </summary>
    /// <param name="text">A piece of text to be printed.</param>
    public StandardConsoleWriter(FabulousText text)
        : this(new FabulousTextCollection(text))
    {
    }

    /// <summary>
    /// Creates a console writer that performs styling using <see cref="Console"/>.
    /// </summary>
    /// <param name="textCollection">A collection of text to be printed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="textCollection"/> is <c>null</c>.</exception>
    public StandardConsoleWriter(FabulousTextCollection textCollection)
    {
        TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
    }

    /// <summary>
    /// The pieces of text to be printed
    /// </summary>
    protected FabulousTextCollection TextCollection { get; }

    /// <summary>
    /// Writes styled text to the standard output stream.
    /// </summary>
    public void Write()
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            Console.Write(text.Text);

            ResetConsoleColors();
        }
    }

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    public void Write(params object[] args)
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            Console.Write(text.Text, args);

            ResetConsoleColors();
        }
    }

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
    public void WriteError()
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            Console.Error.Write(text.Text);

            ResetConsoleColors();
        }
    }

    /// <summary>
    /// Writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    public void WriteError(params object[] args)
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            Console.Error.Write(text.Text, args);

            ResetConsoleColors();
        }
    }

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
    public async Task WriteAsync()
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            await Console.Out.WriteAsync(text.Text).ConfigureAwait(false);

            ResetConsoleColors();
        }
    }

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteAsync(params object[] args)
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            await Console.Out.WriteAsync(string.Format(text.Text, args)).ConfigureAwait(false);

            ResetConsoleColors();
        }
    }

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
    public async Task WriteErrorAsync()
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            await Console.Error.WriteAsync(text.Text).ConfigureAwait(false);

            ResetConsoleColors();
        }
    }

    /// <summary>
    /// Asynchronously writes styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public async Task WriteErrorAsync(params object[] args)
    {
        foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
        {
            var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
            var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            await Console.Error.WriteAsync(string.Format(text.Text, args)).ConfigureAwait(false);

            ResetConsoleColors();
        }
    }

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

    /// <summary>
    /// Translates an color in the RGB colorspace to a <see cref="ConsoleColor"/> object that can be used for styling the console.
    /// </summary>
    /// <param name="rgb">A color in the RGB colorspace.</param>
    /// <returns>A <see cref="ConsoleColor"/> object that can be used for styling.</returns>
    protected static ConsoleColor GetConsoleColor(IRgb rgb)
    {
        var ansiColor = GetSimpleAnsiColor(rgb);
        return _ansiToConsoleColor[ansiColor];
    }

    /// <summary>
    /// Resets the console styling to grey text on a black background.
    /// </summary>
    protected static void ResetConsoleColors()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Black;
    }

    private static int GetSimpleAnsiColor(IRgb rgb)
    {
        if (rgb == null)
            throw new ArgumentNullException(nameof(rgb));

        var value = GetValue(rgb);
        if (value == 0)
            return 30;

        var iBlue = Convert.ToInt32(Math.Round(rgb.Blue / 255d, MidpointRounding.AwayFromZero));
        var iGreen = Convert.ToInt32(Math.Round(rgb.Green / 255d, MidpointRounding.AwayFromZero));
        var iRed = Convert.ToInt32(Math.Round(rgb.Red / 255d, MidpointRounding.AwayFromZero));

        var ansi = 30
            + ((iBlue << 2)
            | (iGreen << 1)
            | iRed);

        return value >= 50
            ? ansi + 60
            : ansi;
    }

    private static double GetValue(IRgb rgb)
    {
        if (rgb == null)
            throw new ArgumentNullException(nameof(rgb));

        var maxColor = Math.Max(Math.Max(rgb.Blue, rgb.Green), rgb.Red);
        return (maxColor / 255d) * 100d;
    }

    private readonly static IReadOnlyDictionary<int, ConsoleColor> _ansiToConsoleColor = new Dictionary<int, ConsoleColor>
    {
        [30] = ConsoleColor.Black,
        [31] = ConsoleColor.DarkRed,
        [32] = ConsoleColor.DarkGreen,
        [33] = ConsoleColor.DarkYellow,
        [34] = ConsoleColor.DarkBlue,
        [35] = ConsoleColor.DarkMagenta,
        [36] = ConsoleColor.DarkCyan,
        [37] = ConsoleColor.DarkGray,
        [90] = ConsoleColor.Gray,
        [91] = ConsoleColor.Red,
        [92] = ConsoleColor.Green,
        [93] = ConsoleColor.Yellow,
        [94] = ConsoleColor.Blue,
        [95] = ConsoleColor.Magenta,
        [96] = ConsoleColor.Cyan,
        [97] = ConsoleColor.White
    };
}
