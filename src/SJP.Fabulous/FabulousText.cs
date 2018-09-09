using System;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;
using EnumsNET;
using System.Collections.Generic;

namespace SJP.Fabulous
{
    /// <summary>
    /// Represents a styled piece of text.
    /// </summary>
    public class FabulousText : IConsoleWriter, IEquatable<FabulousText>
    {
        /// <summary>
        /// Creates a styled piece of text.
        /// </summary>
        /// <param name="foreColor">The foreground color to use.</param>
        /// <param name="backColor">The background color to use.</param>
        /// <param name="decorations">The decorations to be applied to the text.</param>
        /// <param name="text">The text to be styled.</param>
        /// <param name="reset">Whether to reset the console to default styling before and after printing the text.</param>
        /// <exception cref="ArgumentNullException"><paramref name="foreColor"/> or <paramref name="backColor"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="decorations"/> is not a valid enum.</exception>
        public FabulousText(IColor foreColor, IColor backColor, TextDecoration decorations, string text, bool reset = false)
        {
            ForegroundColor = foreColor ?? throw new ArgumentNullException(nameof(foreColor));
            BackgroundColor = backColor ?? throw new ArgumentNullException(nameof(backColor));

            if (!decorations.IsValid())
                throw new ArgumentException($"The { nameof(TextDecoration) } provided must be a valid enum.", nameof(decorations));

            Decorations = decorations;
            ConsoleReset = reset;
            Text = text ?? string.Empty;
        }

        /// <summary>
        /// The color of the foreground text.
        /// </summary>
        public IColor ForegroundColor { get; }

        /// <summary>
        /// The color of the background text.
        /// </summary>
        public IColor BackgroundColor { get; }

        /// <summary>
        /// A collection of styles that may be applied to the console.
        /// </summary>
        public TextDecoration Decorations { get; }

        /// <summary>
        /// If true, will reset all styling on the console before and after printing this text object.
        /// </summary>
        public bool ConsoleReset { get; }

        /// <summary>
        /// The text that will be styled.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Styles the text with a new foreground color in the RGB colorspace.
        /// </summary>
        /// <param name="values">A tuple containing RGB color components.</param>
        /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
        public FabulousText Rgb((byte red, byte green, byte blue) values)=> Rgb(values.red, values.green, values.blue);

