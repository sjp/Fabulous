using System;
using System.Collections.Generic;
using System.Globalization;

namespace SJP.Fabulous.Colorspaces
{
    public struct Rgb : IRgb
    {
        public Rgb((byte red, byte green, byte blue) values)
            : this(values.red, values.green, values.blue)
        {
        }

        public Rgb(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }

        public IRgb ToRgb() => new Rgb(Red, Green, Blue);

        public static IRgb FromHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException(nameof(hex));

            if (hex.Length < 3)
                throw new ArgumentException("Hex string does not have enough characters. Must be either 3 or 6 hexadecimal digits.", nameof(hex));

            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 3 && hex.Length != 6)
                throw new ArgumentException("Hex string is not the correct length. Must either be 3 or 6 hexadecimal characters.", nameof(hex));

            var inputLength = hex.Length;

            var rStr = string.Empty;
            var gStr = string.Empty;
            var bStr = string.Empty;

            if (inputLength == 3)
            {
                rStr = new string(hex[0], 2);
                gStr = new string(hex[1], 2);
                bStr = new string(hex[2], 2);
            }
            else if (inputLength == 6)
            {
                rStr = hex.Substring(0, 2);
                gStr = hex.Substring(2, 2);
                bStr = hex.Substring(4, 2);
            }

            var isValidHex = true;
            isValidHex &= byte.TryParse(rStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out var r);
            isValidHex &= byte.TryParse(gStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out var g);
            isValidHex &= byte.TryParse(bStr, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out var b);

            if (!isValidHex)
                throw new ArgumentException("Hex string contains invalid hexadecimal characters. Hex string is: " + hex, nameof(hex));

