using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public static class Fabulous
    {
        public static FabulousText Foreground(IRgb foreColor)
        {
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, false, null);
        }

        public static FabulousText Background(IRgb backColor)
        {
            return new FabulousText(DefaultForeground, backColor, TextDecoration.None, false, null);
        }

        public static FabulousText Text(string text)
        {
            return new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.None, false, text);
        }

        // FG styling
        public static FabulousText Rgb(byte red, byte green, byte blue)
        {
            var foreColor = new Rgb(red, green, blue);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, false, null);
        }

        public static FabulousText Rgb((byte red, byte green, byte blue) values)
        {
            var foreColor = new Rgb(values);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, false, null);
        }

        public static FabulousText Hex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var foreColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, false, null);
        }

        public static FabulousText Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(foreColor, DefaultBackground, TextDecoration.None, false, null);
        }

        public static FabulousText Black => new FabulousText(ConsoleColors.Black, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText Red => new FabulousText(ConsoleColors.DarkRed, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText Green => new FabulousText(ConsoleColors.DarkGreen, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText Yellow => new FabulousText(ConsoleColors.DarkYellow, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText Blue => new FabulousText(ConsoleColors.DarkBlue, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText Magenta => new FabulousText(ConsoleColors.DarkMagenta, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText Cyan => new FabulousText(ConsoleColors.DarkCyan, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText White => new FabulousText(ConsoleColors.White, DefaultBackground, TextDecoration.None, false, null);

        // bright black
        public static FabulousText Gray => new FabulousText(ConsoleColors.Grey, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText Grey => new FabulousText(ConsoleColors.Grey, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText RedBright => new FabulousText(ConsoleColors.Red, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText GreenBright => new FabulousText(ConsoleColors.Green, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText YellowBright => new FabulousText(ConsoleColors.Yellow, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText BlueBright => new FabulousText(ConsoleColors.Blue, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText MagentaBright => new FabulousText(ConsoleColors.Magenta, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText CyanBright => new FabulousText(ConsoleColors.Cyan, DefaultBackground, TextDecoration.None, false, null);

        public static FabulousText WhiteBright => new FabulousText(ConsoleColors.WhiteBright, DefaultBackground, TextDecoration.None, false, null);

        // BG styling
        public static FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new Rgb(red, green, blue);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, false, null);
        }

        public static FabulousText BgRgb((byte red, byte green, byte blue) values)
        {
            var bgColor = new Rgb(values);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, false, null);
        }

        public static FabulousText BgHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            var bgColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, false, null);
        }

        public static FabulousText BgKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(DefaultForeground, bgColor, TextDecoration.None, false, null);
        }

        public static FabulousText BgBlack => new FabulousText(DefaultForeground, ConsoleColors.Black, TextDecoration.None, false, null);

        public static FabulousText BgRed => new FabulousText(DefaultForeground, ConsoleColors.DarkRed, TextDecoration.None, false, null);

        public static FabulousText BgGreen => new FabulousText(DefaultForeground, ConsoleColors.DarkGreen, TextDecoration.None, false, null);

        public static FabulousText BgYellow => new FabulousText(DefaultForeground, ConsoleColors.DarkYellow, TextDecoration.None, false, null);

        public static FabulousText BgBlue => new FabulousText(DefaultForeground, ConsoleColors.DarkBlue, TextDecoration.None, false, null);

        public static FabulousText BgMagenta => new FabulousText(DefaultForeground, ConsoleColors.DarkMagenta, TextDecoration.None, false, null);

        public static FabulousText BgCyan => new FabulousText(DefaultForeground, ConsoleColors.DarkCyan, TextDecoration.None, false, null);

        public static FabulousText BgWhite => new FabulousText(DefaultForeground, ConsoleColors.White, TextDecoration.None, false, null);

        // bright black
        public static FabulousText BgGray => new FabulousText(DefaultForeground, ConsoleColors.Grey, TextDecoration.None, false, null);

        public static FabulousText BgGrey => new FabulousText(DefaultForeground, ConsoleColors.Grey, TextDecoration.None, false, null);

        public static FabulousText BgRedBright => new FabulousText(DefaultForeground, ConsoleColors.Red, TextDecoration.None, false, null);

        public static FabulousText BgGreenBright => new FabulousText(DefaultForeground, ConsoleColors.Green, TextDecoration.None, false, null);

        public static FabulousText BgYellowBright => new FabulousText(DefaultForeground, ConsoleColors.Yellow, TextDecoration.None, false, null);

        public static FabulousText BgBlueBright => new FabulousText(DefaultForeground, ConsoleColors.Blue, TextDecoration.None, false, null);

        public static FabulousText BgMagentaBright => new FabulousText(DefaultForeground, ConsoleColors.Magenta, TextDecoration.None, false, null);

        public static FabulousText BgCyanBright => new FabulousText(DefaultForeground, ConsoleColors.Cyan, TextDecoration.None, false, null);

        public static FabulousText BgWhiteBright => new FabulousText(DefaultForeground, ConsoleColors.WhiteBright, TextDecoration.None, false, null);

        // decorations
        public static FabulousText Reset => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.None, true, null);

        public static FabulousText Blink => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Blink, false, null);

        public static FabulousText Bold => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Bold, false, null);

        public static FabulousText Dim => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Dim, false, null);

        public static FabulousText Italic => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Italic, false, null);

        public static FabulousText Underline => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Underline, false, null);

        public static FabulousText Hidden => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Hidden, false, null);

        public static FabulousText Strikethrough => new FabulousText(DefaultForeground, DefaultBackground, TextDecoration.Strikethrough, false, null);

        public static void Write(object obj)
        {
            FabulousText fragment = obj?.ToString();
            FabulousTextCollection collection = fragment;
            var writer = GetConsoleWriter(collection);
            writer.Write();
        }

        public static void Write(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;
            var writer = GetConsoleWriter(collection);
            writer.Write();
        }

        public static void Write(string format, params object[] args)
        {
            FabulousText fragment = format;
            FabulousTextCollection collection = fragment;
            var writer = GetConsoleWriter(collection);
            writer.Write(args);
        }

        public static void Write(FabulousText fragment)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            var writer = GetConsoleWriter(fragment);
            writer.Write();
        }

        public static void Write(FabulousText fragment, params object[] args)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            var writer = GetConsoleWriter(fragment);
            writer.Write(args);
        }

        public static void Write(FabulousTextCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var writer = GetConsoleWriter(collection);
            writer.Write();
        }

        public static void Write(FabulousTextCollection collection, params object[] args)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var writer = GetConsoleWriter(collection);
            writer.Write(args);
        }

        public static void WriteLine(object obj)
        {
            FabulousText fragment = obj?.ToString();
            FabulousTextCollection collection = fragment;
            var writer = GetConsoleWriter(collection);
            writer.WriteLine();
        }

        public static void WriteLine(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;
            var writer = GetConsoleWriter(collection);
            writer.WriteLine();
        }

        public static void WriteLine(string format, params object[] args)
        {
            FabulousText fragment = format;
            FabulousTextCollection collection = fragment;
            var writer = GetConsoleWriter(collection);
            writer.WriteLine(args);
        }

        public static void WriteLine(FabulousText fragment)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            var writer = GetConsoleWriter(fragment);
            writer.WriteLine();
        }

        public static void WriteLine(FabulousText fragment, params object[] args)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            var writer = GetConsoleWriter(fragment);
            writer.WriteLine(args);
        }

        public static void WriteLine(FabulousTextCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var writer = GetConsoleWriter(collection);
            writer.WriteLine();
        }

        public static void WriteLine(FabulousTextCollection collection, params object[] args)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var writer = GetConsoleWriter(collection);
            writer.WriteLine(args);
        }

        private static IRgb DefaultForeground { get; } = new Rgb(192, 192, 192);

        private static IRgb DefaultBackground { get; } = new Rgb(0, 0, 0);

        private static IConsoleWriter GetConsoleWriter(FabulousTextCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (WindowsConsole.IsWindows)
                WindowsConsole.EnableVirtualTerminalProcessing();

            var consoleSupport = ConsoleSupport.SupportedColorMode;
            switch (consoleSupport)
            {
                case ConsoleColorMode.Basic:
                    return WindowsConsole.IsWindows && !WindowsConsole.IsVirtualTerminalProcessingEnabled()
                        ? new StandardConsoleWriter(collection) as IConsoleWriter
                        : new AnsiSimpleConsoleWriter(collection) as IConsoleWriter;
                case ConsoleColorMode.Enhanced:
                    return new AnsiEnhancedConsoleWriter(collection);
                case ConsoleColorMode.Full:
                    return new AnsiFullConsoleWriter(collection);
                default:
                    throw new ArgumentOutOfRangeException(nameof(consoleSupport), "Unknown console support level " + consoleSupport.ToString());
            }
        }
    }
}
