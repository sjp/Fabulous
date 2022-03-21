using System;
using System.Linq;
using System.Text;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous;

/// <summary>
/// An ANSI string builder that will style text using ANSI escapes with 24-bit color.
/// </summary>
public class AnsiFullStringBuilder : IAnsiStringBuilder
{
    /// <summary>
    /// Creates an ANSI string builder that is styled with 24-bit color for a piece of styled text.
    /// </summary>
    /// <param name="text">A piece of text to be styled.</param>
    public AnsiFullStringBuilder(FabulousText text)
        : this(new FabulousTextCollection(text))
    {
    }

    /// <summary>
    /// Creates an ANSI string builder that is styled with 24-bit color for a collection of styled text.
    /// </summary>
    /// <param name="textCollection">A collection of text to be styled.</param>
    /// <exception cref="ArgumentNullException"><paramref name="textCollection"/> is <c>null</c>.</exception>
    public AnsiFullStringBuilder(FabulousTextCollection textCollection)
    {
        TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
    }

    /// <summary>
    /// The text to be styled.
    /// </summary>
    protected FabulousTextCollection TextCollection { get; }

    /// <summary>
    /// Converts the value of an <see cref="AnsiFullStringBuilder"/> to a <see cref="string"/>.
    /// </summary>
    /// <returns>A string that can contain ANSI styling if present.</returns>
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
    /// Creates an ANSI string definition of a color in a 24-bit color format.
    /// </summary>
    /// <param name="rgb">A color in the RGB colorspace.</param>
    /// <returns>A string representing a 24-bit definition of a color, usable in ANSI consoles.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="rgb"/> is <c>null</c>.</exception>
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
