using System;
using System.Linq;
using System.Text;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class AnsiSimpleStringBuilder : IAnsiStringBuilder
    {
        public AnsiSimpleStringBuilder(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        public AnsiSimpleStringBuilder(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        protected FabulousTextCollection TextCollection { get; }

        public string ToAnsiString()
        {
            var builder = new StringBuilder();

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
            }

            return builder.ToString();
        }

        public string ToAnsiString(params object[] args)
        {
            var builder = new StringBuilder();

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

                builder.AppendFormat(text.Text, args);
                builder.Append(BackgroundColorClose);
                builder.Append(ForegroundColorClose);

                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Close.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                if (text.ConsoleReset)
                    builder.Append(Reset);
            }

            return builder.ToString();
        }

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
