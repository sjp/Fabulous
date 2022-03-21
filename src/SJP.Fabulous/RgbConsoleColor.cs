using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous;

internal static class RgbConsoleColor
{
    public static IRgb Black => new Rgb(0, 0, 0);

    public static IRgb DarkBlue => new Rgb(0, 0, 139);

    public static IRgb DarkGreen => new Rgb(0, 100, 0);

    public static IRgb DarkCyan => new Rgb(0, 139, 139);

    public static IRgb DarkRed => new Rgb(139, 0, 0);

    public static IRgb DarkMagenta => new Rgb(139, 0, 139);

    public static IRgb DarkYellow => new Rgb(215, 195, 42);

    public static IRgb DarkGray => new Rgb(128, 128, 128);

    public static IRgb DarkGrey => new Rgb(128, 128, 128);

    public static IRgb Gray => new Rgb(169, 169, 169);

    public static IRgb Grey => new Rgb(169, 169, 169);

    public static IRgb Blue => new Rgb(0, 0, 255);

    public static IRgb Green => new Rgb(0, 255, 0);

    public static IRgb Cyan => new Rgb(0, 255, 255);

    public static IRgb Red => new Rgb(255, 0, 0);

    public static IRgb Magenta => new Rgb(255, 0, 255);

    public static IRgb Yellow => new Rgb(255, 255, 0);

    public static IRgb White => new Rgb(192, 192, 192);

    public static IRgb WhiteBright => new Rgb(255, 255, 255);
}