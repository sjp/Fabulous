using System;
using NUnit.Framework;

namespace SJP.Fabulous.Tests;

[TestFixture]
internal static class AnsiEnhancedStringBuilderTests
{
    [Test]
    public static void Ctor_GivenNullInput_ThrowsArgNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new AnsiEnhancedStringBuilder((FabulousTextCollection)null));
    }

    [Test]
    public static void ToAnsiString_GivenOnlyFgAndBgColors_ReturnsCorrectValue()
    {
        const string message = "this is a test";
        var expected = $"\x1B[38;5;250m\x1B[48;5;16m{ message }\x1B[39m\x1B[49m";

        var text = Fabulous.White.BgBlack.Text(message);
        var builder = new AnsiEnhancedStringBuilder(text);
        var result = builder.ToAnsiString();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public static void ToAnsiString_GivenTextWithStyling_ReturnsCorrectValue()
    {
        const string message = "this is an important test";
        var expected = $"\x1B[38;5;250m\x1B[48;5;16m\x1B[1m\x1B[4m{ message }\x1B[39m\x1B[49m\x1B[22m\x1B[24m";

        var text = Fabulous.White.BgBlack.Bold.Underline.Text(message);
        var builder = new AnsiEnhancedStringBuilder(text);
        var result = builder.ToAnsiString();

        Assert.That(result, Is.EqualTo(expected));
    }
}