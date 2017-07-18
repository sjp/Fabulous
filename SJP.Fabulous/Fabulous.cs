using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
//using ColorMine;

namespace SJP.Fabulous
{
    public static class Fabulous
    {
        public static FabulousText Foreground(RgbColor foreColor)
        {
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Background(RgbColor backColor)
        {
            return new FabulousText(DefaultForeground, backColor, TextDecoration.None, null);
        }

        public static FabulousText Text(string text)
        {
            return new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.None, text);
        }

        // FG styling
        public static FabulousText Rgb(byte red, byte green, byte blue)
        {
            var foreColor = new RgbColor(red, green, blue);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Rgb((byte red, byte green, byte blue) values)
        {
            var foreColor = new RgbColor(values);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Hex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var foreColor = RgbColor.FromHex(hex);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var foreColor = RgbColor.FromKeyword(keyword);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Black => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Red => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Green => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Yellow => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Blue => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Magenta => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Cyan => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText White => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        // bright black
        public static FabulousText Gray => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Grey => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText RedBright => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText GreenBright => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText YellowBright => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText BlueBright => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText MagentaBright => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText CyanBright => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText WhiteBright => new FabulousText(new RgbColor(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        // BG styling
        public static FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new RgbColor(red, green, blue);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgRgb((byte red, byte green, byte blue) values)
        {
            var bgColor = new RgbColor(values);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var bgColor = RgbColor.FromHex(hex);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var bgColor = RgbColor.FromKeyword(keyword);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgBlack => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgRed => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGreen => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgYellow => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgBlue => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgMagenta => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgCyan => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgWhite => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        // bright black
        public static FabulousText BgGray => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGrey => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgRedBright => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGreenBright => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgYellowBright => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgBlueBright => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgMagentaBright => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgCyanBright => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgWhiteBright => new FabulousText(DefaultForeground, new RgbColor(0, 0, 0), TextDecoration.None, null);

        // decorations
        public static FabulousText Blink => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Blink, null);

        public static FabulousText Bold => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Bold, null);

        public static FabulousText Dim => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Dim, null);

        public static FabulousText Italic => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Italic, null);

        public static FabulousText Underline => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Underline, null);

        public static FabulousText Hidden => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Hidden, null);

