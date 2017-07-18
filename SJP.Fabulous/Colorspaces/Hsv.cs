using System;
using System.Collections.Generic;
using System.Globalization;

namespace SJP.Fabulous.Colorspaces
{
    public struct Hsv : IHsv
    {
        public Hsv((double hue, double saturation, double value) values)
            : this(values.hue, values.saturation, values.value)
        {
        }

        public Hsv(double hue, double saturation, double value)
        {
            hue = Math.Abs(hue);
            if (hue < 0 || hue > 360)
                throw new ArgumentOutOfRangeException("hue must be between 0 and 360", nameof(hue));
            if (saturation < 0 || saturation > 1)
                throw new ArgumentOutOfRangeException("saturation must be between 0 and 1", nameof(saturation));
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException("value must be between 0 and 1", nameof(value));

            Hue = hue;
            Saturation = saturation;
            Value = value;
        }

        public double Hue { get; }

        public double Saturation { get; }

        public double Value { get; }

        // TODO! implement
        public IRgb ToRgb() => throw new NotImplementedException(); //new Rgb(0, 0, 0);
    }
}
