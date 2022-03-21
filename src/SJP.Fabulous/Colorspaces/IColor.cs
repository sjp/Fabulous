namespace SJP.Fabulous.Colorspaces;

/// <summary>
/// Defines methods used to support color definition.
/// </summary>
public interface IColor
{
    /// <summary>
    /// Transforms the color from the current colorspace into an RGB representation.
    /// </summary>
    /// <returns>A color that is represented in RGB.</returns>
    IRgb ToRgb();
}
