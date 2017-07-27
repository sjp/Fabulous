using NUnit.Framework;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    public class AnsiStringCleanerTests
    {
        [Test]
        public void ToAnsiCleanedString_GivenRegularText_ReturnsUnchangedText()
        {
            var input = "this is regular text";
            var cleaner = new AnsiStringCleaner(input);

            var result = cleaner.ToAnsiCleanedString();

            Assert.AreEqual(result, input);
        }

        [Test]
        public void ToAnsiCleanedString_GivenTextWithAnsiEscapes_ReturnsCleanedText()
        {
            var input = "\x1B[45mthis is a test\x1B[0m";
            var cleaner = new AnsiStringCleaner(input);

            var result = cleaner.ToAnsiCleanedString();

            Assert.AreEqual("this is a test", result);
        }

        [Test]
        public void ToAnsiCleanedString_GivenTextWithAnsiLikeText_ReturnsTextWithoutAnsiEscapes()
        {
            var input = "\x1B[45this is a test\x1B[0m\x1Bsdfb";
            var cleaner = new AnsiStringCleaner(input);

            var result = cleaner.ToAnsiCleanedString();

            Assert.AreEqual("\x1B[45this is a test\x1Bsdfb", result);
        }
    }
}
