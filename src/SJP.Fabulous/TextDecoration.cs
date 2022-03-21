using System;

namespace SJP.Fabulous;

/// <summary>
/// A collection of styles that can be applied to a console.
/// </summary>
[Flags]
public enum TextDecoration
{
    /// <summary>
    /// No styles set.
    /// </summary>
    None = 0,

    /// <summary>
    /// Blinks the console, not widely supported.
    /// </summary>
    Blink = 1 << 0,

    /// <summary>
    /// Sets the font weight to bold.
    /// </summary>
    Bold = 1 << 1,

    /// <summary>
    /// Dims the text on the console.
    /// </summary>
    Dim = 1 << 2,

    /// <summary>
    /// Sets the text styling to italic, not widely supported.
    /// </summary>
    Italic = 1 << 3,

    /// <summary>
    /// Underlines the text in the console.
    /// </summary>
    Underline = 1 << 4,

    /// <summary>
    /// Hides the text from being visibly printed, not widely supported.
    /// </summary>
    Hidden = 1 << 5,

    /// <summary>
    /// Strikes a line horizontally through the middle of the text.
    /// </summary>
    Strikethrough = 1 << 6
}