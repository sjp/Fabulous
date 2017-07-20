using System;

namespace SJP.Fabulous
{
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
}
