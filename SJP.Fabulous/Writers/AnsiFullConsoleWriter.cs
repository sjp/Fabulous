using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class AnsiFullConsoleWriter : IConsoleWriter
    {
        public AnsiFullConsoleWriter(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        public AnsiFullConsoleWriter(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        protected FabulousTextCollection TextCollection { get; }

        public void Write()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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

        protected static string GetColorDefinition(IRgb rgb)
        {
            if (rgb == null)
                throw new ArgumentNullException(nameof(rgb));

            return rgb.Red.ToString() + ";"
                + rgb.Green.ToString() + ";"
                + rgb.Blue.ToString();
        }

        private const string Escape = "\x1B";
        private const string Reset = Escape + "[0m";
        private const string ForegroundColorOpen = Escape + "[38;2;";
        private const string BackgroundColorOpen = Escape + "[48;2;";
        private const string ForegroundColorClose = Escape + "[39m";
        private const string BackgroundColorClose = Escape + "[49m";
    }
}
