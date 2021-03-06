using System;
using NUnit.Framework;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    internal static class RgbTests
    {
        [Test]
        public static void Ctor_GivenTupleArg_EqualsExplicitArg()
        {
            var tuple = new Rgb((12, 34, 56));
            var expl = new Rgb(12, 34, 56);

            Assert.IsTrue(tuple == expl);
        }

        [Test]
        public static void Red_PropertyGet_MatchesCtorArg()
        {
            var rgb = new Rgb(12, 34, 56);
            Assert.AreEqual(12, rgb.Red);
        }

        [Test]
        public static void Green_PropertyGet_MatchesCtorArg()
        {
            var rgb = new Rgb(12, 34, 56);
            Assert.AreEqual(34, rgb.Green);
        }

        [Test]
        public static void Blue_PropertyGet_MatchesCtorArg()
        {
            var rgb = new Rgb(12, 34, 56);
            Assert.AreEqual(56, rgb.Blue);
        }

        [Test]
        public static void ToRgb_WhenInvoked_ReturnsEqualRgb()
        {
            var rgb = new Rgb(12, 34, 56);
            var newRgb = rgb.ToRgb();
            Assert.AreEqual(rgb, newRgb);
        }

        [Test]
        public static void ToRgb_WhenInvoked_ReturnsDifferentObject()
        {
            var rgb = new Rgb(12, 34, 56);
            var newRgb = rgb.ToRgb();
            Assert.AreNotSame(rgb, newRgb);
        }

        [Test]
        public static void ToString_WhenInvoked_ReturnsCorrectRepresentation()
        {
            var rgb = new Rgb(12, 34, 56);
            const string strRep = "Red = 12, Green = 34, Blue = 56";
            Assert.AreEqual(strRep, rgb.ToString());
        }

        [Test]
        public static void GetHashCode_GivenEqualObjects_ReturnsSameHashCode()
        {
            var rgbHash = new Rgb(12, 34, 56).GetHashCode();
            var otherRgbHash = new Rgb(12, 34, 56).GetHashCode();

            Assert.AreEqual(rgbHash, otherRgbHash);
        }

        [Test]
        public static void GetHashCode_GivenUnequalObjects_ReturnsDifferentHashCode()
        {
            var rgbHash = new Rgb(12, 34, 56).GetHashCode();
            var otherRgbHash = new Rgb(65, 43, 21).GetHashCode();

            Assert.AreNotEqual(rgbHash, otherRgbHash);
        }

        [Test]
        public static void FromHex_GivenValidFullHex_ReturnsCorrectRgbColor()
        {
            var rgb = new Rgb(12, 34, 56);
            var hexRgb = Rgb.FromHex("#0C2238");

            Assert.AreEqual(rgb, hexRgb);
        }

        [Test]
        public static void FromHex_GivenFullHexWithoutHashPrefix_ReturnsCorrectRgbColor()
        {
            var rgb = new Rgb(12, 34, 56);
            var hexRgb = Rgb.FromHex("0C2238");

            Assert.AreEqual(rgb, hexRgb);
        }

        [Test]
        public static void FromHex_GivenValidShortHex_ReturnsCorrectRgbColor()
        {
            var rgb = new Rgb(51, 68, 85);
            var hexRgb = Rgb.FromHex("#345");

            Assert.AreEqual(rgb, hexRgb);
        }

        [Test]
        public static void FromHex_GivenShortHexWithoutHashPrefix_ReturnsCorrectRgbColor()
        {
            var rgb = new Rgb(51, 68, 85);
            var hexRgb = Rgb.FromHex("345");

            Assert.AreEqual(rgb, hexRgb);
        }

        [Test]
        public static void FromHex_GivenEmptyHexString_ThrowsArgNullException()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => Rgb.FromHex(null));
                Assert.Throws<ArgumentNullException>(() => Rgb.FromHex(string.Empty));
                Assert.Throws<ArgumentNullException>(() => Rgb.FromHex("   "));
            });
        }

        [Test]
        public static void FromHex_GivenTooShortString_ThrowsArgException()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => Rgb.FromHex("12"));
                Assert.Throws<ArgumentException>(() => Rgb.FromHex("#12"));
            });
        }

        [Test]
        public static void FromHex_GivenIncorrectLengthString_ThrowsArgException()
        {
            Assert.Multiple(() =>
            {
                // > 3 but < 6
                Assert.Throws<ArgumentException>(() => Rgb.FromHex("1234"));
                Assert.Throws<ArgumentException>(() => Rgb.FromHex("#1234"));

                // >6
                Assert.Throws<ArgumentException>(() => Rgb.FromHex("1234567"));
                Assert.Throws<ArgumentException>(() => Rgb.FromHex("#1234567"));
            });
        }

        [Test]
        public static void FromKeyword_GivenEmptyKeywordString_ThrowsArgNullException()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => Rgb.FromKeyword(null));
                Assert.Throws<ArgumentNullException>(() => Rgb.FromKeyword(string.Empty));
                Assert.Throws<ArgumentNullException>(() => Rgb.FromKeyword("   "));
            });
        }

        [Test]
        public static void FromKeyword_GivenUnknownColorKeyword_ThrowsArgOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Rgb.FromKeyword("this_color_does_not_exist"));
        }

        [Test]
        public static void FromKeyword_GivenValidColorKeyword_ReturnsRgbColorDefinition()
        {
            var rgb = new Rgb(255, 69, 0);
            var orangeRed = Rgb.FromKeyword("orangered");

            Assert.AreEqual(rgb, orangeRed);
        }

        [Test]
        public static void FromKeyword_GivenColorKeywordWithDifferentCase_ReturnsRgbColorDefinition()
        {
            var rgb = new Rgb(255, 69, 0);
            var orangeRed = Rgb.FromKeyword("orAnGeRed");

            Assert.AreEqual(rgb, orangeRed);
        }

        [Test]
        public static void FromKeyword_GivenColorKeywordWithInvalidEnum_ThrowsArgException()
        {
            const ColorKeyword badEnum = (ColorKeyword)293048;
            Assert.Throws<ArgumentException>(() => Rgb.FromKeyword(badEnum));
        }

        [Test]
        public static void FromKeyword_GivenColorKeywordWithEnum_ReturnsRgbColorDefinition()
        {
            var rgb = new Rgb(255, 69, 0);
            var orangeRed = Rgb.FromKeyword(ColorKeyword.OrangeRed);

            Assert.AreEqual(rgb, orangeRed);
        }
    }
}
