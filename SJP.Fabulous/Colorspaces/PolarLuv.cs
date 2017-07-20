using System;
using Colourful;
using Colourful.Conversion;

namespace SJP.Fabulous.Colorspaces
{
    public interface IPolarLuv : IColor
    {
        double H { get; }

        double C { get; }

        double L { get; }
    }

    public struct PolarLuv : IPolarLuv
    {
        public PolarLuv((double l, double c, double h) values)
            : this(values.h, values.c, values.l)
        {
        }

        public PolarLuv(double l, double c, double h)
        {
            var luv = new LChuvColor(l, c, h);
            var converter = new ColourfulConverter();
            var rgb = converter.ToRGB(luv);

            _color = new Rgb(Convert.ToByte(rgb.R), Convert.ToByte(rgb.G), Convert.ToByte(rgb.B));

            H = h;
            C = c;
            L = l;
        }

        public double H { get; }

        public double C { get; }

        public double L { get; }

        public IRgb ToRgb() => _color;

        private readonly IRgb _color;
    }
}
