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
        public void Equals_GivenDifferentValuedObjects_ReturnsFalse()
        {
            var message = "asd";
            var a = Fabulous.Green.Text(message);
            var b = Fabulous.Red.Text(message);

            var result = a.Equals(b);

            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_GivenSameValuedObjects_ReturnsTrue()
        {
            var message = "asd";
            var a = Fabulous.Green.Text(message);
            var b = Fabulous.Green.Text(message);

            var result = a.Equals(b);

            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_GivenSameObjects_ReturnsTrue()
        {
            var message = "asd";
            var a = Fabulous.Green.Text(message);

            var result = a.Equals(a);

            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsOp_GivenSameValuedObjects_ReturnsTrue()
        {
            var message = "asd";
            var a = Fabulous.Green.Text(message);
            var b = Fabulous.Green.Text(message);

            var result = a == b;

            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsOp_GivenDifferentValuedObjects_ReturnsFalse()
        {
            var message = "asd";
            var a = Fabulous.Green.Text(message);
            var b = Fabulous.Red.Text(message);

            var result = a == b;

            Assert.IsFalse(result);
        }

        [Test]
        public void NotEqualsOp_GivenDifferentValuedObjects_ReturnsFalse()
        {
            var message = "asd";
            var a = Fabulous.Green.Text(message);
            var b = Fabulous.Red.Text(message);

            var result = a != b;

            Assert.IsTrue(result);
        }

        [Test]
        public void NotEqualsOp_GivenSameValuedObjects_ReturnsFalse()
        {
            var message = "asd";
            var a = Fabulous.Green.Text(message);
            var b = Fabulous.Green.Text(message);

            var result = a != b;

            Assert.IsFalse(result);
        }

        [Test]
        public void Rgb_GivenValidColor_ReturnsNewObjectWithForegroundSet()
        {
            var expectedColor = new Rgb(12, 34, 56);

            FabulousText text = string.Empty;
            var result = text.Rgb(12, 34, 56);

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void BgRgb_GivenValidColor_ReturnsObjectWithBackgroundSet()
        {
            var expectedColor = new Rgb(12, 34, 56);

            FabulousText text = string.Empty;
            var result = Fabulous.BgRgb(12, 34, 56);

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void Hex_GivenValidHex_ReturnsObjectWithForegroundSet()
        {
            var expectedColor = new Rgb(143, 188, 143);

            FabulousText text = string.Empty;
            var result = Fabulous.Hex("#8FBC8F");

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void BgHex_GivenValidHex_ReturnsObjectWithBackgroundSet()
        {
            var expectedColor = new Rgb(143, 188, 143);

            FabulousText text = string.Empty;
            var result = Fabulous.BgHex("#8FBC8F");

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void Keyword_GivenValidColorName_ReturnsObjectWithForegroundSet()
        {
            var expectedColor = new Rgb(143, 188, 143);

            FabulousText text = string.Empty;
            var result = Fabulous.Keyword("DarkSeaGreen");

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Keyword_GivenValidColorNameEnum_ReturnsObjectWithForegroundSet()
        {
            var expectedColor = new Rgb(143, 188, 143);

            FabulousText text = string.Empty;
            var result = Fabulous.Keyword(ColorKeyword.DarkSeaGreen);

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void BgKeyword_GivenValidColorName_ReturnsObjectWithBackgroundSet()
        {
            var expectedColor = new Rgb(143, 188, 143);

            FabulousText text = string.Empty;
            var result = Fabulous.BgKeyword("DarkSeaGreen");

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgKeyword_GivenValidColorNameEnum_ReturnsObjectWithBackgroundSet()
        {
            var expectedColor = new Rgb(143, 188, 143);

            FabulousText text = string.Empty;
            var result = Fabulous.BgKeyword(ColorKeyword.DarkSeaGreen);

            Assert.AreEqual(expectedColor, result.BackgroundColor);
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

            var result = text.Red;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Green_PropertyGet_ReturnsObjectWithGreenForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 100, 0);

            var result = text.Green;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Yellow_PropertyGet_ReturnsObjectWithYellowForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(215, 195, 42);

            var result = text.Yellow;

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

            var result = text.Magenta;

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

            var result = text.White;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Gray_PropertyGet_ReturnsObjectWithGrayForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(128, 128, 128);

            var result = text.Gray;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void Grey_PropertyGet_ReturnsObjectWithGreyForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(128, 128, 128);

            var result = text.Grey;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void RedBright_PropertyGet_ReturnsObjectWithRedBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 0);

            var result = text.RedBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void GreenBright_PropertyGet_ReturnsObjectWithGreenBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 0);

            var result = text.GreenBright;

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

            var result = text.BlueBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void MagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 255);

            var result = text.MagentaBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void CyanBright_PropertyGet_ReturnsObjectWithCyanBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 255);

            var result = text.CyanBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void WhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightForegroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 255, 255);

            var result = text.WhiteBright;

            Assert.AreEqual(expectedColor, result.ForegroundColor);
        }

        [Test]
        public void BgBlack_PropertyGet_ReturnsObjectWithBlackBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 0);

            var result = text.Black;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgRed_PropertyGet_ReturnsObjectWithRedBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(139, 0, 0);

            var result = text.BgRed;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGreen_PropertyGet_ReturnsObjectWithGreenBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 100, 0);

            var result = text.BgGreen;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgYellow_PropertyGet_ReturnsObjectWithYellowBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(215, 195, 42);

            var result = text.BgYellow;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgBlue_PropertyGet_ReturnsObjectWithBlueBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 139);

            var result = text.BgBlue;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgMagenta_PropertyGet_ReturnsObjectWithMagentaBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(139, 0, 139);

            var result = text.BgMagenta;

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

            var result = text.BgWhite;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGray_PropertyGet_ReturnsObjectWithGrayBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(169, 169, 169);

            var result = text.BgGray;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGrey_PropertyGet_ReturnsObjectWithGreyBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(169, 169, 169);

            var result = text.BgGrey;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgRedBright_PropertyGet_ReturnsObjectWithRedBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 0);

            var result = text.BgRedBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgGreenBright_PropertyGet_ReturnsObjectWithGreenBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 0);

            var result = text.BgGreenBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgYellowBright_PropertyGet_ReturnsObjectWithYellowBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 255, 0);

            var result = text.BgYellowBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgBlueBright_PropertyGet_ReturnsObjectWithBlueBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 0, 255);

            var result = text.BgBlueBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgMagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 0, 255);

            var result = text.BgMagentaBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgCyanBright_PropertyGet_ReturnsObjectWithCyanBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(0, 255, 255);

            var result = text.BgCyanBright;

            Assert.AreEqual(expectedColor, result.BackgroundColor);
        }

        [Test]
        public void BgWhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightBackgroundColor()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(255, 255, 255);

            var result = text.BgWhiteBright;

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

            var result = text.Blink;

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

            var result = text.Dim;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Italic_PropertyGet_ReturnsObjectWithItalicDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Italic;

            var result = text.Italic;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Underline_PropertyGet_ReturnsObjectWithUnderlineDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Underline;

            var result = text.Underline;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Hidden_PropertyGet_ReturnsObjectWithHiddenDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Hidden;

            var result = text.Hidden;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Strikethrough_PropertyGet_ReturnsObjectWithStrikethroughDecorationSet()
        {
            FabulousText text = string.Empty;
            var expected = TextDecoration.Strikethrough;

            var result = text.Strikethrough;

            Assert.AreEqual(expected, result.Decorations);
        }

        [Test]
        public void Rgb_GivenValidColor_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = text.Rgb(12, 34, 56);

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgRgb_GivenValidColor_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = Fabulous.BgRgb(12, 34, 56);

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Hex_GivenValidHex_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = Fabulous.Hex("#8FBC8F");

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgHex_GivenValidHex_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = Fabulous.BgHex("#8FBC8F");

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Keyword_GivenValidColorName_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = Fabulous.Keyword("DarkSeaGreen");

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Keyword_GivenValidColorNameEnum_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = Fabulous.Keyword(ColorKeyword.DarkSeaGreen);

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgKeyword_GivenValidColorName_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = Fabulous.BgKeyword("DarkSeaGreen");

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgKeyword_GivenValidColorNameEnum_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var result = Fabulous.BgKeyword(ColorKeyword.DarkSeaGreen);

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Black_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Black;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Red_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Red;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Green_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Green;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Yellow_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Yellow;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Blue_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = Fabulous.Blue;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Magenta_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Magenta;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Cyan_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = Fabulous.Cyan;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void White_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.White;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Gray_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Gray;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Grey_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Grey;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void RedBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.RedBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void GreenBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.GreenBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void YellowBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = Fabulous.YellowBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BlueBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BlueBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void MagentaBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.MagentaBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void CyanBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.CyanBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void WhiteBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.WhiteBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgBlack_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Black;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgRed_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgRed;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgGreen_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgGreen;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgYellow_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgYellow;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgBlue_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgBlue;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgMagenta_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgMagenta;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgCyan_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = Fabulous.BgCyan;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgWhite_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgWhite;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgGray_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;
            var expectedColor = new Rgb(169, 169, 169);

            var result = text.BgGray;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgGrey_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgGrey;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgRedBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgRedBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgGreenBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgGreenBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgYellowBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgYellowBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgBlueBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgBlueBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgMagentaBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgMagentaBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgCyanBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgCyanBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void BgWhiteBright_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.BgWhiteBright;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Reset_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Reset;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Blink_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Blink;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Bold_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = Fabulous.Bold;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Dim_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Dim;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Italic_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Italic;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Underline_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Underline;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Hidden_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Hidden;

            Assert.AreNotSame(text, result);
        }

        [Test]
        public void Strikethrough_PropertyGet_ReturnsNewObject()
        {
            FabulousText text = string.Empty;

            var result = text.Strikethrough;

            Assert.AreNotSame(text, result);
        }
    }
}
