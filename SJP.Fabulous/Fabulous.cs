using System;
using System.Collections;
using System.Collections.Generic;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public static class Fabulous
    {
        public static FabulousText Foreground(IRgb foreColor)
        {
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Background(IRgb backColor)
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
            var foreColor = new Rgb(red, green, blue);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Rgb((byte red, byte green, byte blue) values)
        {
            var foreColor = new Rgb(values);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Hex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var foreColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, null);
        }

        public static FabulousText Black => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Red => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Green => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Yellow => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Blue => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Magenta => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Cyan => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText White => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        // bright black
        public static FabulousText Gray => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText Grey => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText RedBright => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText GreenBright => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText YellowBright => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText BlueBright => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText MagentaBright => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText CyanBright => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        public static FabulousText WhiteBright => new FabulousText(new Rgb(0, 0, 0), DefaultBackground, TextDecoration.None, null);

        // BG styling
        public static FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new Rgb(red, green, blue);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgRgb((byte red, byte green, byte blue) values)
        {
            var bgColor = new Rgb(values);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var bgColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, null);
        }

        public static FabulousText BgBlack => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgRed => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGreen => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgYellow => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgBlue => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgMagenta => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgCyan => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgWhite => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        // bright black
        public static FabulousText BgGray => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGrey => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgRedBright => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgGreenBright => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgYellowBright => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgBlueBright => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgMagentaBright => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgCyanBright => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

        public static FabulousText BgWhiteBright => new FabulousText(DefaultForeground, new Rgb(0, 0, 0), TextDecoration.None, null);

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

        private static IRgb DefaultForeground { get; } = new Rgb(192, 192, 192);

        private static IRgb DefaultBackground { get; } = new Rgb(0, 0, 0);
    }

    public class FabulousText
    {
        public FabulousText(IColor foreColor, IColor backColor, TextDecoration decorations, string text)
        {
            ForegroundColor = foreColor;
            BackgroundColor = backColor;
            Decorations = decorations;
            Text = text ?? string.Empty;
        }

        internal IColor ForegroundColor { get; }

        internal IColor BackgroundColor { get; }

        internal TextDecoration Decorations { get; }

        public string Text { get; }

        public void Write() => Fabulous.Write(this);

        public void Write(params object[] args) => Fabulous.Write(this, args);

        public void WriteLine() => Fabulous.WriteLine(this);

        public void WriteLine(params object[] args) => Fabulous.WriteLine(this, args);

        // FG styling
        public FabulousText Rgb(byte red, byte green, byte blue)
        {
            var foreColor = new Rgb(red, green, blue);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text);
        }

        public FabulousText Hex(string hex)
        {
            var foreColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text);
        }

        public FabulousText Keyword(string keyword)
        {
            var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(foreColor, BackgroundColor, Decorations, Text);
        }

        public FabulousText Black => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Red => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Green => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Yellow => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Blue => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Magenta => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Cyan => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText White => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        // bright black
        public FabulousText Gray => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText Grey => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText RedBright => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText GreenBright => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText YellowBright => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText BlueBright => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText MagentaBright => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText CyanBright => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        public FabulousText WhiteBright => new FabulousText(new Rgb(192, 192, 192), BackgroundColor, Decorations, Text);

        // BG styling
        public FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new Rgb(red, green, blue);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text);
        }

        public FabulousText BgHex(string hex)
        {
            var bgColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text);
        }

        public FabulousText BgKeyword(string keyword)
        {
            var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(ForegroundColor, bgColor, Decorations, Text);
        }

        public FabulousText BgBlack => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgRed => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgGreen => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgYellow => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgBlue => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgMagenta => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgCyan => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgWhite => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        // bright black
        public FabulousText BgGray => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgGrey => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgRedBright => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgGreenBright => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgYellowBright => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgBlueBright => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgMagentaBright => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgCyanBright => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

        public FabulousText BgWhiteBright => new FabulousText(ForegroundColor, new Rgb(0, 0, 0), Decorations, Text);

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
            return new FabulousText(new Rgb(192, 192, 192), new Rgb(0, 0, 0), TextDecoration.None, text);
        }

        public static FabulousTextCollection operator +(FabulousText fragmentA, FabulousText fragmentB)
        {
            return new FabulousTextCollection(fragmentA, fragmentB);
        }
    }

    public static class TextFragmentExtensions
    {
        public static FabulousText Foreground(this FabulousText fragment, IColor foreColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(foreColor, fragment.BackgroundColor, fragment.Decorations, fragment.Text);
        }

        public static FabulousText Background(this FabulousText fragment, IColor backColor)
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

    public static class AnsiModifiers
    {
        public static class ConsoleColors
        {
            public static IRgb Black => new Rgb(0, 0, 0);

            public static IRgb DarkBlue => new Rgb(0, 0, 139);

            public static IRgb DarkGreen => new Rgb(0, 100, 0);

            public static IRgb DarkCyan => new Rgb(0, 139, 139);

            public static IRgb DarkRed => new Rgb(139, 0, 0);

            public static IRgb DarkMagenta => new Rgb(139, 0, 139);

            public static IRgb DarkYellow => new Rgb(215, 195, 42);

            public static IRgb DarkGray => new Rgb(128, 128, 128);

            public static IRgb DarkGrey => new Rgb(128, 128, 128);

            public static IRgb Gray => new Rgb(169, 169, 169);

            public static IRgb Grey => new Rgb(169, 169, 169);

            public static IRgb Blue => new Rgb(0, 0, 255);

            public static IRgb Green => new Rgb(0, 128, 0);

            public static IRgb Cyan => new Rgb(0, 255, 255);

            public static IRgb Red => new Rgb(255, 0, 0);

            public static IRgb Magenta => new Rgb(255, 0, 255);

            public static IRgb Yellow => new Rgb(255, 255, 0);

            public static IRgb White => new Rgb(255, 255, 255);
        }

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
