using System;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    /// <summary>
    /// Extension methods for working with styled text.
    /// </summary>
    public static class FabulousTextExtensions
    {
        /// <summary>
        /// Creates a new styled text object that is the same as the current object, but with the foreground color set to the given color instead.
        /// </summary>
        /// <param name="fragment">The text object to be used as a reference.</param>
        /// <param name="foreColor">The new color to use as a foreground color.</param>
        /// <returns>A new text object that is the same as the current object, but with the new foreground color.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="fragment"/> or <paramref name="foreColor"/> is <c>null</c>.</exception>
        public static FabulousText Foreground(this FabulousText fragment, IColor foreColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));
            if (foreColor == null)
                throw new ArgumentNullException(nameof(foreColor));

            return new FabulousText(foreColor, fragment.BackgroundColor, fragment.Decorations, fragment.Text, fragment.ConsoleReset);
        }

        /// <summary>
        /// Creates a new styled text object that is the same as the current object, but with the background color set to the given color instead.
        /// </summary>
        /// <param name="fragment">The text object to be used as a reference.</param>
        /// <param name="backColor">The new color to use as a background color.</param>
        /// <returns>A new text object that is the same as the current object, but with the new background color.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="fragment"/> or <paramref name="backColor"/> is <c>null</c>.</exception>
        public static FabulousText Background(this FabulousText fragment, IColor backColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));
            if (backColor == null)
                throw new ArgumentNullException(nameof(backColor));

            return new FabulousText(fragment.ForegroundColor, backColor, fragment.Decorations, fragment.Text, fragment.ConsoleReset);
        }

        /// <summary>
        /// Creates a new styled text object that is the same as the current object, but with the text set to the given text instead.
        /// </summary>
        /// <param name="fragment">The text object to be used as a reference.</param>
        /// <param name="text">The text to be used for printing.</param>
        /// <returns>A new text object that is the same as the current object, but with the new text instead.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="fragment"/> is <c>null</c>.</exception>
        public static FabulousText Text(this FabulousText fragment, string text)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(fragment.ForegroundColor, fragment.BackgroundColor, fragment.Decorations, text, fragment.ConsoleReset);
        }
    }
}
