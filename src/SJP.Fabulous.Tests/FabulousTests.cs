using System;
using NUnit.Framework;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.Tests;

[TestFixture]
internal static class FabulousTests
{
    [Test]
    public static void Foreground_NullColor_ThrowsArgNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Fabulous.Foreground(null));
    }

    [Test]
    public static void Background_NullColor_ThrowsArgNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Fabulous.Background(null));
    }

    [Test]
    public static void Hex_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => Fabulous.Hex(null));
            Assert.Throws<ArgumentNullException>(() => Fabulous.Hex(string.Empty));
            Assert.Throws<ArgumentNullException>(() => Fabulous.Hex("   "));
        });
    }

    [Test]
    public static void BgHex_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => Fabulous.BgHex(null));
            Assert.Throws<ArgumentNullException>(() => Fabulous.BgHex(string.Empty));
            Assert.Throws<ArgumentNullException>(() => Fabulous.BgHex("   "));
        });
    }

    [Test]
    public static void Keyword_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => Fabulous.Keyword(null));
            Assert.Throws<ArgumentNullException>(() => Fabulous.Keyword(string.Empty));
            Assert.Throws<ArgumentNullException>(() => Fabulous.Keyword("   "));
        });
    }

    [Test]
    public static void Keyword_GivenInvalidKeywordEnum_ThrowsArgNullException()
    {
        const ColorKeyword keyword = (ColorKeyword)293048;
        Assert.Throws<ArgumentException>(() => Fabulous.Keyword(keyword));
    }

    [Test]
    public static void BgKeyword_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => Fabulous.BgKeyword(null));
            Assert.Throws<ArgumentNullException>(() => Fabulous.BgKeyword(string.Empty));
            Assert.Throws<ArgumentNullException>(() => Fabulous.BgKeyword("   "));
        });
    }

    [Test]
    public static void BgKeyword_GivenInvalidKeywordEnum_ThrowsArgNullException()
    {
        const ColorKeyword keyword = (ColorKeyword)293048;
        Assert.Throws<ArgumentException>(() => Fabulous.BgKeyword(keyword));
    }

    [Test]
    public static void Rgb_GivenValidColor_ReturnsObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(12, 34, 56);

        var text = Fabulous.Rgb(12, 34, 56);

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgRgb_GivenValidColor_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(12, 34, 56);

        var text = Fabulous.BgRgb(12, 34, 56);

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Hex_GivenValidHex_ReturnsObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);

        var text = Fabulous.Hex("#8FBC8F");

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgHex_GivenValidHex_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);

        var text = Fabulous.BgHex("#8FBC8F");

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Keyword_GivenValidColorName_ReturnsObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);

        var text = Fabulous.Keyword("DarkSeaGreen");

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Keyword_GivenValidColorNameEnum_ReturnsObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);

        var text = Fabulous.Keyword(ColorKeyword.DarkSeaGreen);

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgKeyword_GivenValidColorName_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);

        var text = Fabulous.BgKeyword("DarkSeaGreen");

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgKeyword_GivenValidColorNameEnum_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);

        var text = Fabulous.BgKeyword(ColorKeyword.DarkSeaGreen);

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Black_PropertyGet_ReturnsObjectWithBlackForegroundColor()
    {
        var expectedColor = new Rgb(0, 0, 0);

        var text = Fabulous.Black;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Red_PropertyGet_ReturnsObjectWithRedForegroundColor()
    {
        var expectedColor = new Rgb(139, 0, 0);

        var text = Fabulous.Red;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Green_PropertyGet_ReturnsObjectWithGreenForegroundColor()
    {
        var expectedColor = new Rgb(0, 100, 0);

        var text = Fabulous.Green;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Yellow_PropertyGet_ReturnsObjectWithYellowForegroundColor()
    {
        var expectedColor = new Rgb(215, 195, 42);

        var text = Fabulous.Yellow;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Blue_PropertyGet_ReturnsObjectWithBlueForegroundColor()
    {
        var expectedColor = new Rgb(0, 0, 139);

        var text = Fabulous.Blue;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Magenta_PropertyGet_ReturnsObjectWithMagentaForegroundColor()
    {
        var expectedColor = new Rgb(139, 0, 139);

        var text = Fabulous.Magenta;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Cyan_PropertyGet_ReturnsObjectWithCyanForegroundColor()
    {
        var expectedColor = new Rgb(0, 139, 139);

        var text = Fabulous.Cyan;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void White_PropertyGet_ReturnsObjectWithWhiteForegroundColor()
    {
        var expectedColor = new Rgb(192, 192, 192);

        var text = Fabulous.White;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Gray_PropertyGet_ReturnsObjectWithGrayForegroundColor()
    {
        var expectedColor = new Rgb(169, 169, 169);

        var text = Fabulous.Gray;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Grey_PropertyGet_ReturnsObjectWithGreyForegroundColor()
    {
        var expectedColor = new Rgb(169, 169, 169);

        var text = Fabulous.Grey;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void RedBright_PropertyGet_ReturnsObjectWithRedBrightForegroundColor()
    {
        var expectedColor = new Rgb(255, 0, 0);

        var text = Fabulous.RedBright;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void GreenBright_PropertyGet_ReturnsObjectWithGreenBrightForegroundColor()
    {
        var expectedColor = new Rgb(0, 255, 0);

        var text = Fabulous.GreenBright;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void YellowBright_PropertyGet_ReturnsObjectWithYellowBrightForegroundColor()
    {
        var expectedColor = new Rgb(255, 255, 0);

        var text = Fabulous.YellowBright;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BlueBright_PropertyGet_ReturnsObjectWithBlueBrightForegroundColor()
    {
        var expectedColor = new Rgb(0, 0, 255);

        var text = Fabulous.BlueBright;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void MagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightForegroundColor()
    {
        var expectedColor = new Rgb(255, 0, 255);

        var text = Fabulous.MagentaBright;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void CyanBright_PropertyGet_ReturnsObjectWithCyanBrightForegroundColor()
    {
        var expectedColor = new Rgb(0, 255, 255);

        var text = Fabulous.CyanBright;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void WhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightForegroundColor()
    {
        var expectedColor = new Rgb(255, 255, 255);

        var text = Fabulous.WhiteBright;

        Assert.That(text.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgBlack_PropertyGet_ReturnsObjectWithBlackBackgroundColor()
    {
        var expectedColor = new Rgb(0, 0, 0);

        var text = Fabulous.Black;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgRed_PropertyGet_ReturnsObjectWithRedBackgroundColor()
    {
        var expectedColor = new Rgb(139, 0, 0);

        var text = Fabulous.BgRed;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGreen_PropertyGet_ReturnsObjectWithGreenBackgroundColor()
    {
        var expectedColor = new Rgb(0, 100, 0);

        var text = Fabulous.BgGreen;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgYellow_PropertyGet_ReturnsObjectWithYellowBackgroundColor()
    {
        var expectedColor = new Rgb(215, 195, 42);

        var text = Fabulous.BgYellow;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgBlue_PropertyGet_ReturnsObjectWithBlueBackgroundColor()
    {
        var expectedColor = new Rgb(0, 0, 139);

        var text = Fabulous.BgBlue;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgMagenta_PropertyGet_ReturnsObjectWithMagentaBackgroundColor()
    {
        var expectedColor = new Rgb(139, 0, 139);

        var text = Fabulous.BgMagenta;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgCyan_PropertyGet_ReturnsObjectWithCyanBackgroundColor()
    {
        var expectedColor = new Rgb(0, 139, 139);

        var text = Fabulous.BgCyan;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgWhite_PropertyGet_ReturnsObjectWithWhiteBackgroundColor()
    {
        var expectedColor = new Rgb(192, 192, 192);

        var text = Fabulous.BgWhite;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGray_PropertyGet_ReturnsObjectWithGrayBackgroundColor()
    {
        var expectedColor = new Rgb(169, 169, 169);

        var text = Fabulous.BgGray;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGrey_PropertyGet_ReturnsObjectWithGreyBackgroundColor()
    {
        var expectedColor = new Rgb(169, 169, 169);

        var text = Fabulous.BgGrey;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgRedBright_PropertyGet_ReturnsObjectWithRedBrightBackgroundColor()
    {
        var expectedColor = new Rgb(255, 0, 0);

        var text = Fabulous.BgRedBright;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGreenBright_PropertyGet_ReturnsObjectWithGreenBrightBackgroundColor()
    {
        var expectedColor = new Rgb(0, 255, 0);

        var text = Fabulous.BgGreenBright;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgYellowBright_PropertyGet_ReturnsObjectWithYellowBrightBackgroundColor()
    {
        var expectedColor = new Rgb(255, 255, 0);

        var text = Fabulous.BgYellowBright;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgBlueBright_PropertyGet_ReturnsObjectWithBlueBrightBackgroundColor()
    {
        var expectedColor = new Rgb(0, 0, 255);

        var text = Fabulous.BgBlueBright;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgMagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightBackgroundColor()
    {
        var expectedColor = new Rgb(255, 0, 255);

        var text = Fabulous.BgMagentaBright;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgCyanBright_PropertyGet_ReturnsObjectWithCyanBrightBackgroundColor()
    {
        var expectedColor = new Rgb(0, 255, 255);

        var text = Fabulous.BgCyanBright;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgWhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightBackgroundColor()
    {
        var expectedColor = new Rgb(255, 255, 255);

        var text = Fabulous.BgWhiteBright;

        Assert.That(text.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Reset_PropertyGet_ReturnsObjectWithConsoleResetTrue()
    {
        Assert.That(Fabulous.Reset.ConsoleReset, Is.True);
    }

    [Test]
    public static void Blink_PropertyGet_ReturnsObjectWithBlinkDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Blink;

        var text = Fabulous.Blink;

        Assert.That(text.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Bold_PropertyGet_ReturnsObjectWithBoldDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Bold;

        var text = Fabulous.Bold;

        Assert.That(text.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Dim_PropertyGet_ReturnsObjectWithDimDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Dim;

        var text = Fabulous.Dim;

        Assert.That(text.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Italic_PropertyGet_ReturnsObjectWithItalicDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Italic;

        var text = Fabulous.Italic;

        Assert.That(text.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Underline_PropertyGet_ReturnsObjectWithUnderlineDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Underline;

        var text = Fabulous.Underline;

        Assert.That(text.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Hidden_PropertyGet_ReturnsObjectWithHiddenDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Hidden;

        var text = Fabulous.Hidden;

        Assert.That(text.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Strikethrough_PropertyGet_ReturnsObjectWithStrikethroughDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Strikethrough;

        var text = Fabulous.Strikethrough;

        Assert.That(text.Decorations, Is.EqualTo(expected));
    }
}