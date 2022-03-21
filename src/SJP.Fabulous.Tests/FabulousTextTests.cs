using System;
using Moq;
using NUnit.Framework;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.Tests;

[TestFixture]
internal static class FabulousTextTests
{
    [Test]
    public static void Ctor_NullForeground_ThrowsArgNullException()
    {
        var color = Mock.Of<IColor>();
        Assert.Throws<ArgumentNullException>(() => new FabulousText(null, color, TextDecoration.None, string.Empty));
    }

    [Test]
    public static void Ctor_NullBackground_ThrowsArgNullException()
    {
        var color = Mock.Of<IColor>();
        Assert.Throws<ArgumentNullException>(() => new FabulousText(color, null, TextDecoration.None, string.Empty));
    }

    [Test]
    public static void Ctor_InvalidDecorations_ThrowsArgException()
    {
        var color = Mock.Of<IColor>();
        const TextDecoration decorations = (TextDecoration)234908;

        Assert.Throws<ArgumentException>(() => new FabulousText(color, color, decorations, string.Empty));
    }

    [Test]
    public static void Foreground_NullColor_ThrowsArgNullException()
    {
        FabulousText text = string.Empty;

        Assert.Throws<ArgumentNullException>(() => text.Foreground(null));
    }

    [Test]
    public static void Background_NullColor_ThrowsArgNullException()
    {
        FabulousText text = string.Empty;

        Assert.Throws<ArgumentNullException>(() => text.Background(null));
    }

    [Test]
    public static void Hex_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
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
    public static void BgHex_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
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
    public static void Keyword_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
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
    public static void Keyword_GivenInvalidKeywordEnum_ThrowsArgNullException()
    {
        FabulousText text = string.Empty;

        const ColorKeyword keyword = (ColorKeyword)293048;
        Assert.Throws<ArgumentException>(() => text.Keyword(keyword));
    }

    [Test]
    public static void BgKeyword_GivenNullEmptyOrWhiteSpace_ThrowsArgNullException()
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
    public static void BgKeyword_GivenInvalidKeywordEnum_ThrowsArgNullException()
    {
        const ColorKeyword keyword = (ColorKeyword)293048;
        Assert.Throws<ArgumentException>(() => Fabulous.BgKeyword(keyword));
    }

    [Test]
    public static void Equals_GivenDifferentValuedObjects_ReturnsFalse()
    {
        const string message = "asd";
        var a = Fabulous.Green.Text(message);
        var b = Fabulous.Red.Text(message);

        var result = a.Equals(b);

        Assert.That(result, Is.False);
    }

    [Test]
    public static void Equals_GivenSameValuedObjects_ReturnsTrue()
    {
        const string message = "asd";
        var a = Fabulous.Green.Text(message);
        var b = Fabulous.Green.Text(message);

        var result = a.Equals(b);

        Assert.That(result, Is.True);
    }

    [Test]
    public static void Equals_GivenSameObjects_ReturnsTrue()
    {
        const string message = "asd";
        var a = Fabulous.Green.Text(message);

        var result = a.Equals(a);

        Assert.That(result, Is.True);
    }

    [Test]
    public static void EqualsOp_GivenSameValuedObjects_ReturnsTrue()
    {
        const string message = "asd";
        var a = Fabulous.Green.Text(message);
        var b = Fabulous.Green.Text(message);

        var result = a == b;

        Assert.That(result, Is.True);
    }

    [Test]
    public static void EqualsOp_GivenDifferentValuedObjects_ReturnsFalse()
    {
        const string message = "asd";
        var a = Fabulous.Green.Text(message);
        var b = Fabulous.Red.Text(message);

        var result = a == b;

        Assert.That(result, Is.False);
    }

    [Test]
    public static void NotEqualsOp_GivenDifferentValuedObjects_ReturnsFalse()
    {
        const string message = "asd";
        var a = Fabulous.Green.Text(message);
        var b = Fabulous.Red.Text(message);

        var result = a != b;

        Assert.That(result, Is.True);
    }

    [Test]
    public static void NotEqualsOp_GivenSameValuedObjects_ReturnsFalse()
    {
        const string message = "asd";
        var a = Fabulous.Green.Text(message);
        var b = Fabulous.Green.Text(message);

        var result = a != b;

        Assert.That(result, Is.False);
    }

    [Test]
    public static void Rgb_GivenValidColor_ReturnsNewObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(12, 34, 56);

