﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class AnsiEnhancedStringBuilder : IAnsiStringBuilder
    {
        public AnsiEnhancedStringBuilder(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        public AnsiEnhancedStringBuilder(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        protected FabulousTextCollection TextCollection { get; }

        public string ToAnsiString()
        {
            var builder = new StringBuilder();

            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

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
                var fgAnsiColor = GetAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetAnsiColor(text.BackgroundColor.ToRgb());

                var fgStart = ForegroundColorOpen + fgAnsiColor.ToString() + "m";
                var bgStart = BackgroundColorOpen + bgAnsiColor.ToString() + "m";

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

            return builder.ToString();
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
