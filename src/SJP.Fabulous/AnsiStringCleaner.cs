﻿using System;
using System.Text.RegularExpressions;

namespace SJP.Fabulous;

/// <summary>
/// An ANSI string cleaner that removes any ANSI escapes from a string.
/// </summary>
public class AnsiStringCleaner : IAnsiStringCleaner
{
    private static readonly Regex _ansiSequence = new Regex("\u001B\\[[0-9;:]+m", RegexOptions.Compiled, TimeSpan.FromMilliseconds(100));

    /// <summary>
    /// Creates an ANSI string cleaner that removes ANSI escapes.
    /// </summary>
    /// <param name="ansiText">A piece of text that may contain ANSI escapes.</param>
    public AnsiStringCleaner(string ansiText)
    {
        AnsiText = ansiText ?? string.Empty;
    }

    /// <summary>
    /// Text containing ANSI escapes.
    /// </summary>
    protected string AnsiText { get; }

    /// <summary>
    /// Returns a string that has ANSI escape sequences removed.
    /// </summary>
    /// <returns>A string without ANSI escape sequences.</returns>
    public string ToAnsiCleanedString()
    {
        return _ansiSequence.Replace(AnsiText, string.Empty);
    }
}