            return new Rgb(r, g, b);
        }

        public static IRgb FromKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException(nameof(keyword));

            if (!_keywordColors.ContainsKey(keyword))
                throw new ArgumentOutOfRangeException(nameof(keyword), "Unknown keyword for color: " + keyword);

            return _keywordColors[keyword];
        }

        private readonly static IReadOnlyDictionary<string, Rgb> _keywordColors = new Dictionary<string, Rgb>(StringComparer.OrdinalIgnoreCase)
        {
            ["aliceblue"] = new Rgb(240, 248, 255),
            ["antiquewhite"] = new Rgb(250, 235, 215),
            ["aqua"] = new Rgb(0, 255, 255),
            ["aquamarine"] = new Rgb(127, 255, 212),
            ["azure"] = new Rgb(240, 255, 255),
            ["beige"] = new Rgb(245, 245, 220),
            ["bisque"] = new Rgb(255, 228, 196),
            ["black"] = new Rgb(0, 0, 0),
            ["blanchedalmond"] = new Rgb(255, 235, 205),
            ["blue"] = new Rgb(0, 0, 255),
            ["blueviolet"] = new Rgb(138, 43, 226),
            ["brown"] = new Rgb(165, 42, 42),
            ["burlywood"] = new Rgb(222, 184, 135),
            ["cadetblue"] = new Rgb(95, 158, 160),
            ["chartreuse"] = new Rgb(127, 255, 0),
            ["chocolate"] = new Rgb(210, 105, 30),
            ["coral"] = new Rgb(255, 127, 80),
            ["cornflowerblue"] = new Rgb(100, 149, 237),
            ["cornsilk"] = new Rgb(255, 248, 220),
            ["crimson"] = new Rgb(220, 20, 60),
            ["cyan"] = new Rgb(0, 255, 255),
            ["darkblue"] = new Rgb(0, 0, 139),
            ["darkcyan"] = new Rgb(0, 139, 139),
            ["darkgoldenrod"] = new Rgb(184, 134, 11),
            ["darkgray"] = new Rgb(169, 169, 169),
            ["darkgreen"] = new Rgb(0, 100, 0),
            ["darkgrey"] = new Rgb(169, 169, 169),
            ["darkkhaki"] = new Rgb(189, 183, 107),
            ["darkmagenta"] = new Rgb(139, 0, 139),
            ["darkolivegreen"] = new Rgb(85, 107, 47),
            ["darkorange"] = new Rgb(255, 140, 0),
            ["darkorchid"] = new Rgb(153, 50, 204),
            ["darkred"] = new Rgb(139, 0, 0),
            ["darksalmon"] = new Rgb(233, 150, 122),
            ["darkseagreen"] = new Rgb(143, 188, 143),
            ["darkslateblue"] = new Rgb(72, 61, 139),
            ["darkslategray"] = new Rgb(47, 79, 79),
            ["darkslategrey"] = new Rgb(47, 79, 79),
            ["darkturquoise"] = new Rgb(0, 206, 209),
            ["darkviolet"] = new Rgb(148, 0, 211),
            ["deeppink"] = new Rgb(255, 20, 147),
            ["deepskyblue"] = new Rgb(0, 191, 255),
            ["dimgray"] = new Rgb(105, 105, 105),
            ["dimgrey"] = new Rgb(105, 105, 105),
            ["dodgerblue"] = new Rgb(30, 144, 255),
            ["firebrick"] = new Rgb(178, 34, 34),
            ["floralwhite"] = new Rgb(255, 250, 240),
            ["forestgreen"] = new Rgb(34, 139, 34),
            ["fuchsia"] = new Rgb(255, 0, 255),
            ["gainsboro"] = new Rgb(220, 220, 220),
            ["ghostwhite"] = new Rgb(248, 248, 255),
            ["gold"] = new Rgb(255, 215, 0),
            ["goldenrod"] = new Rgb(218, 165, 32),
            ["gray"] = new Rgb(128, 128, 128),
            ["green"] = new Rgb(0, 128, 0),
            ["greenyellow"] = new Rgb(173, 255, 47),
            ["grey"] = new Rgb(128, 128, 128),
            ["honeydew"] = new Rgb(240, 255, 240),
            ["hotpink"] = new Rgb(255, 105, 180),
            ["indianred"] = new Rgb(205, 92, 92),
            ["indigo"] = new Rgb(75, 0, 130),
            ["ivory"] = new Rgb(255, 255, 240),
            ["khaki"] = new Rgb(240, 230, 140),
            ["lavender"] = new Rgb(230, 230, 250),
            ["lavenderblush"] = new Rgb(255, 240, 245),
            ["lawngreen"] = new Rgb(124, 252, 0),
            ["lemonchiffon"] = new Rgb(255, 250, 205),
            ["lightblue"] = new Rgb(173, 216, 230),
            ["lightcoral"] = new Rgb(240, 128, 128),
            ["lightcyan"] = new Rgb(224, 255, 255),
            ["lightgoldenrodyellow"] = new Rgb(250, 250, 210),
            ["lightgray"] = new Rgb(211, 211, 211),
            ["lightgreen"] = new Rgb(144, 238, 144),
            ["lightgrey"] = new Rgb(211, 211, 211),
            ["lightpink"] = new Rgb(255, 182, 193),
            ["lightsalmon"] = new Rgb(255, 160, 122),
            ["lightseagreen"] = new Rgb(32, 178, 170),
            ["lightskyblue"] = new Rgb(135, 206, 250),
            ["lightslategray"] = new Rgb(119, 136, 153),
            ["lightslategrey"] = new Rgb(119, 136, 153),
            ["lightsteelblue"] = new Rgb(176, 196, 222),
            ["lightyellow"] = new Rgb(255, 255, 224),
            ["lime"] = new Rgb(0, 255, 0),
            ["limegreen"] = new Rgb(50, 205, 50),
            ["linen"] = new Rgb(250, 240, 230),
            ["magenta"] = new Rgb(255, 0, 255),
            ["maroon"] = new Rgb(128, 0, 0),
            ["mediumaquamarine"] = new Rgb(102, 205, 170),
            ["mediumblue"] = new Rgb(0, 0, 205),
            ["mediumorchid"] = new Rgb(186, 85, 211),
            ["mediumpurple"] = new Rgb(147, 112, 219),
            ["mediumseagreen"] = new Rgb(60, 179, 113),
            ["mediumslateblue"] = new Rgb(123, 104, 238),
            ["mediumspringgreen"] = new Rgb(0, 250, 154),
            ["mediumturquoise"] = new Rgb(72, 209, 204),
            ["mediumvioletred"] = new Rgb(199, 21, 133),
            ["midnightblue"] = new Rgb(25, 25, 112),
            ["mintcream"] = new Rgb(245, 255, 250),
            ["mistyrose"] = new Rgb(255, 228, 225),
            ["moccasin"] = new Rgb(255, 228, 181),
            ["navajowhite"] = new Rgb(255, 222, 173),
            ["navy"] = new Rgb(0, 0, 128),
            ["oldlace"] = new Rgb(253, 245, 230),
            ["olive"] = new Rgb(128, 128, 0),
            ["olivedrab"] = new Rgb(107, 142, 35),
            ["orange"] = new Rgb(255, 165, 0),
            ["orangered"] = new Rgb(255, 69, 0),
            ["orchid"] = new Rgb(218, 112, 214),
            ["palegoldenrod"] = new Rgb(238, 232, 170),
            ["palegreen"] = new Rgb(152, 251, 152),
            ["paleturquoise"] = new Rgb(175, 238, 238),
            ["palevioletred"] = new Rgb(219, 112, 147),
            ["papayawhip"] = new Rgb(255, 239, 213),
            ["peachpuff"] = new Rgb(255, 218, 185),
            ["peru"] = new Rgb(205, 133, 63),
            ["pink"] = new Rgb(255, 192, 203),
            ["plum"] = new Rgb(221, 160, 221),
            ["powderblue"] = new Rgb(176, 224, 230),
            ["purple"] = new Rgb(128, 0, 128),
            ["rebeccapurple"] = new Rgb(102, 51, 153),
            ["red"] = new Rgb(255, 0, 0),
            ["rosybrown"] = new Rgb(188, 143, 143),
            ["royalblue"] = new Rgb(65, 105, 225),
            ["saddlebrown"] = new Rgb(139, 69, 19),
            ["salmon"] = new Rgb(250, 128, 114),
            ["sandybrown"] = new Rgb(244, 164, 96),
            ["seagreen"] = new Rgb(46, 139, 87),
            ["seashell"] = new Rgb(255, 245, 238),
            ["sienna"] = new Rgb(160, 82, 45),
            ["silver"] = new Rgb(192, 192, 192),
            ["skyblue"] = new Rgb(135, 206, 235),
            ["slateblue"] = new Rgb(106, 90, 205),
            ["slategray"] = new Rgb(112, 128, 144),
            ["slategrey"] = new Rgb(112, 128, 144),
            ["snow"] = new Rgb(255, 250, 250),
            ["springgreen"] = new Rgb(0, 255, 127),
            ["steelblue"] = new Rgb(70, 130, 180),
            ["tan"] = new Rgb(210, 180, 140),
            ["teal"] = new Rgb(0, 128, 128),
            ["thistle"] = new Rgb(216, 191, 216),
            ["tomato"] = new Rgb(255, 99, 71),
            ["turquoise"] = new Rgb(64, 224, 208),
            ["violet"] = new Rgb(238, 130, 238),
            ["wheat"] = new Rgb(245, 222, 179),
            ["white"] = new Rgb(255, 255, 255),
            ["whitesmoke"] = new Rgb(245, 245, 245),
            ["yellow"] = new Rgb(255, 255, 0),
            ["yellowgreen"] = new Rgb(154, 205, 50)
        };
    }
}
