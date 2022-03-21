using NUnit.Framework;

namespace SJP.Fabulous.Tests;

[TestFixture]
internal static class AnsiStringCleanerTests
{
    [Test]
    public static void ToAnsiCleanedString_GivenRegularText_ReturnsUnchangedText()
    {
        const string input = "this is regular text";
        var cleaner = new AnsiStringCleaner(input);

        var result = cleaner.ToAnsiCleanedString();

        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public static void ToAnsiCleanedString_GivenTextWithAnsiEscapes_ReturnsCleanedText()
    {
        const string input = "\x1B[45mthis is a test\x1B[0m";
        var cleaner = new AnsiStringCleaner(input);

        var result = cleaner.ToAnsiCleanedString();

        Assert.That(result, Is.EqualTo("this is a test"));
    }

    [Test]
    public static void ToAnsiCleanedString_GivenTextWithAnsiLikeText_ReturnsTextWithoutAnsiEscapes()
    {
        const string input = "\x1B[45this is a test\x1B[0m\x1Bsdfb";
        var cleaner = new AnsiStringCleaner(input);

        var result = cleaner.ToAnsiCleanedString();

        Assert.That(result, Is.EqualTo("\x1B[45this is a test\x1Bsdfb"));
    }
}