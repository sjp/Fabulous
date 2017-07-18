namespace SJP.Fabulous.Colorspaces
{
    public interface IHsl : IColor
    {
        double Hue { get; }

        double Saturation { get; }

        double Lightness { get; }
    }
}
