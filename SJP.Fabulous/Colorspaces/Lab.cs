using System;
using Colourful;
using Colourful.Conversion;

namespace SJP.Fabulous.Colorspaces
{
    public interface ILab : IColor
    {
        double L { get; }

        double A { get; }

        double B { get; }
    }

    public struct Lab : ILab
    {
        public Lab((double lightness, double a, double b) values)
            : this(values.lightness, values.a, values.b)
        {
        }

        public Lab(double lightness, double a, double b)
        {
            var lab = new LabColor(lightness, a, b);
            var converter = new ColourfulConverter();
            var rgb = converter.ToRGB(lab);

            _color = new Rgb(Convert.ToByte(rgb.R), Convert.ToByte(rgb.G), Convert.ToByte(rgb.B));

            L = lightness;
            A = a;
            B = b;
        }

        public double L { get; }

        public double A { get; }

        public double B { get; }

        public IRgb ToRgb() => _color;

        private readonly IRgb _color;
    }
}
