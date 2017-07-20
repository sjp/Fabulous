using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class AnsiEnhancedConsoleWriter : IConsoleWriter
    {
        public AnsiEnhancedConsoleWriter(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        public AnsiEnhancedConsoleWriter(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        protected FabulousTextCollection TextCollection { get; }

        public void Write()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
                Console.Write(builder.ToString());
            }
        }

        public void Write(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
                Console.Write(builder.ToString(), args);
            }
        }

        public void WriteLine()
        {
            Write();
            Console.WriteLine();
        }

        public void WriteLine(params object[] args)
        {
            Write(args);
            Console.WriteLine();
        }

        public void WriteError()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
                Console.Error.Write(builder.ToString());
            }
        }

        public void WriteError(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
                Console.Error.Write(builder.ToString(), args);
            }
        }

        public void WriteErrorLine()
        {
            WriteError();
            Console.Error.WriteLine();
        }

        public void WriteErrorLine(params object[] args)
        {
            WriteError(args);
            Console.Error.WriteLine();
        }

        public async Task WriteAsync()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
                await Console.Out.WriteAsync(builder.ToString());
            }
        }

        public async Task WriteAsync(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);

                await Console.Out.WriteAsync(string.Format(builder.ToString(), args));
            }
        }

        public async Task WriteLineAsync()
        {
            await WriteAsync();
            await Console.Out.WriteLineAsync();
        }

        public async Task WriteLineAsync(params object[] args)
        {
            await WriteAsync(args);
            await Console.Out.WriteLineAsync();
        }

        public async Task WriteErrorAsync()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
                await Console.Error.WriteAsync(builder.ToString());
            }
        }

        public async Task WriteErrorAsync(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

                var builder = new StringBuilder(text.Text.Length);
                if (text.ConsoleReset)
                    builder.Append(Reset);

                builder.Append(fgStart);
                builder.Append(bgStart);

                var styles = AnsiStyles.GetAnsiStyles(text.Decorations);
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
                await Console.Error.WriteAsync(string.Format(builder.ToString(), args));
            }
        }

        public async Task WriteErrorLineAsync()
        {
            await WriteErrorAsync();
            await Console.Error.WriteLineAsync();
        }

        public async Task WriteErrorLineAsync(params object[] args)
        {
            await WriteErrorAsync(args);
            await Console.Error.WriteLineAsync();
        }

        protected static int GetAnsiColor(IRgb rgb)
        {
            if (rgb == null)
                throw new ArgumentNullException(nameof(rgb));

            // we use the extended greyscale palette here, with the exception of
            // black and white. normal palette only has 4 greyscale shades.
            if (rgb.Red == rgb.Green && rgb.Green == rgb.Blue)
            {
                if (rgb.Red < 8)
                    return 16;

                if (rgb.Red > 248)
                    return 231;

                var dResult = ((rgb.Red - 8) / 247d) * 24;
                return Convert.ToInt32(Math.Round(dResult, MidpointRounding.AwayFromZero) + 232);
            }

            var dRed = rgb.Red / 255d * 5;
            var dGreen = rgb.Green / 255d * 5;
            var dBlue = rgb.Blue / 255d * 5;

            var iRed = Convert.ToInt32(Math.Round(dRed, MidpointRounding.AwayFromZero));
            var iGreen = Convert.ToInt32(Math.Round(dGreen, MidpointRounding.AwayFromZero));
            var iBlue = Convert.ToInt32(Math.Round(dBlue, MidpointRounding.AwayFromZero));

            return 16
                + (36 * iRed)
                + (6 * iGreen)
                + iBlue;
        }

        private const string Escape = "\x1B";
        private const string Reset = Escape + "[0m";
        private const string ForegroundColorOpen = Escape + "[38;5;";
        private const string BackgroundColorOpen = Escape + "[48;5;";
        private const string ForegroundColorClose = Escape + "[39m";
        private const string BackgroundColorClose = Escape + "[49m";
    }
}
