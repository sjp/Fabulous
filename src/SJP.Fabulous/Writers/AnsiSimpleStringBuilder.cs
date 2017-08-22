using System;
using System.Linq;
using System.Text;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    /// <summary>
    /// An ANSI string builder that will style text using ANSI escapes with the basic ANSI 16 colors.
    /// </summary>
    public class AnsiSimpleStringBuilder : IAnsiStringBuilder
    {
        /// <summary>
        /// Creates an ANSI string builder that is styled with 16 colors for a piece of styled text.
        /// </summary>
        /// <param name="text">A piece of text to be styled.</param>
        public AnsiSimpleStringBuilder(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        /// <summary>
        /// Creates an ANSI string builder that is styled with 16 colors for a collection of styled text.
        /// </summary>
        /// <param name="textCollection">A collection of text to be styled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="textCollection"/> is <c>null</c>.</exception>
        public AnsiSimpleStringBuilder(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        /// <summary>
        /// The text to be styled.
        /// </summary>
        protected FabulousTextCollection TextCollection { get; }

        /// <summary>
        /// Converts the value of an <see cref="AnsiSimpleStringBuilder"/> to a <see cref="string"/>.
        /// </summary>
        /// <returns>A string that can contain ANSI styling if present.</returns>
        public string ToAnsiString()
        {
            var builder = new StringBuilder();

            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgAnsiColor = GetSimpleAnsiColor(text.ForegroundColor.ToRgb());
                var bgAnsiColor = GetSimpleAnsiColor(text.BackgroundColor.ToRgb());

                // bump blue brightness up on windows
                if (WindowsConsole.IsWindowsPlatform)
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

                var styles = text.Decorations.GetAnsiStyles();
                foreach (var style in styles)
                {
                    var ansiStyle = Escape + "[" + style.Start.ToString() + "m";
                    builder.Append(ansiStyle);
                }

                builder.Append(text.Text);
                builder.Append(ForegroundColorClose);
                builder.Append(BackgroundColorClose);

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

        /// <summary>
        /// Translates a color in the RGB colorspace to an ANSI color.
        /// </summary>
        /// <param name="rgb">A color in the RGB colorspace.</param>
        /// <returns>An integer representing an escape code in the ANSI color set.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rgb"/> is <c>null</c>.</exception>
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

            return value >= 50
                ? ansi += 60
                : ansi;
        }

        /// <summary>
        /// Retrieves the value of a color (i.e. its white or black level) from the HSV colorspace.
        /// </summary>
        /// <param name="rgb">A color in the RGB colorspace.</param>
        /// <returns>The value of a color from the HSV colorspace.</returns>
        private static double GetValue(IRgb rgb)
        {
            if (rgb == null)
                throw new ArgumentNullException(nameof(rgb));

            var maxColor = Math.Max(Math.Max(rgb.Blue, rgb.Green), rgb.Red);
            return (maxColor / 255d) * 100d;
        }

        private const string Escape = "\x1B";
        private const string Reset = Escape + "[0m";
        private const string ForegroundColorClose = Escape + "[39m";
        private const string BackgroundColorClose = Escape + "[49m";
    }
}
