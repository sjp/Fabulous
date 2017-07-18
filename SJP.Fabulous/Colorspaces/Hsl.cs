using System;
using System.Collections.Generic;
using System.Globalization;

namespace SJP.Fabulous.Colorspaces
{
    public struct Hsl : IHsl
    {
        public Hsl((double hue, double saturation, double lightness) values)
            : this(values.hue, values.saturation, values.lightness)
        {
        }

        public Hsl(double hue, double saturation, double lightness)
        {
            hue = Math.Abs(hue);
            if (hue < 0 || hue > 360)
                throw new ArgumentOutOfRangeException("hue must be between 0 and 360", nameof(hue));
            if (saturation < 0 || saturation > 1)
                throw new ArgumentOutOfRangeException("saturation must be between 0 and 1", nameof(saturation));
            if (lightness < 0 || lightness > 1)
                throw new ArgumentOutOfRangeException("lightness must be between 0 and 1", nameof(lightness));

            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }

        public double Hue { get; }

        public double Saturation { get; }

        public double Lightness { get; }

        // TODO! implement
        public IRgb ToRgb() => throw new NotImplementedException(); //new Rgb(0, 0, 0);
    }
}
