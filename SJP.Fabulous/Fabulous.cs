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
            return new FabulousText(foreColor, new RgbColor(0, 0, 0), TextDecoration.None, null);
        }

        public static FabulousText Background(RgbColor backColor)
        {
            return new FabulousText(new RgbColor(192, 192, 192), backColor, TextDecoration.None, null);
        }

        public static FabulousText Text(string text)
        {
            return new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.None, text);
        }


        // FG styling
        public static FabulousText Rgb(byte red, byte green, byte blue)
        {
            var foreColor = new RgbColor(red, green, blue);
            return new FabulousText(foreColor, new RgbColor(0, 0, 0), TextDecoration.None, null);
        }

        public static FabulousText Hex(string hex)
        {
            var foreColor = RgbColor.FromHex(hex);
            return new FabulousText(foreColor, new RgbColor(0, 0, 0), TextDecoration.None, null);
        }

        public static FabulousText Keyword(string keyword)
        {
            var foreColor = RgbColor.FromHex(keyword); // TODO: should be a keyword ctor instead
            return new FabulousText(foreColor, new RgbColor(0, 0, 0), TextDecoration.None, null);
        }

        /*
         *         Black,
        Red,
        Green,
        Yellow,
        Blue, //*(On Windows the bright version is used since normal blue is illegible)*
        Magenta,
        Cyan,
        White,
        Gray, // ("bright black")
        RedBright,
        GreenBright,
        YellowBright,
        BlueBright,
        MagentaBright,
        CyanBright,
        WhiteBright*/

        public static FabulousText Black => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText Red => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText Green => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText Yellow => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText Blue => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText Magenta => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText Cyan => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText White => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        // bright black
        public static FabulousText Gray => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText RedBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText GreenBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText YellowBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BlueBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText MagentaBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText CyanBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText WhiteBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        // BG styling
        public static FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new RgbColor(red, green, blue);
            return new FabulousText(new RgbColor(192, 192, 192), bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgHex(string hex)
        {
            var bgColor = RgbColor.FromHex(hex);
            return new FabulousText(new RgbColor(192, 192, 192), bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgKeyword(string keyword)
        {
            var bgColor = RgbColor.FromHex(keyword); // TODO: should be a keyword ctor instead
            return new FabulousText(new RgbColor(192, 192, 192), bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgBlack => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgRed => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGreen => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgYellow => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgBlue => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgMagenta => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgCyan => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgWhite => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        // bright black
        public static FabulousText BgGray => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgRedBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGreenBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgYellowBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgBlueBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgMagentaBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgCyanBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgWhiteBright => new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 0, 0), TextDecoration.None, null);

        // decorations
        public static FabulousText Blink => new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.Blink, null);

        public static FabulousText Bold => new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.Bold, null);

        public static FabulousText Dim => new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.Dim, null);

        public static FabulousText Italic => new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.Italic, null);

        public static FabulousText Underline => new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.Underline, null);

        public static FabulousText Hidden => new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.Hidden, null);

        public static FabulousText Strikethrough => new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.Strikethrough, null);

        public static void Write(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;

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

        public static void Write(FabulousText fragment)
        {

        }

        public static void Write(FabulousTextCollection fragment)
        {

        }

        public static void WriteLine(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;

            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

                Console.WriteLine(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }

        public static void WriteLine(FabulousText fragment)
        {
            FabulousTextCollection collection = fragment;

            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Green;

                Console.WriteLine(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
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

                Console.WriteLine(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }
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
            var foreColor = RgbColor.FromHex(keyword); // TODO: should be a keyword ctor instead
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
            var bgColor = RgbColor.FromHex(keyword); // TODO: should be a keyword ctor instead
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

        public static void Write(this FabulousText fragment)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            Fabulous.Write(fragment);
        }

        public static void WriteLine(this FabulousText fragment)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            Fabulous.WriteLine(fragment);
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
                throw new ArgumentException("hex string is not the right length, must either be 3 or 6 hexadecimal characters.");

            var inputLength = hex.Length;

            byte r;
            var rStr = string.Empty;

            byte g;
            var gStr = string.Empty;

            byte b;
            string bStr = string.Empty;

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
            isValidHex &= byte.TryParse(rStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out r);
            isValidHex &= byte.TryParse(gStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out g);
            isValidHex &= byte.TryParse(bStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out b);

            if (!isValidHex)
                throw new ArgumentException("hex string contains invalid hex characters", nameof(hex));

            return new RgbColor(r, g, b);
        }

        private static ISet<char> _hexChars = new HashSet<char>(new[] { 'A', 'B', 'C', 'D', 'E', 'F' });
    }
}