        FabulousText text = string.Empty;
        var result = text.Rgb(12, 34, 56);

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgRgb_GivenValidColor_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(12, 34, 56);
        var result = Fabulous.BgRgb(12, 34, 56);

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Hex_GivenValidHex_ReturnsObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);
        var result = Fabulous.Hex("#8FBC8F");

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgHex_GivenValidHex_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);
        var result = Fabulous.BgHex("#8FBC8F");

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Keyword_GivenValidColorName_ReturnsObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);
        var result = Fabulous.Keyword(nameof(ColorKeyword.DarkSeaGreen));

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Keyword_GivenValidColorNameEnum_ReturnsObjectWithForegroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);
        var result = Fabulous.Keyword(ColorKeyword.DarkSeaGreen);

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgKeyword_GivenValidColorName_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);
        var result = Fabulous.BgKeyword(nameof(ColorKeyword.DarkSeaGreen));

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgKeyword_GivenValidColorNameEnum_ReturnsObjectWithBackgroundSet()
    {
        var expectedColor = new Rgb(143, 188, 143);
        var result = Fabulous.BgKeyword(ColorKeyword.DarkSeaGreen);

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Black_PropertyGet_ReturnsObjectWithBlackForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 0, 0);

        var result = text.Black;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Red_PropertyGet_ReturnsObjectWithRedForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(139, 0, 0);

        var result = text.Red;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Green_PropertyGet_ReturnsObjectWithGreenForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 100, 0);

        var result = text.Green;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Yellow_PropertyGet_ReturnsObjectWithYellowForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(215, 195, 42);

        var result = text.Yellow;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Blue_PropertyGet_ReturnsObjectWithBlueForegroundColor()
    {
        var expectedColor = new Rgb(0, 0, 139);
        var result = Fabulous.Blue;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Magenta_PropertyGet_ReturnsObjectWithMagentaForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(139, 0, 139);

        var result = text.Magenta;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Cyan_PropertyGet_ReturnsObjectWithCyanForegroundColor()
    {
        var expectedColor = new Rgb(0, 139, 139);
        var result = Fabulous.Cyan;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void White_PropertyGet_ReturnsObjectWithWhiteForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(192, 192, 192);

        var result = text.White;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Gray_PropertyGet_ReturnsObjectWithGrayForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(128, 128, 128);

        var result = text.Gray;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Grey_PropertyGet_ReturnsObjectWithGreyForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(128, 128, 128);

        var result = text.Grey;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void RedBright_PropertyGet_ReturnsObjectWithRedBrightForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(255, 0, 0);

        var result = text.RedBright;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void GreenBright_PropertyGet_ReturnsObjectWithGreenBrightForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 255, 0);

        var result = text.GreenBright;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void YellowBright_PropertyGet_ReturnsObjectWithYellowBrightForegroundColor()
    {
        var expectedColor = new Rgb(255, 255, 0);
        var result = Fabulous.YellowBright;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BlueBright_PropertyGet_ReturnsObjectWithBlueBrightForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 0, 255);

        var result = text.BlueBright;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void MagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(255, 0, 255);

        var result = text.MagentaBright;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void CyanBright_PropertyGet_ReturnsObjectWithCyanBrightForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 255, 255);

        var result = text.CyanBright;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void WhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightForegroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(255, 255, 255);

        var result = text.WhiteBright;

        Assert.That(result.ForegroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgBlack_PropertyGet_ReturnsObjectWithBlackBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 0, 0);

        var result = text.Black;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgRed_PropertyGet_ReturnsObjectWithRedBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(139, 0, 0);

        var result = text.BgRed;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGreen_PropertyGet_ReturnsObjectWithGreenBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 100, 0);

        var result = text.BgGreen;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgYellow_PropertyGet_ReturnsObjectWithYellowBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(215, 195, 42);

        var result = text.BgYellow;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgBlue_PropertyGet_ReturnsObjectWithBlueBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 0, 139);

        var result = text.BgBlue;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgMagenta_PropertyGet_ReturnsObjectWithMagentaBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(139, 0, 139);

        var result = text.BgMagenta;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgCyan_PropertyGet_ReturnsObjectWithCyanBackgroundColor()
    {
        var expectedColor = new Rgb(0, 139, 139);
        var result = Fabulous.BgCyan;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgWhite_PropertyGet_ReturnsObjectWithWhiteBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(192, 192, 192);

        var result = text.BgWhite;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGray_PropertyGet_ReturnsObjectWithGrayBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(169, 169, 169);

        var result = text.BgGray;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGrey_PropertyGet_ReturnsObjectWithGreyBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(169, 169, 169);

        var result = text.BgGrey;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgRedBright_PropertyGet_ReturnsObjectWithRedBrightBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(255, 0, 0);

        var result = text.BgRedBright;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgGreenBright_PropertyGet_ReturnsObjectWithGreenBrightBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 255, 0);

        var result = text.BgGreenBright;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgYellowBright_PropertyGet_ReturnsObjectWithYellowBrightBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(255, 255, 0);

        var result = text.BgYellowBright;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgBlueBright_PropertyGet_ReturnsObjectWithBlueBrightBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 0, 255);

        var result = text.BgBlueBright;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgMagentaBright_PropertyGet_ReturnsObjectWithMagentaBrightBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(255, 0, 255);

        var result = text.BgMagentaBright;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgCyanBright_PropertyGet_ReturnsObjectWithCyanBrightBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(0, 255, 255);

        var result = text.BgCyanBright;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void BgWhiteBright_PropertyGet_ReturnsObjectWithWhiteBrightBackgroundColor()
    {
        FabulousText text = string.Empty;
        var expectedColor = new Rgb(255, 255, 255);

        var result = text.BgWhiteBright;

        Assert.That(result.BackgroundColor, Is.EqualTo(expectedColor));
    }

    [Test]
    public static void Reset_PropertyGet_ReturnsObjectWithConsoleResetTrue()
    {
        FabulousText text = string.Empty;
        Assert.That(text.Reset.ConsoleReset, Is.True);
    }

    [Test]
    public static void Blink_PropertyGet_ReturnsObjectWithBlinkDecorationSet()
    {
        FabulousText text = string.Empty;
        const TextDecoration expected = TextDecoration.Blink;

        var result = text.Blink;

        Assert.That(result.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Bold_PropertyGet_ReturnsObjectWithBoldDecorationSet()
    {
        const TextDecoration expected = TextDecoration.Bold;
        var result = Fabulous.Bold;

        Assert.That(result.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Dim_PropertyGet_ReturnsObjectWithDimDecorationSet()
    {
        FabulousText text = string.Empty;
        const TextDecoration expected = TextDecoration.Dim;

        var result = text.Dim;

        Assert.That(result.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Italic_PropertyGet_ReturnsObjectWithItalicDecorationSet()
    {
        FabulousText text = string.Empty;
        const TextDecoration expected = TextDecoration.Italic;

        var result = text.Italic;

        Assert.That(result.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Underline_PropertyGet_ReturnsObjectWithUnderlineDecorationSet()
    {
        FabulousText text = string.Empty;
        const TextDecoration expected = TextDecoration.Underline;

        var result = text.Underline;

        Assert.That(result.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Hidden_PropertyGet_ReturnsObjectWithHiddenDecorationSet()
    {
        FabulousText text = string.Empty;
        const TextDecoration expected = TextDecoration.Hidden;

        var result = text.Hidden;

        Assert.That(result.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Strikethrough_PropertyGet_ReturnsObjectWithStrikethroughDecorationSet()
    {
        FabulousText text = string.Empty;
        const TextDecoration expected = TextDecoration.Strikethrough;

        var result = text.Strikethrough;

        Assert.That(result.Decorations, Is.EqualTo(expected));
    }

    [Test]
    public static void Rgb_GivenValidColor_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = text.Rgb(12, 34, 56);

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgRgb_GivenValidColor_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = Fabulous.BgRgb(12, 34, 56);

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Hex_GivenValidHex_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = Fabulous.Hex("#8FBC8F");

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgHex_GivenValidHex_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = Fabulous.BgHex("#8FBC8F");

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Keyword_GivenValidColorName_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = Fabulous.Keyword("DarkSeaGreen");

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Keyword_GivenValidColorNameEnum_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = Fabulous.Keyword(ColorKeyword.DarkSeaGreen);

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgKeyword_GivenValidColorName_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = Fabulous.BgKeyword("DarkSeaGreen");

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgKeyword_GivenValidColorNameEnum_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = Fabulous.BgKeyword(ColorKeyword.DarkSeaGreen);

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Black_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Black;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Red_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Red;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Green_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Green;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Yellow_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Yellow;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Blue_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = Fabulous.Blue;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Magenta_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Magenta;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Cyan_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = Fabulous.Cyan;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void White_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.White;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Gray_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Gray;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Grey_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Grey;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void RedBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.RedBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void GreenBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.GreenBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void YellowBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = Fabulous.YellowBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BlueBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BlueBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void MagentaBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.MagentaBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void CyanBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.CyanBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void WhiteBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.WhiteBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgBlack_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = text.BgBlack;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgRed_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgRed;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgGreen_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgGreen;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgYellow_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgYellow;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgBlue_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgBlue;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgMagenta_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgMagenta;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgCyan_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = Fabulous.BgCyan;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgWhite_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgWhite;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgGray_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;
        var result = text.BgGray;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgGrey_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgGrey;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgRedBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgRedBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgGreenBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgGreenBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgYellowBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgYellowBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgBlueBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgBlueBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgMagentaBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgMagentaBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgCyanBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgCyanBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void BgWhiteBright_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.BgWhiteBright;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Reset_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Reset;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Blink_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Blink;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Bold_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = Fabulous.Bold;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Dim_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Dim;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Italic_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Italic;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Underline_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Underline;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Hidden_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Hidden;

        Assert.That(result, Is.Not.SameAs(text));
    }

    [Test]
    public static void Strikethrough_PropertyGet_ReturnsNewObject()
    {
        FabulousText text = string.Empty;

        var result = text.Strikethrough;

        Assert.That(result, Is.Not.SameAs(text));
    }
}