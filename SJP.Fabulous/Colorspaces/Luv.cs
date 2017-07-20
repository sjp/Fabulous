using System;
using Colourful;
using Colourful.Conversion;

namespace SJP.Fabulous.Colorspaces
{
    public interface ILuv : IColor
    {
        double L { get; }

        double U { get; }

        double V { get; }
    }

    public struct Luv : ILuv
    {
        public Luv((double lightness, double u, double v) values)
            : this(values.lightness, values.u, values.v)
        {
        }

        public Luv(double lightness, double u, double v)
        {
            var lab = new LuvColor(lightness, u, v);
            var converter = new ColourfulConverter();
            var rgb = converter.ToRGB(lab);

            _color = new Rgb(Convert.ToByte(rgb.R), Convert.ToByte(rgb.G), Convert.ToByte(rgb.B));

            L = lightness;
            U = u;
            V = v;
        }

        public double L { get; }

        public double U { get; }

        public double V { get; }

        public IRgb ToRgb() => _color;

        private readonly IRgb _color;
    }
}
