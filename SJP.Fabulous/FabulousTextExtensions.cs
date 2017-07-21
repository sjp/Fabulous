using System;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous
{
    public static class FabulousTextExtensions
    {
        public static FabulousText Foreground(this FabulousText fragment, IColor foreColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));
            if (foreColor == null)
                throw new ArgumentNullException(nameof(foreColor));

            return new FabulousText(foreColor, fragment.BackgroundColor, fragment.Decorations, fragment.ConsoleReset, fragment.Text);
        }

        public static FabulousText Background(this FabulousText fragment, IColor backColor)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));
            if (backColor == null)
                throw new ArgumentNullException(nameof(backColor));

            return new FabulousText(fragment.ForegroundColor, backColor, fragment.Decorations, fragment.ConsoleReset, fragment.Text);
        }

        public static FabulousText Text(this FabulousText fragment, string text)
        {
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            return new FabulousText(fragment.ForegroundColor, fragment.BackgroundColor, fragment.Decorations, fragment.ConsoleReset, text);
        }
    }
}
