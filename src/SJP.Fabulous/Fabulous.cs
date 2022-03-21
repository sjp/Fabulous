using System;
using System.Threading.Tasks;
using EnumsNET;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous;

/// <summary>
/// Prints and initializes styled text for use in a console.
/// </summary>
public static class Fabulous
{
    /// <summary>
    /// Creates a new <see cref="FabulousText"/> object that has a given foreground color.
    /// </summary>
    /// <param name="foreColor">A color to use for the foreground.</param>
    /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="foreColor"/> is <c>null</c>.</exception>
    public static FabulousText Foreground(IColor foreColor)
    {
        if (foreColor == null)
            throw new ArgumentNullException(nameof(foreColor));

        return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
    }

    /// <summary>
    /// Creates a new <see cref="FabulousText"/> object that has a given background color.
    /// </summary>
    /// <param name="backColor">A color to use for the background.</param>
    /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="backColor"/> is <c>null</c>.</exception>
    public static FabulousText Background(IColor backColor)
    {
        if (backColor == null)
            throw new ArgumentNullException(nameof(backColor));

        return new FabulousText(DefaultForeground, backColor, TextDecoration.None, null);
    }

    /// <summary>
    /// Creates a new <see cref="FabulousText"/> object that has text set to a given string.
    /// </summary>
    /// <param name="text">A string to be printed that may be styled.</param>
    /// <returns>A new text object that is the same as the current object, but with the provided string set as the printable text.</returns>
    public static FabulousText Text(string text) => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.None, text);

    /// <summary>
    /// Styles the text with a foreground color in the RGB colorspace.
    /// </summary>
    /// <param name="red">The red component of the foreground color</param>
    /// <param name="green">The green component of the foreground color</param>
    /// <param name="blue">The blue component of the foreground color</param>
    /// <returns>A new text object with the given foreground color.</returns>
    public static FabulousText Rgb(byte red, byte green, byte blue)
    {
        var foreColor = new Rgb(red, green, blue);
        return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
    }

    /// <summary>
    /// Styles the text with a foreground color in the RGB colorspace.
    /// </summary>
    /// <param name="values">A tuple containing RGB color components.</param>
    /// <returns>A new text object with the given foreground color.</returns>
    public static FabulousText Rgb((byte red, byte green, byte blue) values) => Rgb(values.red, values.green, values.blue);

    /// <summary>
    /// Styles the text with a foreground color as defined by a hexadecimal string in the RGB colorspace.
    /// </summary>
    /// <param name="hex">A hexadecimal string representing a color in the RGB colorspace.</param>
    /// <returns>A new text object with the given foreground color.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="hex"/> is <c>null</c>, empty, or whitespace.</exception>
    public static FabulousText Hex(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentNullException(nameof(hex));

        var foreColor = Colorspaces.Rgb.FromHex(hex);
        return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
    }

    /// <summary>
    /// Styles the text with a foreground color as defined by a named CSS color in the RGB colorspace.
    /// </summary>
    /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
    /// <returns>A new text object with the given foreground color.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="keyword"/> is <c>null</c>, empty, or whitespace.</exception>
    public static FabulousText Keyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentNullException(nameof(keyword));

        var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
        return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
    }

    /// <summary>
    /// Styles the text with a new foreground color as defined by a named CSS color in the RGB colorspace.
    /// </summary>
    /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
    /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
    /// <exception cref="ArgumentException"><paramref name="keyword"/> is not a valid enum.</exception>
    public static FabulousText Keyword(ColorKeyword keyword)
    {
        if (!keyword.IsValid())
            throw new ArgumentException($"The { nameof(ColorKeyword) } object is not set to a valid value.", nameof(keyword));

        var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
        return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
    }

    /// <summary>
    /// Initializes a new text object that has a black foreground color.
    /// </summary>
    public static FabulousText Black => new FabulousText(RgbConsoleColor.Black, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a red foreground color.
    /// </summary>
    public static FabulousText Red => new FabulousText(RgbConsoleColor.DarkRed, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a green foreground color.
    /// </summary>
    public static FabulousText Green => new FabulousText(RgbConsoleColor.DarkGreen, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a yellow foreground color.
    /// </summary>
    public static FabulousText Yellow => new FabulousText(RgbConsoleColor.DarkYellow, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a blue foreground color.
    /// </summary>
    public static FabulousText Blue => new FabulousText(RgbConsoleColor.DarkBlue, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a magenta foreground color.
    /// </summary>
    public static FabulousText Magenta => new FabulousText(RgbConsoleColor.DarkMagenta, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a cyan foreground color.
    /// </summary>
    public static FabulousText Cyan => new FabulousText(RgbConsoleColor.DarkCyan, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a white foreground color.
    /// </summary>
    public static FabulousText White => new FabulousText(RgbConsoleColor.White, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a gray foreground color.
    /// </summary>
    public static FabulousText Gray => new FabulousText(RgbConsoleColor.Grey, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a grey foreground color.
    /// </summary>
    public static FabulousText Grey => new FabulousText(RgbConsoleColor.Grey, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright red foreground color.
    /// </summary>
    public static FabulousText RedBright => new FabulousText(RgbConsoleColor.Red, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright green foreground color.
    /// </summary>
    public static FabulousText GreenBright => new FabulousText(RgbConsoleColor.Green, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright yellow foreground color.
    /// </summary>
    public static FabulousText YellowBright => new FabulousText(RgbConsoleColor.Yellow, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright blue foreground color.
    /// </summary>
    public static FabulousText BlueBright => new FabulousText(RgbConsoleColor.Blue, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright magenta foreground color.
    /// </summary>
    public static FabulousText MagentaBright => new FabulousText(RgbConsoleColor.Magenta, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright cyan foreground color.
    /// </summary>
    public static FabulousText CyanBright => new FabulousText(RgbConsoleColor.Cyan, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright white foreground color.
    /// </summary>
    public static FabulousText WhiteBright => new FabulousText(RgbConsoleColor.WhiteBright, DefaultBackground, TextDecoration.None, null);

    /// <summary>
    /// Styles the text with a background color in the RGB colorspace.
    /// </summary>
    /// <param name="red">The red component of the background color</param>
    /// <param name="green">The green component of the background color</param>
    /// <param name="blue">The blue component of the background color</param>
    /// <returns>A new text object with the given background color.</returns>
    public static FabulousText BgRgb(byte red, byte green, byte blue)
    {
        var bgColor = new Rgb(red, green, blue);
        return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
    }

    /// <summary>
    /// Styles the text with a background color in the RGB colorspace.
    /// </summary>
    /// <param name="values">A tuple containing RGB color components.</param>
    /// <returns>A new text object with the given background color.</returns>
    public static FabulousText BgRgb((byte red, byte green, byte blue) values) => BgRgb(values.red, values.green, values.blue);

    /// <summary>
    /// Styles the text with a background color as defined by a hexadecimal string in the RGB colorspace.
    /// </summary>
    /// <param name="hex">A hexadecimal string representing a color in the RGB colorspace.</param>
    /// <returns>A new text object with the given background color.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="hex"/> is <c>null</c>, empty, or whitespace.</exception>
    public static FabulousText BgHex(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentNullException(nameof(hex));

        var bgColor = Colorspaces.Rgb.FromHex(hex);
        return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
    }

    /// <summary>
    /// Styles the text with a background color as defined by a named CSS color in the RGB colorspace.
    /// </summary>
    /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
    /// <returns>A new text object with the given background color.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="keyword"/> is <c>null</c>, empty, or whitespace.</exception>
    public static FabulousText BgKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentNullException(nameof(keyword));

        var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
        return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
    }

    /// <summary>
    /// Styles the text with a new background color as defined by a named CSS color in the RGB colorspace.
    /// </summary>
    /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
    /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
    /// <exception cref="ArgumentException"><paramref name="keyword"/> is not a valid enum.</exception>
    public static FabulousText BgKeyword(ColorKeyword keyword)
    {
        if (!keyword.IsValid())
            throw new ArgumentException($"The { nameof(ColorKeyword) } object is not set to a valid value.", nameof(keyword));

        var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
        return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
    }

    /// <summary>
    /// Initializes a new text object that has a black background color.
    /// </summary>
    public static FabulousText BgBlack => new FabulousText(DefaultForeground, RgbConsoleColor.Black, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a red background color.
    /// </summary>
    public static FabulousText BgRed => new FabulousText(DefaultForeground, RgbConsoleColor.DarkRed, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a green background color.
    /// </summary>
    public static FabulousText BgGreen => new FabulousText(DefaultForeground, RgbConsoleColor.DarkGreen, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a yellow background color.
    /// </summary>
    public static FabulousText BgYellow => new FabulousText(DefaultForeground, RgbConsoleColor.DarkYellow, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a blue background color.
    /// </summary>
    public static FabulousText BgBlue => new FabulousText(DefaultForeground, RgbConsoleColor.DarkBlue, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a magenta background color.
    /// </summary>
    public static FabulousText BgMagenta => new FabulousText(DefaultForeground, RgbConsoleColor.DarkMagenta, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a cyan background color.
    /// </summary>
    public static FabulousText BgCyan => new FabulousText(DefaultForeground, RgbConsoleColor.DarkCyan, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a white background color.
    /// </summary>
    public static FabulousText BgWhite => new FabulousText(DefaultForeground, RgbConsoleColor.White, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a gray background color.
    /// </summary>
    public static FabulousText BgGray => new FabulousText(DefaultForeground, RgbConsoleColor.Grey, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a grey background color.
    /// </summary>
    public static FabulousText BgGrey => new FabulousText(DefaultForeground, RgbConsoleColor.Grey, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright red background color.
    /// </summary>
    public static FabulousText BgRedBright => new FabulousText(DefaultForeground, RgbConsoleColor.Red, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright green background color.
    /// </summary>
    public static FabulousText BgGreenBright => new FabulousText(DefaultForeground, RgbConsoleColor.Green, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright yellow background color.
    /// </summary>
    public static FabulousText BgYellowBright => new FabulousText(DefaultForeground, RgbConsoleColor.Yellow, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright blue background color.
    /// </summary>
    public static FabulousText BgBlueBright => new FabulousText(DefaultForeground, RgbConsoleColor.Blue, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright magenta background color.
    /// </summary>
    public static FabulousText BgMagentaBright => new FabulousText(DefaultForeground, RgbConsoleColor.Magenta, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright cyan background color.
    /// </summary>
    public static FabulousText BgCyanBright => new FabulousText(DefaultForeground, RgbConsoleColor.Cyan, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that has a bright white background color.
    /// </summary>
    public static FabulousText BgWhiteBright => new FabulousText(DefaultForeground, RgbConsoleColor.WhiteBright, TextDecoration.None, null);

    /// <summary>
    /// Initializes a new text object that resets the console to default styling before and after printing the text.
    /// </summary>
    public static FabulousText Reset => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.None, null, true);

    /// <summary>
    /// Initializes a new text object that will blink when printed.
    /// </summary>
    public static FabulousText Blink => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Blink, null);

    /// <summary>
    /// Initializes a new text object that will be styled with a bold font weight.
    /// </summary>
    public static FabulousText Bold => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Bold, null);

    /// <summary>
    /// Initializes a new text object that will be dimmed.
    /// </summary>
    public static FabulousText Dim => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Dim, null);

    /// <summary>
    /// Initializes a new text object that will be styled as italic.
    /// </summary>
    public static FabulousText Italic => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Italic, null);

    /// <summary>
    /// Initializes a new text object that will be underlined when printed.
    /// </summary>
    public static FabulousText Underline => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Underline, null);

    /// <summary>
    /// Initializes a new text object that will be concealed when printed.
    /// </summary>
    public static FabulousText Hidden => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Hidden, null);

    /// <summary>
    /// Initializes a new text object that will be styled with a horizontal strike through the middle of the text.
    /// </summary>
    public static FabulousText Strikethrough => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Strikethrough, null);

    #region Writer methods

    /// <summary>
    /// Writes the string representation of the object to the standard output stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    public static void Write(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.Write();
    }

    /// <summary>
    /// Writes the string to the standard output stream.
    /// </summary>
    /// <param name="text">Text to be printed to the console.</param>
    public static void Write(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.Write();
    }

    /// <summary>
    /// Writes the text representation of the specified array of objects to the standard output stream using the specified format information.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    public static void Write(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.Write(args);
    }

    /// <summary>
    /// Writes the styled text to the standard output stream.
    /// </summary>
    /// <param name="fragment">A piece of styled text.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void Write(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.Write();
    }

    /// <summary>
    /// Writes the text representation of the specified array of objects to the standard output stream using the specified styled text format information.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using <paramref name="fragment"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void Write(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.Write(args);
    }

    /// <summary>
    /// Writes the styled text to the standard output stream.
    /// </summary>
    /// <param name="collection">A collection of text to be styled.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void Write(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.Write();
    }

    /// <summary>
    /// Writes the string using the text representation of the specified array of objects to the standard output stream using the text as the specified format information.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void Write(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.Write(args);
    }

    /// <summary>
    /// Writes the string representation of the object followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    public static void WriteLine(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteLine();
    }

    /// <summary>
    /// Writes the string followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="text">Text to be printed to the console.</param>
    public static void WriteLine(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteLine();
    }

    /// <summary>
    /// Writes the string using the text representation of the specified array of objects to the standard output stream using the text as the specified format information. The current line terminator will also be printed to the standard output stream afterwards.
    /// </summary>
    /// <param name="format">A composite string format.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    public static void WriteLine(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteLine(args);
    }

    /// <summary>
    /// Writes the styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="fragment">A piece of styled text.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void WriteLine(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.WriteLine();
    }

    /// <summary>
    /// Writes the styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be printed to the standard output stream afterwards.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void WriteLine(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.WriteLine(args);
    }

    /// <summary>
    /// Writes the styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="collection">A collection of text to be styled.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void WriteLine(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.WriteLine();
    }

    /// <summary>
    /// Writes the string using the text representation of the specified array of objects to the standard output stream using the text as the specified format information.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void WriteLine(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.WriteLine(args);
    }

    /// <summary>
    /// Writes the string representation of the object to the standard error stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    public static void WriteError(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteError();
    }

    /// <summary>
    /// Writes the string to the standard error stream.
    /// </summary>
    /// <param name="text">Text to be printed to the console.</param>
    public static void WriteError(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteError();
    }

    /// <summary>
    /// Writes the string using the text representation of the specified array of objects to the standard error stream using the text as the specified format information.
    /// </summary>
    /// <param name="format">A composite string format.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    public static void WriteError(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteError(args);
    }

    /// <summary>
    /// Writes the styled text to the standard error stream.
    /// </summary>
    /// <param name="fragment">A piece of styled text.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void WriteError(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.WriteError();
    }

    /// <summary>
    /// Writes the string using the text representation of the specified array of objects to the standard error stream using the text as the specified format information.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using <paramref name="fragment"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void WriteError(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.WriteError(args);
    }

    /// <summary>
    /// Writes the styled text to the standard error stream.
    /// </summary>
    /// <param name="collection">A collection of text to be styled.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void WriteError(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.WriteError();
    }

    /// <summary>
    /// Writes the string using the text representation of the specified array of objects to the standard error stream using the text as the specified format information.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void WriteError(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.WriteError(args);
    }

    /// <summary>
    /// Asynchronously writes the text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    public static void WriteErrorLine(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteErrorLine();
    }

    /// <summary>
    /// Writes the string followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="text"></param>
    public static void WriteErrorLine(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteErrorLine();
    }

    /// <summary>
    /// Writes the string using the text representation of the specified array of objects to the standard error stream using the text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="format">A composite string format.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    public static void WriteErrorLine(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        writer.WriteErrorLine(args);
    }

    /// <summary>
    /// Writes the styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="fragment">A piece of styled text.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void WriteErrorLine(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.WriteErrorLine();
    }

    /// <summary>
    /// Writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using <paramref name="fragment"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static void WriteErrorLine(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        writer.WriteErrorLine(args);
    }

    /// <summary>
    /// Writes the styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="collection">A collection of text to be styled.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void WriteErrorLine(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.WriteErrorLine();
    }

    /// <summary>
    /// Writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static void WriteErrorLine(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        writer.WriteErrorLine(args);
    }

    /// <summary>
    /// Asynchronously writes the string representation of the object to the standard output stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteAsync(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteAsync();
    }

    /// <summary>
    /// Asynchronously writes the text to the standard output stream.
    /// </summary>
    /// <param name="text">Text to be printed to the console.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteAsync(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteAsync();
    }

    /// <summary>
    /// Asynchronously writes the string using the text representation of the specified array of objects to the standard output stream using the text as the specified format information.
    /// </summary>
    /// <param name="format">A composite string format.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteAsync(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the styled text to the standard output stream.
    /// </summary>
    /// <param name="fragment">A piece of styled text.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteAsync(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteAsync();
    }

    /// <summary>
    /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using the styled text format.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteAsync(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the styled text to the standard output stream.
    /// </summary>
    /// <param name="collection">A collection of text to be styled.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteAsync(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteAsync();
    }

    /// <summary>
    /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteAsync(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the string representation of the object followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteLineAsync(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the text followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="text">Text to be printed to the console.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteLineAsync(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the string using the text representation of the specified array of objects to the standard output stream using the text as the specified format information. The current line terminator will also be asynchronously printed to the standard output stream afterwards.
    /// </summary>
    /// <param name="format">A composite string format.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteLineAsync(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteLineAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="fragment">A piece of styled text.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteLineAsync(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard output stream afterwards.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using <paramref name="fragment"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteLineAsync(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteLineAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the styled text followed by the current line terminator to the standard output stream.
    /// </summary>
    /// <param name="collection">A collection of text to be styled.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteLineAsync(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard output stream afterwards.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteLineAsync(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteLineAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the string representation of the object to the standard error stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteErrorAsync(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorAsync();
    }

    /// <summary>
    /// Asynchronously writes the text to the standard error stream.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteErrorAsync(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorAsync();
    }

    /// <summary>
    /// Asynchronously writes the string using the text representation of the specified array of objects to the standard error stream using the text as the specified format information.
    /// </summary>
    /// <param name="format">A composite string format.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteErrorAsync(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the styled text to the standard error stream.
    /// </summary>
    /// <param name="fragment"></param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteErrorAsync(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteErrorAsync();
    }

    /// <summary>
    /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using <paramref name="fragment"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteErrorAsync(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteErrorAsync(args);
    }

    /// <summary>
    /// Asynchronously writes to the standard error stream.
    /// </summary>
    /// <param name="collection"></param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteErrorAsync(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorAsync();
    }

    /// <summary>
    /// Asynchronously writes the string using the text representation of the specified array of objects to the standard error stream using the text as the specified format information.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteErrorAsync(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the string representation of the object followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="obj">An object to be written to the console.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteErrorLineAsync(object obj)
    {
        FabulousText fragment = obj?.ToString();
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="text">Text to be printed to the console.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteErrorLineAsync(string text)
    {
        FabulousText fragment = text;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the string using the text representation of the specified array of objects to the standard error stream using the text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="format">A composite string format.</param>
    /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static Task WriteErrorLineAsync(string format, params object[] args)
    {
        FabulousText fragment = format;
        FabulousTextCollection collection = fragment;
        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorLineAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="fragment">A piece of styled text.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteErrorLineAsync(FabulousText fragment)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteErrorLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="fragment">A composite styled text format.</param>
    /// <param name="args">An array of objects to write using <paramref name="fragment"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
    public static Task WriteErrorLineAsync(FabulousText fragment, params object[] args)
    {
        if (fragment == null)
            throw new ArgumentNullException(nameof(fragment));

        var writer = GetConsoleWriter(fragment);
        return writer.WriteErrorLineAsync(args);
    }

    /// <summary>
    /// Asynchronously writes the styled text followed by the current line terminator to the standard error stream.
    /// </summary>
    /// <param name="collection">A collection of text to be styled.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteErrorLineAsync(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorLineAsync();
    }

    /// <summary>
    /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
    /// </summary>
    /// <param name="collection">A collection of composite styled text formats.</param>
    /// <param name="args">An array of objects to write using <paramref name="collection"/>.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
    public static Task WriteErrorLineAsync(FabulousTextCollection collection, params object[] args)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var writer = GetConsoleWriter(collection);
        return writer.WriteErrorLineAsync(args);
    }

    #endregion Writer methods

    private static IColor DefaultForeground { get; } = RgbConsoleColor.White;

    private static IColor DefaultBackground { get; } = RgbConsoleColor.Black;

    private static IConsoleWriter GetConsoleWriter(FabulousTextCollection collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        var consoleLevel = FabulousConsole.ColorLevel;
        switch (consoleLevel)
        {
            case ConsoleColorMode.None:
                return new UnstyledConsoleWriter(collection);
            case ConsoleColorMode.Standard:
                return new StandardConsoleWriter(collection);
            case ConsoleColorMode.Basic:
                var basicAnsi = new AnsiSimpleStringBuilder(collection);
                return new AnsiConsoleWriter(basicAnsi.ToAnsiString());
            case ConsoleColorMode.Enhanced:
                var enhancedText = new AnsiEnhancedStringBuilder(collection);
                return new AnsiConsoleWriter(enhancedText.ToAnsiString());
            case ConsoleColorMode.Full:
                var fullText = new AnsiFullStringBuilder(collection);
                return new AnsiConsoleWriter(fullText.ToAnsiString());
            default:
                throw new NotSupportedException("Unknown console support level: " + consoleLevel.ToString());
        }
    }
}