        public static FabulousText Strikethrough => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Strikethrough, null);

        public static void Write(object obj)
        {
            FabulousText fragment = obj?.ToString();
            FabulousTextCollection collection = fragment;
            Write(collection);
        }

        public static void Write(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;
            Write(collection);
        }

        public static void Write(string format, params object[] args)
        {
            FabulousText fragment = format;
            FabulousTextCollection collection = fragment;
            Write(collection, args);
        }

        public static void Write(FabulousText fragment)
        {
            FabulousTextCollection collection = fragment;
            Write(collection);
        }

        public static void Write(FabulousText fragment, params object[] args)
        {
            FabulousTextCollection collection = fragment;
            Write(collection, args);
        }

        public static void Write(FabulousTextCollection collection)
        {
            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

                Console.Write(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }

        public static void Write(FabulousTextCollection collection, params object[] args)
        {
            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

                Console.Write(f.Text, args);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }

        public static void WriteLine(object obj)
        {
            FabulousText fragment = obj?.ToString();
            FabulousTextCollection collection = fragment;
            WriteLine(collection);
        }

        public static void WriteLine(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;
            WriteLine(collection);
        }

        public static void WriteLine(string format, params object[] args)
        {
            FabulousText fragment = format;
            FabulousTextCollection collection = fragment;
            WriteLine(collection, args);
        }

        public static void WriteLine(FabulousText fragment)
        {
            FabulousTextCollection collection = fragment;
            WriteLine(collection);
        }

        public static void WriteLine(FabulousText fragment, params object[] args)
        {
            FabulousTextCollection collection = fragment;
            WriteLine(collection, args);
        }

        public static void WriteLine(FabulousTextCollection collection)
        {
            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;

                Console.Write(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }

            Console.Write("\r\n");
        }

        public static void WriteLine(FabulousTextCollection collection, params object[] args)
        {
            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;

                Console.Write(f.Text, args);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }

            Console.Write("\r\n");
        }

        private static RgbColor DefaultForeground { get; } = new RgbColor(192, 192, 192);

        private static RgbColor DefaultBackground { get; } = new RgbColor(0, 0, 0);
    }

    public class FabulousText
    {
        public FabulousText(RgbColor foreColor, RgbColor backColor, TextDecoration decorations, string text)
        {
            ForegroundColor = foreColor;
            BackgroundColor = backColor;
            Decorations = decorations;
            Text = text ?? string.Empty;
        }

        internal RgbColor ForegroundColor { get; }

        internal RgbColor BackgroundColor { get; }

        internal TextDecoration Decorations { get; }

        public string Text { get; }

        public void Write() => Fabulous.Write(this);

        public void Write(params object[] args) => Fabulous.Write(this, args);

        public void WriteLine() => Fabulous.WriteLine(this);

        public void WriteLine(params object[] args) => Fabulous.WriteLine(this, args);

        // FG styling
        public FabulousText Rgb(byte red, byte green, byte blue)
        {
            var foreColor = new RgbColor(red, green, blue);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text);
        }

        public FabulousText Hex(string hex)
        {
            var foreColor = RgbColor.FromHex(hex);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text);
        }

        public FabulousText Keyword(string keyword)
        {
            var foreColor = RgbColor.FromKeyword(keyword);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text);
        }

        public FabulousText Black => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Red => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Green => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Yellow => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Blue => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Magenta => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Cyan => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText White => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        // bright black
        public FabulousText Gray => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Grey => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText RedBright => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText GreenBright => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText YellowBright => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText BlueBright => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText MagentaBright => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText CyanBright => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText WhiteBright => new FabulousText(new RgbColor(192, 192, 192), BackgroundColor, Decorations, Text);

        // BG styling
        public FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new RgbColor(red, green, blue);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text);
        }

        public FabulousText BgHex(string hex)
        {
            var bgColor = RgbColor.FromHex(hex);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text);
        }

        public FabulousText BgKeyword(string keyword)
        {
            var bgColor = RgbColor.FromKeyword(keyword);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text);
        }

        public FabulousText BgBlack => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgRed => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgGreen => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgYellow => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgBlue => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgMagenta => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgCyan => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgWhite => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        // bright black
        public FabulousText BgGray => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgGrey => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgRedBright => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgGreenBright => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgYellowBright => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgBlueBright => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgMagentaBright => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgCyanBright => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        public FabulousText BgWhiteBright => new FabulousText(ForegroundColor, new RgbColor(0, 0, 0), Decorations, Text);

        // decorations
        public FabulousText Blink => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Blink, Text);

        public FabulousText Bold => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Bold, Text);

        public FabulousText Dim => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Dim, Text);

        public FabulousText Italic => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Italic, Text);

        public FabulousText Underline => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Underline, Text);

        public FabulousText Hidden => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Hidden, Text);

        public FabulousText Strikethrough => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Strikethrough, Text);

        public static implicit operator FabulousText(string text)
        {
            return new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.None, text);
        }

        public static FabulousTextCollection operator +(FabulousText fragmentA, FabulousText fragmentB)
        {
            return new FabulousTextCollection(fragmentA, fragmentB);
        }
    }

    public static class TextFragmentExtensions
    {
        public static FabulousText Foreground(this FabulousText fragment, RgbColor foreColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(foreColor, fragment.BackgroundColor, fragment.Decorations, fragment.Text);
        }

        public static FabulousText Background(this FabulousText fragment, RgbColor backColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(fragment.ForegroundColor, backColor, fragment.Decorations, fragment.Text);
        }

        public static FabulousText Text(this FabulousText fragment, string text)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(fragment.ForegroundColor, fragment.BackgroundColor, fragment.Decorations, text);
        }
    }

    public class FabulousTextCollection : IEnumerable<FabulousText>
    {
        public FabulousTextCollection(params FabulousText[] fragments)
            : this(fragments as IEnumerable<FabulousText>)
        {
        }

        public FabulousTextCollection(IEnumerable<FabulousText> fragments)
        {
            Fragments = fragments ?? throw new ArgumentNullException(nameof(fragments));
        }

        public IEnumerable<FabulousText> Fragments { get; }

        public void Write() => Fabulous.Write(this);

        public void WriteLine() => Fabulous.WriteLine(this);

        public static implicit operator FabulousTextCollection(string text)
        {
            FabulousText fragment = text;
            return new FabulousTextCollection(fragment);
        }

        public static implicit operator FabulousTextCollection(FabulousText fragment)
        {
            return new FabulousTextCollection(fragment);
        }

        public static FabulousTextCollection operator +(FabulousTextCollection collection, FabulousText fragment)
        {
            var fragments = new List<FabulousText>(collection.Fragments) { fragment };
            return new FabulousTextCollection(fragments);
        }

        public IEnumerator<FabulousText> GetEnumerator() => Fragments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Fragments.GetEnumerator();
    }

    [Flags]
    public enum TextDecoration
    {
        None            = 0,
        Blink           = 1 << 0,
        Bold            = 1 << 1,
        Dim             = 1 << 2,
        Italic          = 1 << 3,
        Underline       = 1 << 4,
        Hidden          = 1 << 5,
        Strikethrough   = 1 << 6
    }

    // hex, bghex,
    // rgb, bgrgb
    public enum FabColors
    {
        Black,
        Red,
        Green,
        Yellow,
        Blue, //*(On Windows the bright version is used since normal blue is illegible)*
        Magenta,
        Cyan,
        White,
        Gray, // ("bright black")
        Grey,
        RedBright,
        GreenBright,
        YellowBright,
        BlueBright,
        MagentaBright,
        CyanBright,
        WhiteBright
    }

    // dummy for now until we get a proper color solution,
    // i.e. one that can span something like the HCL colorspace for color matching
    public struct RgbColor
    {
        public RgbColor((byte red, byte green, byte blue) values)
            : this(values.red, values.green, values.blue)
        {
        }

        public RgbColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }

        public static RgbColor FromHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            if (hex.Length < 3)
                throw new ArgumentException("hex string does not have enough characters", nameof(hex));

            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 3 && hex.Length != 6)
                throw new ArgumentException("hex string is not the right length, must either be 3 or 6 hexadecimal characters.", nameof(hex));

            var inputLength = hex.Length;

            var rStr = string.Empty;
            var gStr = string.Empty;
            var bStr = string.Empty;

            if (inputLength == 3)
            {
                rStr = new string(hex[0], 2);
                gStr = new string(hex[1], 2);
                bStr = new string(hex[2], 2);
            }
            else if (inputLength == 6)
            {
                rStr = hex.Substring(0, 2);
                gStr = hex.Substring(2, 2);
                bStr = hex.Substring(4, 2);
            }

            var isValidHex = true;
            isValidHex &= byte.TryParse(rStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out byte r);
            isValidHex &= byte.TryParse(gStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out byte g);
            isValidHex &= byte.TryParse(bStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out byte b);

            if (!isValidHex)
                throw new ArgumentException("hex string contains invalid hex characters", nameof(hex));

            return new RgbColor(r, g, b);
        }

        public static RgbColor FromKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            if (!_keywordColors.ContainsKey(keyword))
                throw new ArgumentOutOfRangeException(nameof(keyword), "Unknown keyword for color: " + keyword);

            return _keywordColors[keyword];
        }

        private readonly static IReadOnlyDictionary<string, RgbColor> _keywordColors = new Dictionary<string, RgbColor>(StringComparer.OrdinalIgnoreCase)
        {
            ["aliceblue"] = new RgbColor(240, 248, 255),
            ["antiquewhite"] = new RgbColor(250, 235, 215),
            ["aqua"] = new RgbColor(0, 255, 255),
            ["aquamarine"] = new RgbColor(127, 255, 212),
            ["azure"] = new RgbColor(240, 255, 255),
            ["beige"] = new RgbColor(245, 245, 220),
            ["bisque"] = new RgbColor(255, 228, 196),
            ["black"] = new RgbColor(0, 0, 0),
            ["blanchedalmond"] = new RgbColor(255, 235, 205),
            ["blue"] = new RgbColor(0, 0, 255),
            ["blueviolet"] = new RgbColor(138, 43, 226),
            ["brown"] = new RgbColor(165, 42, 42),
            ["burlywood"] = new RgbColor(222, 184, 135),
            ["cadetblue"] = new RgbColor(95, 158, 160),
            ["chartreuse"] = new RgbColor(127, 255, 0),
            ["chocolate"] = new RgbColor(210, 105, 30),
            ["coral"] = new RgbColor(255, 127, 80),
            ["cornflowerblue"] = new RgbColor(100, 149, 237),
            ["cornsilk"] = new RgbColor(255, 248, 220),
            ["crimson"] = new RgbColor(220, 20, 60),
            ["cyan"] = new RgbColor(0, 255, 255),
            ["darkblue"] = new RgbColor(0, 0, 139),
            ["darkcyan"] = new RgbColor(0, 139, 139),
            ["darkgoldenrod"] = new RgbColor(184, 134, 11),
            ["darkgray"] = new RgbColor(169, 169, 169),
            ["darkgreen"] = new RgbColor(0, 100, 0),
            ["darkgrey"] = new RgbColor(169, 169, 169),
            ["darkkhaki"] = new RgbColor(189, 183, 107),
            ["darkmagenta"] = new RgbColor(139, 0, 139),
            ["darkolivegreen"] = new RgbColor(85, 107, 47),
            ["darkorange"] = new RgbColor(255, 140, 0),
            ["darkorchid"] = new RgbColor(153, 50, 204),
            ["darkred"] = new RgbColor(139, 0, 0),
            ["darksalmon"] = new RgbColor(233, 150, 122),
            ["darkseagreen"] = new RgbColor(143, 188, 143),
            ["darkslateblue"] = new RgbColor(72, 61, 139),
            ["darkslategray"] = new RgbColor(47, 79, 79),
            ["darkslategrey"] = new RgbColor(47, 79, 79),
            ["darkturquoise"] = new RgbColor(0, 206, 209),
            ["darkviolet"] = new RgbColor(148, 0, 211),
            ["deeppink"] = new RgbColor(255, 20, 147),
            ["deepskyblue"] = new RgbColor(0, 191, 255),
            ["dimgray"] = new RgbColor(105, 105, 105),
            ["dimgrey"] = new RgbColor(105, 105, 105),
            ["dodgerblue"] = new RgbColor(30, 144, 255),
            ["firebrick"] = new RgbColor(178, 34, 34),
            ["floralwhite"] = new RgbColor(255, 250, 240),
            ["forestgreen"] = new RgbColor(34, 139, 34),
            ["fuchsia"] = new RgbColor(255, 0, 255),
            ["gainsboro"] = new RgbColor(220, 220, 220),
            ["ghostwhite"] = new RgbColor(248, 248, 255),
            ["gold"] = new RgbColor(255, 215, 0),
            ["goldenrod"] = new RgbColor(218, 165, 32),
            ["gray"] = new RgbColor(128, 128, 128),
            ["green"] = new RgbColor(0, 128, 0),
            ["greenyellow"] = new RgbColor(173, 255, 47),
            ["grey"] = new RgbColor(128, 128, 128),
            ["honeydew"] = new RgbColor(240, 255, 240),
            ["hotpink"] = new RgbColor(255, 105, 180),
            ["indianred"] = new RgbColor(205, 92, 92),
            ["indigo"] = new RgbColor(75, 0, 130),
            ["ivory"] = new RgbColor(255, 255, 240),
            ["khaki"] = new RgbColor(240, 230, 140),
            ["lavender"] = new RgbColor(230, 230, 250),
            ["lavenderblush"] = new RgbColor(255, 240, 245),
            ["lawngreen"] = new RgbColor(124, 252, 0),
            ["lemonchiffon"] = new RgbColor(255, 250, 205),
            ["lightblue"] = new RgbColor(173, 216, 230),
            ["lightcoral"] = new RgbColor(240, 128, 128),
            ["lightcyan"] = new RgbColor(224, 255, 255),
            ["lightgoldenrodyellow"] = new RgbColor(250, 250, 210),
            ["lightgray"] = new RgbColor(211, 211, 211),
            ["lightgreen"] = new RgbColor(144, 238, 144),
            ["lightgrey"] = new RgbColor(211, 211, 211),
            ["lightpink"] = new RgbColor(255, 182, 193),
            ["lightsalmon"] = new RgbColor(255, 160, 122),
            ["lightseagreen"] = new RgbColor(32, 178, 170),
            ["lightskyblue"] = new RgbColor(135, 206, 250),
            ["lightslategray"] = new RgbColor(119, 136, 153),
            ["lightslategrey"] = new RgbColor(119, 136, 153),
            ["lightsteelblue"] = new RgbColor(176, 196, 222),
            ["lightyellow"] = new RgbColor(255, 255, 224),
            ["lime"] = new RgbColor(0, 255, 0),
            ["limegreen"] = new RgbColor(50, 205, 50),
            ["linen"] = new RgbColor(250, 240, 230),
            ["magenta"] = new RgbColor(255, 0, 255),
            ["maroon"] = new RgbColor(128, 0, 0),
            ["mediumaquamarine"] = new RgbColor(102, 205, 170),
            ["mediumblue"] = new RgbColor(0, 0, 205),
            ["mediumorchid"] = new RgbColor(186, 85, 211),
            ["mediumpurple"] = new RgbColor(147, 112, 219),
            ["mediumseagreen"] = new RgbColor(60, 179, 113),
            ["mediumslateblue"] = new RgbColor(123, 104, 238),
            ["mediumspringgreen"] = new RgbColor(0, 250, 154),
            ["mediumturquoise"] = new RgbColor(72, 209, 204),
            ["mediumvioletred"] = new RgbColor(199, 21, 133),
            ["midnightblue"] = new RgbColor(25, 25, 112),
            ["mintcream"] = new RgbColor(245, 255, 250),
            ["mistyrose"] = new RgbColor(255, 228, 225),
            ["moccasin"] = new RgbColor(255, 228, 181),
            ["navajowhite"] = new RgbColor(255, 222, 173),
            ["navy"] = new RgbColor(0, 0, 128),
            ["oldlace"] = new RgbColor(253, 245, 230),
            ["olive"] = new RgbColor(128, 128, 0),
            ["olivedrab"] = new RgbColor(107, 142, 35),
            ["orange"] = new RgbColor(255, 165, 0),
            ["orangered"] = new RgbColor(255, 69, 0),
            ["orchid"] = new RgbColor(218, 112, 214),
            ["palegoldenrod"] = new RgbColor(238, 232, 170),
            ["palegreen"] = new RgbColor(152, 251, 152),
            ["paleturquoise"] = new RgbColor(175, 238, 238),
            ["palevioletred"] = new RgbColor(219, 112, 147),
            ["papayawhip"] = new RgbColor(255, 239, 213),
            ["peachpuff"] = new RgbColor(255, 218, 185),
            ["peru"] = new RgbColor(205, 133, 63),
            ["pink"] = new RgbColor(255, 192, 203),
            ["plum"] = new RgbColor(221, 160, 221),
            ["powderblue"] = new RgbColor(176, 224, 230),
            ["purple"] = new RgbColor(128, 0, 128),
            ["rebeccapurple"] = new RgbColor(102, 51, 153),
            ["red"] = new RgbColor(255, 0, 0),
            ["rosybrown"] = new RgbColor(188, 143, 143),
            ["royalblue"] = new RgbColor(65, 105, 225),
            ["saddlebrown"] = new RgbColor(139, 69, 19),
            ["salmon"] = new RgbColor(250, 128, 114),
            ["sandybrown"] = new RgbColor(244, 164, 96),
            ["seagreen"] = new RgbColor(46, 139, 87),
            ["seashell"] = new RgbColor(255, 245, 238),
            ["sienna"] = new RgbColor(160, 82, 45),
            ["silver"] = new RgbColor(192, 192, 192),
            ["skyblue"] = new RgbColor(135, 206, 235),
            ["slateblue"] = new RgbColor(106, 90, 205),
            ["slategray"] = new RgbColor(112, 128, 144),
            ["slategrey"] = new RgbColor(112, 128, 144),
            ["snow"] = new RgbColor(255, 250, 250),
            ["springgreen"] = new RgbColor(0, 255, 127),
            ["steelblue"] = new RgbColor(70, 130, 180),
            ["tan"] = new RgbColor(210, 180, 140),
            ["teal"] = new RgbColor(0, 128, 128),
            ["thistle"] = new RgbColor(216, 191, 216),
            ["tomato"] = new RgbColor(255, 99, 71),
            ["turquoise"] = new RgbColor(64, 224, 208),
            ["violet"] = new RgbColor(238, 130, 238),
            ["wheat"] = new RgbColor(245, 222, 179),
            ["white"] = new RgbColor(255, 255, 255),
            ["whitesmoke"] = new RgbColor(245, 245, 245),
            ["yellow"] = new RgbColor(255, 255, 0),
            ["yellowgreen"] = new RgbColor(154, 205, 50)
        };
    }

    public static class AnsiModifiers
    {
        public static ConsoleStyle Reset { get; } = new ConsoleStyle(0, 0);

        // 21 isn't widely supported and 22 does the same thing
        public static ConsoleStyle Bold { get; } = new ConsoleStyle(1, 22);

        public static ConsoleStyle Dim { get; } = new ConsoleStyle(2, 22);

        public static ConsoleStyle Italic { get; } = new ConsoleStyle(3, 23);

        public static ConsoleStyle Underline { get; } = new ConsoleStyle(4, 24);

        public static ConsoleStyle Inverse { get; } = new ConsoleStyle(7, 27);

        public static ConsoleStyle Hidden { get; } = new ConsoleStyle(8, 28);

        public static ConsoleStyle Strikethrough { get; } = new ConsoleStyle(9, 29);
    }

    public static class Ansi256ColorMap
    {
        public static ConsoleStyle ForegroundFlags = new ConsoleStyle(31, 39);

        public static ConsoleStyle BackgroundFlags = new ConsoleStyle(41, 49);

        public static class Foreground
        {
            public static int Black { get; } = 30;

            public static int Red { get; } = 31;

            public static int Green { get; } = 32;

            public static int Yellow { get; } = 33;

            public static int Blue { get; } = 34;

            public static int Magenta { get; } = 35;

            public static int Cyan { get; } = 36;

            public static int White { get; } = 37;

            public static int Gray { get; } = 90;

            public static int Grey { get; } = 90;

            public static int RedBright { get; } = 91;

            public static int GreenBright { get; } = 92;

            public static int YellowBright { get; } = 93;

            public static int BlueBright { get; } = 94;

            public static int MagentaBright { get; } = 95;

            public static int CyanBright { get; } = 96;

            public static int WhiteBright { get; } = 97;
        }

        public static class Background
        {
            public static int Black { get; } = 40;

            public static int Red { get; } = 41;

            public static int Green { get; } = 42;

            public static int Yellow { get; } = 43;

            public static int Blue { get; } = 44;

            public static int Magenta { get; } = 45;

            public static int Cyan { get; } = 46;

            public static int White { get; } = 47;

            public static int Gray { get; } = 100;

            public static int Grey { get; } = 100;

            public static int RedBright { get; } = 101;

            public static int GreenBright { get; } = 102;

            public static int YellowBright { get; } = 103;

            public static int BlueBright { get; } = 104;

            public static int MagentaBright { get; } = 105;

            public static int CyanBright { get; } = 106;

            public static int WhiteBright { get; } = 107;
        }

        // TODO add Grey for Gray (Queen's English)
    }

    public struct ConsoleStyle
    {
        public ConsoleStyle(int start, int close)
        {
            Start = start;
            Close = close;
        }

        public int Start { get; }

        public int Close { get; }
    }

    public class AnsiSimpleConsoleWriter
    {
        public AnsiSimpleConsoleWriter()
        {

        }
    }

    public class AnsiEnhancedConsoleWriter
    {
        public AnsiEnhancedConsoleWriter()
        {

        }
    }

    public class AnsiFullConsoleWriter
    {
        public AnsiFullConsoleWriter()
        {

        }
    }
}
