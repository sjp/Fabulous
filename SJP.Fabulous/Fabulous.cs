using System;
using System.Collections;
using System.Collections.Generic;

namespace SJP.Fabulous
{

    public static class Fabulous
    {
        public static FabulousText Foreground(RgbColor foreColor)
        {
            return new FabulousText(foreColor, new RgbColor(0, 0, 0), TextDecoration.None, null);
        }

        public static FabulousText Background(RgbColor backColor)
        {
            return new FabulousText(new RgbColor(192, 192, 192), backColor, TextDecoration.None, null);
        }

        public static FabulousText Text(string text)
        {
            return new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.None, text);
        }

        public static void Write(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;

            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

                Console.Write(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }

        public static void Write(FabulousText fragment)
        {

        }

        public static void Write(FabulousTextCollection fragment)
        {

        }

        public static void WriteLine(string text)
        {
            FabulousText fragment = text;
            FabulousTextCollection collection = fragment;

            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

                Console.WriteLine(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }

        public static void WriteLine(FabulousText fragment)
        {
            FabulousTextCollection collection = fragment;

            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Green;

                Console.WriteLine(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }

        public static void WriteLine(FabulousTextCollection collection)
        {
            foreach (var f in collection.Fragments)
            {
                // write style;
                var originalForeColor = Console.ForegroundColor;
                var originalBackColor = Console.BackgroundColor;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;

                Console.WriteLine(f.Text);

                Console.ForegroundColor = originalForeColor;
                Console.BackgroundColor = originalBackColor;
            }
        }
    }

    public class FabulousText
    {
        public FabulousText(RgbColor foreColor, RgbColor backColor, TextDecoration decorations, string text)
        {
            ForegroundColor = foreColor;
            BackgroundColor = backColor;
            Decorations = decorations;
            Text = text ?? string.Empty;
        }

        internal RgbColor ForegroundColor { get; }

        internal RgbColor BackgroundColor { get; }

        internal TextDecoration Decorations { get; }

        internal string Text { get; }

        public static implicit operator FabulousText(string text)
        {
            return new FabulousText(new RgbColor(192, 192, 192), new RgbColor(0, 0, 0), TextDecoration.None, text);
        }

        public static FabulousTextCollection operator +(FabulousText fragmentA, FabulousText fragmentB)
        {
            return new FabulousTextCollection(fragmentA, fragmentB);
        }
    }

    public static class TextFragmentExtensions
    {
        public static FabulousText Foreground(this FabulousText fragment, RgbColor foreColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(foreColor, fragment.BackgroundColor, fragment.Decorations, fragment.Text);
        }

        public static FabulousText Background(this FabulousText fragment, RgbColor backColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(fragment.ForegroundColor, backColor, fragment.Decorations, fragment.Text);
        }

        public static FabulousText Text(this FabulousText fragment, string text)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(fragment.ForegroundColor, fragment.BackgroundColor, fragment.Decorations, text);
        }

        public static void Write(this FabulousText fragment)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));
        }

        public static void WriteLine(this FabulousText fragment)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));
        }
    }

    public class FabulousTextCollection : IEnumerable<FabulousText>
    {
        public FabulousTextCollection(params FabulousText[] fragments)
            : this(fragments as IEnumerable<FabulousText>)
        {
        }

        public FabulousTextCollection(IEnumerable<FabulousText> fragments)
        {
            Fragments = fragments ?? throw new ArgumentNullException(nameof(fragments));
        }

        public IEnumerable<FabulousText> Fragments { get; }

        public static implicit operator FabulousTextCollection(string text)
        {
            FabulousText fragment = text;
            return new FabulousTextCollection(fragment);
        }

        public static implicit operator FabulousTextCollection(FabulousText fragment)
        {
            return new FabulousTextCollection(fragment);
        }

        public static FabulousTextCollection operator +(FabulousTextCollection collection, FabulousText fragment)
        {
            var fragments = new List<FabulousText>(collection.Fragments) { fragment };
            return new FabulousTextCollection(fragments);
        }

        public IEnumerator<FabulousText> GetEnumerator() => Fragments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Fragments.GetEnumerator();
    }

    [Flags]
    public enum TextDecoration
    {
        None            = 0,
        Blink           = 1 << 0,
        Bold            = 1 << 1,
        Dim             = 1 << 2,
        Italic          = 1 << 3,
        Underline       = 1 << 4,
        Hidden          = 1 << 5,
        Strikethrough   = 1 << 6
    }

    // dummy for now until we get a proper color solution,
    // i.e. one that can span something like the HCL colorspace for color matching
    public struct RgbColor
    {
        public RgbColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }
    }
}