        /// <summary>
        /// Styles the text with a new foreground color in the RGB colorspace.
        /// </summary>
        /// <param name="red">The red component of the foreground color</param>
        /// <param name="green">The green component of the foreground color</param>
        /// <param name="blue">The blue component of the foreground color</param>
        /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
        public FabulousText Rgb(byte red, byte green, byte blue)
        {
            var foreColor = new Rgb(red, green, blue);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Styles the text with a new foreground color as defined by a hexadecimal string in the RGB colorspace.
        /// </summary>
        /// <param name="hex">A hexadecimal string representing a color in the RGB colorspace.</param>
        /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hex"/> is <c>null</c>, empty, or whitespace.</exception>
        public FabulousText Hex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var foreColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Styles the text with a new foreground color as defined by a named CSS color in the RGB colorspace.
        /// </summary>
        /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
        /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keyword"/> is <c>null</c>, empty, or whitespace.</exception>
        public FabulousText Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Styles the text with a new foreground color as defined by a named CSS color in the RGB colorspace.
        /// </summary>
        /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
        /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
        /// <exception cref="ArgumentException"><paramref name="keyword"/> is not a valid enum.</exception>
        public FabulousText Keyword(ColorKeyword keyword)
        {
            if (!keyword.IsValid())
                throw new ArgumentException($"The { nameof(ColorKeyword) } object is not set to a valid value.", nameof(keyword));

            var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a black foreground color.
        /// </summary>
        public FabulousText Black => new FabulousText(RgbConsoleColor.Black, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a red foreground color.
        /// </summary>
        public FabulousText Red => new FabulousText(RgbConsoleColor.DarkRed, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a green foreground color.
        /// </summary>
        public FabulousText Green => new FabulousText(RgbConsoleColor.DarkGreen, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a yellow foreground color.
        /// </summary>
        public FabulousText Yellow => new FabulousText(RgbConsoleColor.DarkYellow, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a blue foreground color.
        /// </summary>
        public FabulousText Blue => new FabulousText(RgbConsoleColor.DarkBlue, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a magenta foreground color.
        /// </summary>
        public FabulousText Magenta => new FabulousText(RgbConsoleColor.DarkMagenta, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a cyan foreground color.
        /// </summary>
        public FabulousText Cyan => new FabulousText(RgbConsoleColor.DarkCyan, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a white foreground color.
        /// </summary>
        public FabulousText White => new FabulousText(RgbConsoleColor.White, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a gray foreground color.
        /// </summary>
        public FabulousText Gray => new FabulousText(RgbConsoleColor.DarkGrey, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a grey foreground color.
        /// </summary>
        public FabulousText Grey => new FabulousText(RgbConsoleColor.DarkGrey, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright red foreground color.
        /// </summary>
        public FabulousText RedBright => new FabulousText(RgbConsoleColor.Red, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright green foreground color.
        /// </summary>
        public FabulousText GreenBright => new FabulousText(RgbConsoleColor.Green, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright yellow foreground color.
        /// </summary>
        public FabulousText YellowBright => new FabulousText(RgbConsoleColor.Yellow, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright blue foreground color.
        /// </summary>
        public FabulousText BlueBright => new FabulousText(RgbConsoleColor.Blue, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright magenta foreground color.
        /// </summary>
        public FabulousText MagentaBright => new FabulousText(RgbConsoleColor.Magenta, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright cyan foreground color.
        /// </summary>
        public FabulousText CyanBright => new FabulousText(RgbConsoleColor.Cyan, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright white foreground color.
        /// </summary>
        public FabulousText WhiteBright => new FabulousText(RgbConsoleColor.WhiteBright, BackgroundColor, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Styles the text with a new background color in the RGB colorspace.
        /// </summary>
        /// <param name="values">A tuple containing RGB color components.</param>
        /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
        public FabulousText BgRgb((byte red, byte green, byte blue) values) => BgRgb(values.red, values.green, values.blue);

        /// <summary>
        /// Styles the text with a new background color in the RGB colorspace.
        /// </summary>
        /// <param name="red">The red component of the background color</param>
        /// <param name="green">The green component of the background color</param>
        /// <param name="blue">The blue component of the background color</param>
        /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
        public FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new Rgb(red, green, blue);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Styles the text with a new background color as defined by a hexadecimal string in the RGB colorspace.
        /// </summary>
        /// <param name="hex">A hexadecimal string representing a color in the RGB colorspace.</param>
        /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hex"/> is <c>null</c>, empty, or whitespace.</exception>
        public FabulousText BgHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var bgColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Styles the text with a new background color as defined by a named CSS color in the RGB colorspace.
        /// </summary>
        /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
        /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keyword"/> is <c>null</c>, empty, or whitespace.</exception>
        public FabulousText BgKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Styles the text with a new background color as defined by a named CSS color in the RGB colorspace.
        /// </summary>
        /// <param name="keyword">A named color, as defined in https://drafts.csswg.org/css-color/#named-colors </param>
        /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
        /// <exception cref="ArgumentException"><paramref name="keyword"/> is not a valid enum.</exception>
        public FabulousText BgKeyword(ColorKeyword keyword)
        {
            if (!keyword.IsValid())
                throw new ArgumentException($"The { nameof(ColorKeyword) } object is not set to a valid value.", nameof(keyword));

            var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text, ConsoleReset);
        }

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a black background color.
        /// </summary>
        public FabulousText BgBlack => new FabulousText(ForegroundColor, RgbConsoleColor.Black, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a red background color.
        /// </summary>
        public FabulousText BgRed => new FabulousText(ForegroundColor, RgbConsoleColor.DarkRed, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a green background color.
        /// </summary>
        public FabulousText BgGreen => new FabulousText(ForegroundColor, RgbConsoleColor.DarkGreen, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a yellow background color.
        /// </summary>
        public FabulousText BgYellow => new FabulousText(ForegroundColor, RgbConsoleColor.DarkYellow, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a blue background color.
        /// </summary>
        public FabulousText BgBlue => new FabulousText(ForegroundColor, RgbConsoleColor.DarkBlue, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a magenta background color.
        /// </summary>
        public FabulousText BgMagenta => new FabulousText(ForegroundColor, RgbConsoleColor.DarkMagenta, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a cyan background color.
        /// </summary>
        public FabulousText BgCyan => new FabulousText(ForegroundColor, RgbConsoleColor.DarkCyan, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a white background color.
        /// </summary>
        public FabulousText BgWhite => new FabulousText(ForegroundColor, RgbConsoleColor.White, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a gray background color.
        /// </summary>
        public FabulousText BgGray => new FabulousText(ForegroundColor, RgbConsoleColor.Grey, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a grey background color.
        /// </summary>
        public FabulousText BgGrey => new FabulousText(ForegroundColor, RgbConsoleColor.Grey, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright red background color.
        /// </summary>
        public FabulousText BgRedBright => new FabulousText(ForegroundColor, RgbConsoleColor.Red, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright green background color.
        /// </summary>
        public FabulousText BgGreenBright => new FabulousText(ForegroundColor, RgbConsoleColor.Green, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright yellow background color.
        /// </summary>
        public FabulousText BgYellowBright => new FabulousText(ForegroundColor, RgbConsoleColor.Yellow, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright blue background color.
        /// </summary>
        public FabulousText BgBlueBright => new FabulousText(ForegroundColor, RgbConsoleColor.Blue, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright magenta background color.
        /// </summary>
        public FabulousText BgMagentaBright => new FabulousText(ForegroundColor, RgbConsoleColor.Magenta, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright cyan background color.
        /// </summary>
        public FabulousText BgCyanBright => new FabulousText(ForegroundColor, RgbConsoleColor.Cyan, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bright white background color.
        /// </summary>
        public FabulousText BgWhiteBright => new FabulousText(ForegroundColor, RgbConsoleColor.WhiteBright, Decorations, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but will reset the console to default styling before and after printing the text.
        /// </summary>
        public FabulousText Reset => new FabulousText(ForegroundColor, BackgroundColor, Decorations, Text, true);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but will cause the text to blink when printed.
        /// </summary>
        public FabulousText Blink => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Blink, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with a bold font weight.
        /// </summary>
        public FabulousText Bold => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Bold, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with dimmed text.
        /// </summary>
        public FabulousText Dim => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Dim, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but text styled in italic form.
        /// </summary>
        public FabulousText Italic => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Italic, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with the text being underlined when printed.
        /// </summary>
        public FabulousText Underline => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Underline, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with the text concealed when printed.
        /// </summary>
        public FabulousText Hidden => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Hidden, Text, ConsoleReset);

        /// <summary>
        /// Returns a new text object that is the same as the current object, but with the text styled with a horizontal strike through the middle of the text.
        /// </summary>
        public FabulousText Strikethrough => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Strikethrough, Text, ConsoleReset);

        /// <summary>
        /// Initializes text styling from a <see cref="string"/> object.
        /// </summary>
        /// <param name="text">Text in the form of a <see cref="string"/> object.</param>
        public static implicit operator FabulousText(string text) => new FabulousText(RgbConsoleColor.White, RgbConsoleColor.Black, TextDecoration.None, text);

        /// <summary>
        /// Combines two styled text objects.
        /// </summary>
        /// <param name="fragmentA">A styled piece of text.</param>
        /// <param name="fragmentB">A styled piece of text.</param>
        /// <returns>An object representing a collection of styled text objects.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="fragmentA"/> or <paramref name="fragmentB"/> is <c>null</c>.</exception>
        public static FabulousTextCollection operator +(FabulousText fragmentA, FabulousText fragmentB)
        {
            if (fragmentA == null)
                throw new ArgumentNullException(nameof(fragmentA));
            if (fragmentB == null)
                throw new ArgumentNullException(nameof(fragmentB));

            return new FabulousTextCollection(fragmentA, fragmentB);
        }

        /// <summary>
        /// Equality operator for FabulousText objects
        /// </summary>
        /// <param name="a">A FabulousText object.</param>
        /// <param name="b">Another FabulousText object.</param>
        /// <returns><c>true</c> if all of the value properties of the FabulousText objects are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==(FabulousText a, FabulousText b)
        {
            var aIsNull = a is null;
            var bIsNull = b is null;

            if (aIsNull && bIsNull)
                return true;

            if (aIsNull ^ bIsNull)
                return false;

            if (ReferenceEquals(a, b))
                return true;

            return a.Equals(b);
        }

        /// <summary>
        /// Inequality operator for FabulousText objects
        /// </summary>
        /// <param name="a">A FabulousText object.</param>
        /// <param name="b">Another FabulousText object.</param>
        /// <returns><c>false</c> if all of the value properties of the FabulousText objects are equal, otherwise <c>true</c>.</returns>
        public static bool operator !=(FabulousText a, FabulousText b) => !(a == b);

        /// <summary>
        /// Indicates whether the FabulousText object is equal to another text object.
        /// </summary>
        /// <returns><c>true</c> if the FabulousText object is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c>.</returns>
        /// <param name="other">A FabulousText object to compare with this object.</param>
        public bool Equals(FabulousText other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return _colorComparer.Equals(ForegroundColor, other.ForegroundColor)
                && _colorComparer.Equals(BackgroundColor, other.BackgroundColor)
                && Decorations == other.Decorations
                && ConsoleReset == other.ConsoleReset
                && Text == other.Text;
        }

        private static readonly IEqualityComparer<IColor> _colorComparer = EqualityComparer<IColor>.Default;

        /// <summary>
        /// Determines whether the specified object is equal to the current FabulousText object.
        /// </summary>
        /// <returns><c>true</c> if the specified object is equal to the current FabulousText object; otherwise, <c>false</c>.</returns>
        /// <param name="obj">The object to compare with the current FabulousText object.</param>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as FabulousText);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the FabulousText object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 17;

                result = (result * 31) + ForegroundColor.GetHashCode();
                result = (result * 31) + BackgroundColor.GetHashCode();
                result = (result * 31) + Decorations.GetHashCode();
                result = (result * 31) + ConsoleReset.GetHashCode();
                return (result * 31) + Text.GetHashCode();
            }
        }

        #region IConsoleWriter

        /// <summary>
        /// Writes the styled text to the standard output stream.
        /// </summary>
        public void Write() => Fabulous.Write(this);

        /// <summary>
        /// Writes using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void Write(params object[] args) => Fabulous.Write(this, args);

        /// <summary>
        /// Writes the styled text followed by the current line terminator to the standard output stream.
        /// </summary>
        public void WriteLine() => Fabulous.WriteLine(this);

        /// <summary>
        /// Writes the styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be printed to standard output stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteLine(params object[] args) => Fabulous.WriteLine(this, args);

        /// <summary>
        /// Writes the styled text to the standard error stream.
        /// </summary>
        public void WriteError() => Fabulous.WriteError(this);

        /// <summary>
        /// Writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteError(params object[] args) => Fabulous.WriteError(this, args);

        /// <summary>
        /// Writes the styled text followed by the current line terminator to the standard error stream.
        /// </summary>
        public void WriteErrorLine() => Fabulous.WriteErrorLine(this);

        /// <summary>
        /// Writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteErrorLine(params object[] args) => Fabulous.WriteErrorLine(this, args);

        /// <summary>
        /// Asynchronously writes the styled text to the standard output stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteAsync() => Fabulous.WriteAsync(this);

        /// <summary>
        /// Asynchronously writes using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteAsync(params object[] args) => Fabulous.WriteAsync(this, args);

        /// <summary>
        /// Asynchronously writes the styled text followed by the current line terminator to the standard output stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteLineAsync() => Fabulous.WriteLineAsync(this);

        /// <summary>
        /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to standard output stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteLineAsync(params object[] args) => Fabulous.WriteLineAsync(this, args);

        /// <summary>
        /// Asynchronously writes the styled text to the standard error stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteErrorAsync() => Fabulous.WriteErrorAsync(this);

        /// <summary>
        /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>

        public Task WriteErrorAsync(params object[] args) => Fabulous.WriteErrorAsync(this, args);

        /// <summary>
        /// Asynchronously writes the styled text followed by the current line terminator to the standard error stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteErrorLineAsync() => Fabulous.WriteErrorLineAsync(this);

        /// <summary>
        /// Asynchronously writes the styled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteErrorLineAsync(params object[] args) => Fabulous.WriteErrorLineAsync(this, args);

        #endregion IConsoleWriter
    }
}
