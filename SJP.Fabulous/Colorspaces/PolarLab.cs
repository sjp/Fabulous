using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colourful;
using Colourful.Conversion;

namespace SJP.Fabulous.Colorspaces
{
    public interface IPolarLab : IColor
    {
        double H { get; }

        double C { get; }

        double L { get; }
    }

    public struct PolarLab : IPolarLab
    {
        public PolarLab((double h, double c, double l) values)
            : this(values.h, values.c, values.l)
        {
        }

        public PolarLab(double h, double c, double l)
        {
            var lab = new LChabColor(l, c, h);
            var converter = new ColourfulConverter();
            var rgb = converter.ToRGB(lab);

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
