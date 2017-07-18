namespace SJP.Fabulous.Colorspaces
{
    public interface IHsv : IColor
    {
        double Hue { get; }

        double Saturation { get; }

        double Value { get; }
    }
}
