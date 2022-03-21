namespace SJP.Fabulous.Colorspaces;

/// <summary>
/// Defines a color in the RGB colorspace.
/// </summary>
public interface IRgb : IColor
{
    /// <summary>
    /// The red component of the color.
    /// </summary>
    byte Red { get; }

    /// <summary>
    /// The green component of the color.
    /// </summary>
    byte Green { get; }

    /// <summary>
    /// The blue component of the color.
    /// </summary>
    byte Blue { get; }
}
