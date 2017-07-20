using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class AnsiSimpleConsoleWriter : IConsoleWriter
    {
        public AnsiSimpleConsoleWriter(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        public AnsiSimpleConsoleWriter(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        protected FabulousTextCollection TextCollection { get; }

        public void Write()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindows)
                {
                    if (fgAnsiColor == 34)
                        fgAnsiColor = 94;
                    if (bgAnsiColor == 34)
                        bgAnsiColor = 94;
                }

                bgAnsiColor += 10;

                var fgStart = Escape + "[" + fgAnsiColor.ToString() + "m";
                var bgStart = Escape + "[" + bgAnsiColor.ToString() + "m";

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

        protected static int GetSimpleAnsiColor(IRgb rgb)
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

            return value == 2
                ? ansi += 60
                : ansi;
        }

        protected static double GetValue(IRgb rgb)
        {
            if (rgb == null)
                throw new ArgumentNullException(nameof(rgb));

            var maxColor = Math.Max(Math.Max(rgb.Blue, rgb.Green), rgb.Red);
            return maxColor * 100d;
        }

        private const string Escape = "\x1B";
        private const string Reset = Escape + "[0m";
        private const string ForegroundColorClose = Escape + "[39m";
        private const string BackgroundColorClose = Escape + "[49m";
    }
}
