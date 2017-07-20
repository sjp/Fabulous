using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public class StandardConsoleWriter : IConsoleWriter
    {
        public StandardConsoleWriter(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        public StandardConsoleWriter(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        protected FabulousTextCollection TextCollection { get; }

        public void Write()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                Console.Write(text.Text);

                ResetConsoleColors();
            }
        }

        public void Write(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                Console.Write(text.Text, args);

                ResetConsoleColors();
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
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                Console.Error.Write(text.Text);

                ResetConsoleColors();
            }
        }

        public void WriteError(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                Console.Error.Write(text.Text, args);

                ResetConsoleColors();
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
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                await Console.Out.WriteAsync(text.Text);

                ResetConsoleColors();
            }
        }

        public async Task WriteAsync(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                await Console.Out.WriteAsync(string.Format(text.Text, args));

                ResetConsoleColors();
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
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                await Console.Error.WriteAsync(text.Text);

                ResetConsoleColors();
            }
        }

        public async Task WriteErrorAsync(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                var fgColor = GetConsoleColor(text.ForegroundColor.ToRgb());
                var bgColor = GetConsoleColor(text.BackgroundColor.ToRgb());

                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                await Console.Error.WriteAsync(string.Format(text.Text, args));

                ResetConsoleColors();
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

        protected static ConsoleColor GetConsoleColor(IRgb rgb)
        {
            var ansiColor = GetSimpleAnsiColor(rgb);
            return _ansiToConsoleColor[ansiColor];
        }

        protected static void ResetConsoleColors()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static int GetSimpleAnsiColor(IRgb rgb)
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

        private static double GetValue(IRgb rgb)
        {
            if (rgb == null)
                throw new ArgumentNullException(nameof(rgb));

            var maxColor = Math.Max(Math.Max(rgb.Blue, rgb.Green), rgb.Red);
            return maxColor * 100d;
        }

        private readonly static IReadOnlyDictionary<int, ConsoleColor> _ansiToConsoleColor = new Dictionary<int, ConsoleColor>
        {
            [30] = ConsoleColor.Black,
            [31] = ConsoleColor.DarkRed,
            [32] = ConsoleColor.DarkGreen,
            [33] = ConsoleColor.DarkYellow,
            [34] = ConsoleColor.DarkBlue,
            [35] = ConsoleColor.DarkMagenta,
            [36] = ConsoleColor.DarkCyan,
            [37] = ConsoleColor.DarkGray,
            [90] = ConsoleColor.Gray,
            [91] = ConsoleColor.Red,
            [92] = ConsoleColor.Green,
            [93] = ConsoleColor.Yellow,
            [94] = ConsoleColor.Blue,
            [95] = ConsoleColor.Magenta,
            [96] = ConsoleColor.Cyan,
            [97] = ConsoleColor.White
        };
    }
}
