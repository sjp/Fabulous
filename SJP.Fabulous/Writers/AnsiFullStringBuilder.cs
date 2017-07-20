using System;
using System.Linq;
using System.Text;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class AnsiFullStringBuilder : IAnsiStringBuilder
    {
        public AnsiFullStringBuilder(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        public AnsiFullStringBuilder(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        protected FabulousTextCollection TextCollection { get; }

        public string ToAnsiString()
        {
            var builder = new StringBuilder();

            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
                var fgAnsiColor = GetColorDefinition(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetColorDefinition(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor + "m";

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
