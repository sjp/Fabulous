using System;
using NUnit.Framework;
using Moq;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    public class FabulousTextTests
    {
        [Test]
        public void Ctor_NullForeground_ThrowsArgNullException()
        {
            var color = Mock.Of<IColor>();
            Assert.Throws<ArgumentNullException>(() => new FabulousText(null, color, TextDecoration.None, string.Empty));
        }

        [Test]
        public void Ctor_NullBackground_ThrowsArgNullException()
        {
            var color = Mock.Of<IColor>();
            Assert.Throws<ArgumentNullException>(() => new FabulousText(color, null, TextDecoration.None, string.Empty));
        }

        [Test]
        public void Ctor_InvalidDecorations_ThrowsArgException()
        {
            var color = Mock.Of<IColor>();
            var decorations = (TextDecoration)234908;

            Assert.Throws<ArgumentException>(() => new FabulousText(color, color, decorations, string.Empty));
        }

        [Test]
        public void Foreground_NullColor_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            Assert.Throws<ArgumentNullException>(() => text.Foreground(null));
        }

        [Test]
        public void Background_NullColor_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            Assert.Throws<ArgumentNullException>(() => text.Background(null));
        }

        [Test]
        public void Hex_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => text.Hex(null));
                Assert.Throws<ArgumentNullException>(() => text.Hex(string.Empty));
                Assert.Throws<ArgumentNullException>(() => text.Hex("   "));
            });
        }

        [Test]
        public void BgHex_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => text.BgHex(null));
                Assert.Throws<ArgumentNullException>(() => text.BgHex(string.Empty));
                Assert.Throws<ArgumentNullException>(() => text.BgHex("   "));
            });
        }

        [Test]
        public void Keyword_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => text.Keyword(null));
                Assert.Throws<ArgumentNullException>(() => text.Keyword(string.Empty));
                Assert.Throws<ArgumentNullException>(() => text.Keyword("   "));
            });
        }

        [Test]
        public void Keyword_GivenInvalidKeywordEnum_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            var keyword = (ColorKeyword)293048;
            Assert.Throws<ArgumentException>(() => text.Keyword(keyword));
        }

        [Test]
        public void BgKeyword_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => text.BgKeyword(null));
                Assert.Throws<ArgumentNullException>(() => text.BgKeyword(string.Empty));
                Assert.Throws<ArgumentNullException>(() => text.BgKeyword("   "));
            });
        }

        [Test]
        public void BgKeyword_GivenInvalidKeywordEnum_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;

            var keyword = (ColorKeyword)293048;
            Assert.Throws<ArgumentException>(() => Fabulous.BgKeyword(keyword));
        }

        [Test]
        public void Black_PropertyGet_ReturnsObjectWithBlackForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 0);

            var result = text.Black;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Red_PropertyGet_ReturnsObjectWithRedForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(139, 0, 0);

            var result = Fabulous.Red;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Green_PropertyGet_ReturnsObjectWithGreenForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 100, 0);

            var result = Fabulous.Green;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Yellow_PropertyGet_ReturnsObjectWithYellowForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(215, 195, 42);

            var result = Fabulous.Yellow;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Blue_PropertyGet_ReturnsObjectWithBlueForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 139);

            var result = Fabulous.Blue;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Magenta_PropertyGet_ReturnsObjectWithMagentaForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(139, 0, 139);

            var result = Fabulous.Magenta;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Cyan_PropertyGet_ReturnsObjectWithCyanForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 139, 139);

            var result = Fabulous.Cyan;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void White_PropertyGet_ReturnsObjectWithWhiteForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(192, 192, 192);

            var result = Fabulous.White;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Gray_PropertyGet_ReturnsObjectWithGrayForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(169, 169, 169);

            var result = Fabulous.Gray;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Grey_PropertyGet_ReturnsObjectWithGreyForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(169, 169, 169);

            var result = Fabulous.Grey;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void RedBright_PropertyGet_ReturnsObjectWithRedBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 0);

            var result = Fabulous.RedBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void GreenBright_PropertyGet_ReturnsObjectWithGreenBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 0);

            var result = Fabulous.GreenBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void YellowBright_PropertyGet_ReturnsObjectWithYellowBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 255, 0);

            var result = Fabulous.YellowBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void BlueBright_PropertyGet_ReturnsObjectWithBlueBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 255);

            var result = Fabulous.BlueBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void MagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 255);

            var result = Fabulous.MagentaBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void CyanBright_PropertyGet_ReturnsObjectWithCyanBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 255);

            var result = Fabulous.CyanBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void WhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 255, 255);

            var result = Fabulous.WhiteBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void BgBlack_PropertyGet_ReturnsObjectWithBlackBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 0);

            var result = Fabulous.Black;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgRed_PropertyGet_ReturnsObjectWithRedBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(139, 0, 0);

            var result = Fabulous.BgRed;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGreen_PropertyGet_ReturnsObjectWithGreenBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 100, 0);

            var result = Fabulous.BgGreen;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgYellow_PropertyGet_ReturnsObjectWithYellowBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(215, 195, 42);

            var result = Fabulous.BgYellow;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgBlue_PropertyGet_ReturnsObjectWithBlueBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 139);

            var result = Fabulous.BgBlue;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgMagenta_PropertyGet_ReturnsObjectWithMagentaBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(139, 0, 139);

            var result = Fabulous.BgMagenta;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgCyan_PropertyGet_ReturnsObjectWithCyanBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 139, 139);

            var result = Fabulous.BgCyan;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgWhite_PropertyGet_ReturnsObjectWithWhiteBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(192, 192, 192);

            var result = Fabulous.BgWhite;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGray_PropertyGet_ReturnsObjectWithGrayBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(169, 169, 169);

            var result = Fabulous.BgGray;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGrey_PropertyGet_ReturnsObjectWithGreyBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(169, 169, 169);

            var result = Fabulous.BgGrey;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgRedBright_PropertyGet_ReturnsObjectWithRedBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 0);

            var result = Fabulous.BgRedBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGreenBright_PropertyGet_ReturnsObjectWithGreenBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 0);

            var result = Fabulous.BgGreenBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgYellowBright_PropertyGet_ReturnsObjectWithYellowBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 255, 0);

            var result = Fabulous.BgYellowBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgBlueBright_PropertyGet_ReturnsObjectWithBlueBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 255);

            var result = Fabulous.BgBlueBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgMagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 255);

            var result = Fabulous.BgMagentaBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgCyanBright_PropertyGet_ReturnsObjectWithCyanBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 255);

            var result = Fabulous.BgCyanBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgWhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 255, 255);

            var result = Fabulous.BgWhiteBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void Reset_PropertyGet_ReturnsObjectWithConsoleResetTrue()
        {
            FabulousText text = string.Empty;
            Assert.IsTrue(text.Reset.ConsoleReset);
        }

        [Test]
        public void Blink_PropertyGet_ReturnsObjectWithBlinkDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Blink;

            var result = Fabulous.Blink;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Bold_PropertyGet_ReturnsObjectWithBoldDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Bold;

            var result = Fabulous.Bold;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Dim_PropertyGet_ReturnsObjectWithDimDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Dim;

            var result = Fabulous.Dim;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Italic_PropertyGet_ReturnsObjectWithItalicDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Italic;

            var result = Fabulous.Italic;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Underline_PropertyGet_ReturnsObjectWithUnderlineDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Underline;

            var result = Fabulous.Underline;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Hidden_PropertyGet_ReturnsObjectWithHiddenDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Hidden;

            var result = Fabulous.Hidden;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Strikethrough_PropertyGet_ReturnsObjectWithStrikethroughDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Strikethrough;

            var result = Fabulous.Strikethrough;

            Assert.AreEqual(expected, result.Decorations);
        }

        // TODO: test correct behaviour of
        // Rgb / BgRgb
        // Hex / BgHex
        // Keyword / BgKeyword

        // TODO
        // now to test that everything returns a new object, i.e. Assert.AreNotSame
        [Test]
        public void Foreground_WithCorrectValue_ReturnsNewObject()
        {

        }
    }
}
