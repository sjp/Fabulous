using System;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class FabulousText : IConsoleWriter
    {
        public FabulousText(IColor foreColor, IColor backColor, TextDecoration decorations, bool reset, string text)
        {
            ForegroundColor = foreColor ?? throw new ArgumentNullException(nameof(foreColor));
            BackgroundColor = backColor ?? throw new ArgumentNullException(nameof(backColor));
            Decorations = decorations;
            ConsoleReset = reset;
            Text = text ?? string.Empty;
        }

        internal IColor ForegroundColor { get; }

        internal IColor BackgroundColor { get; }

        internal TextDecoration Decorations { get; }

        internal bool ConsoleReset { get; }

        public string Text { get; }

        // FG styling
        public FabulousText Rgb(byte red, byte green, byte blue)
        {
            var foreColor = new Rgb(red, green, blue);
            return new FabulousText(foreColor, BackgroundColor, Decorations, ConsoleReset, Text);
        }

        public FabulousText Hex(string hex)
        {
            var foreColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(foreColor, BackgroundColor, Decorations, ConsoleReset, Text);
        }

        public FabulousText Keyword(string keyword)
        {
            var foreColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(foreColor, BackgroundColor, Decorations, ConsoleReset, Text);
        }

        public FabulousText Black => new FabulousText(ConsoleColors.Black, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText Red => new FabulousText(ConsoleColors.DarkRed, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText Green => new FabulousText(ConsoleColors.DarkGreen, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText Yellow => new FabulousText(ConsoleColors.DarkYellow, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText Blue => new FabulousText(ConsoleColors.DarkBlue, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText Magenta => new FabulousText(ConsoleColors.DarkMagenta, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText Cyan => new FabulousText(ConsoleColors.DarkCyan, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText White => new FabulousText(ConsoleColors.White, BackgroundColor, Decorations, ConsoleReset, Text);

        // bright black
        public FabulousText Gray => new FabulousText(ConsoleColors.DarkGrey, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText Grey => new FabulousText(ConsoleColors.DarkGrey, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText RedBright => new FabulousText(ConsoleColors.Red, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText GreenBright => new FabulousText(ConsoleColors.Green, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText YellowBright => new FabulousText(ConsoleColors.Yellow, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText BlueBright => new FabulousText(ConsoleColors.Blue, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText MagentaBright => new FabulousText(ConsoleColors.Magenta, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText CyanBright => new FabulousText(ConsoleColors.Cyan, BackgroundColor, Decorations, ConsoleReset, Text);

        public FabulousText WhiteBright => new FabulousText(ConsoleColors.WhiteBright, BackgroundColor, Decorations, ConsoleReset, Text);

        // BG styling
        public FabulousText BgRgb(byte red, byte green, byte blue)
        {
            var bgColor = new Rgb(red, green, blue);
            return new FabulousText(ForegroundColor, bgColor, Decorations, ConsoleReset, Text);
        }

        public FabulousText BgHex(string hex)
        {
            var bgColor = Colorspaces.Rgb.FromHex(hex);
            return new FabulousText(ForegroundColor, bgColor, Decorations, ConsoleReset, Text);
        }

        public FabulousText BgKeyword(string keyword)
        {
            var bgColor = Colorspaces.Rgb.FromKeyword(keyword);
            return new FabulousText(ForegroundColor, bgColor, Decorations, ConsoleReset, Text);
        }

        public FabulousText BgBlack => new FabulousText(ForegroundColor, ConsoleColors.Black, Decorations, ConsoleReset, Text);

        public FabulousText BgRed => new FabulousText(ForegroundColor, ConsoleColors.DarkRed, Decorations, ConsoleReset, Text);

        public FabulousText BgGreen => new FabulousText(ForegroundColor, ConsoleColors.DarkGreen, Decorations, ConsoleReset, Text);

        public FabulousText BgYellow => new FabulousText(ForegroundColor, ConsoleColors.DarkYellow, Decorations, ConsoleReset, Text);

        public FabulousText BgBlue => new FabulousText(ForegroundColor, ConsoleColors.DarkBlue, Decorations, ConsoleReset, Text);

        public FabulousText BgMagenta => new FabulousText(ForegroundColor, ConsoleColors.DarkMagenta, Decorations, ConsoleReset, Text);

        public FabulousText BgCyan => new FabulousText(ForegroundColor, ConsoleColors.DarkCyan, Decorations, ConsoleReset, Text);

        public FabulousText BgWhite => new FabulousText(ForegroundColor, ConsoleColors.White, Decorations, ConsoleReset, Text);

        // bright black
        public FabulousText BgGray => new FabulousText(ForegroundColor, ConsoleColors.Grey, Decorations, ConsoleReset, Text);

        public FabulousText BgGrey => new FabulousText(ForegroundColor, ConsoleColors.Grey, Decorations, ConsoleReset, Text);

        public FabulousText BgRedBright => new FabulousText(ForegroundColor, ConsoleColors.Red, Decorations, ConsoleReset, Text);

        public FabulousText BgGreenBright => new FabulousText(ForegroundColor, ConsoleColors.Green, Decorations, ConsoleReset, Text);

        public FabulousText BgYellowBright => new FabulousText(ForegroundColor, ConsoleColors.Yellow, Decorations, ConsoleReset, Text);

        public FabulousText BgBlueBright => new FabulousText(ForegroundColor, ConsoleColors.Blue, Decorations, ConsoleReset, Text);

        public FabulousText BgMagentaBright => new FabulousText(ForegroundColor, ConsoleColors.Magenta, Decorations, ConsoleReset, Text);

        public FabulousText BgCyanBright => new FabulousText(ForegroundColor, ConsoleColors.Cyan, Decorations, ConsoleReset, Text);

        public FabulousText BgWhiteBright => new FabulousText(ForegroundColor, ConsoleColors.WhiteBright, Decorations, ConsoleReset, Text);

        // decorations
        public FabulousText Reset => new FabulousText(ForegroundColor, BackgroundColor, Decorations, true, Text);

        public FabulousText Blink => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Blink, ConsoleReset, Text);

        public FabulousText Bold => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Bold, ConsoleReset, Text);

        public FabulousText Dim => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Dim, ConsoleReset, Text);

        public FabulousText Italic => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Italic, ConsoleReset, Text);

        public FabulousText Underline => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Underline, ConsoleReset, Text);

        public FabulousText Hidden => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Hidden, ConsoleReset, Text);

        public FabulousText Strikethrough => new FabulousText(ForegroundColor, BackgroundColor, Decorations | TextDecoration.Strikethrough, ConsoleReset, Text);

        public static implicit operator FabulousText(string text)
        {
            return new FabulousText(new Rgb(192, 192, 192), new Rgb(0, 0, 0), TextDecoration.None, false, text);
        }

        public static FabulousTextCollection operator +(FabulousText fragmentA, FabulousText fragmentB)
        {
            return new FabulousTextCollection(fragmentA, fragmentB);
        }


        #region IConsoleWriter

        public void Write() => Fabulous.Write(this);

        public void Write(params object[] args) => Fabulous.Write(this, args);

        public void WriteLine() => Fabulous.WriteLine(this);

        public void WriteLine(params object[] args) => Fabulous.WriteLine(this, args);

        public void WriteError() => Fabulous.WriteError(this);

        public void WriteError(params object[] args) => Fabulous.WriteError(this, args);

        public void WriteErrorLine() => Fabulous.WriteErrorLine(this);

        public void WriteErrorLine(params object[] args) => Fabulous.WriteErrorLine(this, args);

        public Task WriteAsync() => Fabulous.WriteAsync(this);

        public Task WriteAsync(params object[] args) => Fabulous.WriteAsync(this, args);

        public Task WriteLineAsync() => Fabulous.WriteLineAsync(this);

        public Task WriteLineAsync(params object[] args) => Fabulous.WriteLineAsync(this, args);

        public Task WriteErrorAsync() => Fabulous.WriteErrorAsync(this);

        public Task WriteErrorAsync(params object[] args) => Fabulous.WriteErrorAsync(this, args);

        public Task WriteErrorLineAsync() => Fabulous.WriteErrorLineAsync(this);

        public Task WriteErrorLineAsync(params object[] args) => Fabulous.WriteErrorLineAsync(this, args);

        #endregion IConsoleWriter
    }
}
